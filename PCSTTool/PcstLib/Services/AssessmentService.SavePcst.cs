using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using PcstLib.Sqlite;
using PcstLib.Sqlite.Entities;
using PcstLib.Sqlite.ValueObject;
using PcstLib.Utility;
using System.Configuration;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Globalization;
using System.Net;

namespace PcstLib.Services
{
    public partial class AssessmentService
    {
        public dynamic Save(string parameters)
        {
            string encyptKey = ConfigurationManager.AppSettings["EncyptKey"];
            if (string.IsNullOrEmpty(encyptKey))
            {
                throw new Exception("EncyptKey not found in App.config");
            }

            var dataJson = EncryptHelper.Base64Decode(parameters);
            var jSettings = new JsonSerializerSettings
            {
                Formatting = Formatting.Indented,
                DateTimeZoneHandling = DateTimeZoneHandling.Utc
            };
            jSettings.Converters.Add(new DefaultWrongFormatDeserialize());
            var viewModel = JsonConvert.DeserializeObject<RequestAssessmentPcsVo>(dataJson, jSettings);

            TrackingCompleteInformation(viewModel);

            var listDisclodureError = new List<MessageErrorVo>();
            var IsDisclosureFormComplete = true;
            var listError = new List<MessageErrorVo>();
            if (viewModel.IsSaveAll == true)
            {
                var checkDisclosureForm = CheckInValidDisclosureForm(viewModel.DisclosureFormVo);
                if (checkDisclosureForm.Count > 0)
                {
                    if (viewModel.MessageErrorTotal == null)
                    {
                        viewModel.MessageErrorTotal = new List<MessageErrorVo>();
                        viewModel.MessageErrorTotal.AddRange(checkDisclosureForm);
                    }
                    else
                    {
                        viewModel.MessageErrorTotal.AddRange(checkDisclosureForm);
                    }
                    listDisclodureError = checkDisclosureForm;
                    IsDisclosureFormComplete = false;
                }
                var checkMid = CheckMidDisclosureFormAndPcstForm(viewModel);
                if (checkMid.Count > 0)
                {
                    if (viewModel.MessageErrorTotal == null)
                    {
                        viewModel.MessageErrorTotal = new List<MessageErrorVo>();
                        viewModel.MessageErrorTotal.AddRange(checkMid);
                    }
                    else
                    {
                        viewModel.MessageErrorTotal.AddRange(checkMid);
                    }
                }

                if (viewModel.MessageErrorTotal != null && viewModel.MessageErrorTotal.Count > 0)
                {
                    var index = 0;
                    foreach (var item in viewModel.MessageErrorTotal)
                    {
                        index++;
                        item.Index = index;
                    }
                    //var result = new ObjectReturnVo();
                    //result.Error = viewModel.MessageErrorTotal;
                    //result.Id = viewModel.AssessmentPcsId;
                    //return result;
                    listError = viewModel.MessageErrorTotal;
                }
            }

            var assessmentData = new AssessmentDataVo
            {
                Sections = viewModel.Sections,
                AssessmentSectionQuestions = viewModel.AssessmentSectionQuestions,
            };
            //GetContentHtml(viewModel, assessmentData);

            var encryptAssessmentData =
                EncryptHelper.Encrypt(JsonConvert.SerializeObject(assessmentData), encyptKey);

            //parse string to DateTime
            if (viewModel.DisclosureFormVo.Member != null)
            {
                viewModel.DisclosureFormVo.Member.Dob =
               CaculatorHelper.TryParseDatTimeFromStr(viewModel.DisclosureFormVo.Member.DobStr);//.GetValueOrDefault();
                if (viewModel.DisclosureFormVo.Member.Signature == "_blank")
                {
                    viewModel.DisclosureFormVo.Member.Signature = null;
                }
            }
            viewModel.DisclosureFormVo.DateSigned =
                CaculatorHelper.TryParseDatTimeFromStr(viewModel.DisclosureFormVo.DateSignedStr);//.GetValueOrDefault();
            viewModel.DisclosureFormVo.TheFollowingDate =
                CaculatorHelper.TryParseDatTimeFromStr(viewModel.DisclosureFormVo.TheFollowingDateStr);//.GetValueOrDefault();
            if (viewModel.DisclosureFormVo.Guardian != null && viewModel.DisclosureFormVo.Guardian.Signature == "_blank")
            {
                viewModel.DisclosureFormVo.Guardian.Signature = null;
            }
            if (viewModel.DisclosureFormVo.IsHasProviderAgency)
            {
                //set MPI == id
                if (viewModel.DisclosureFormVo.Providers != null && viewModel.DisclosureFormVo.Providers.Count > 0)
                {
                    foreach (var dt in viewModel.DisclosureFormVo.Providers)
                    {
                        if (dt.Id != null && dt.Id.GetValueOrDefault() > 0)
                        {
                            dt.Mpi = dt.Id.ToString();
                        }
                    }
                }
            }
            else
            {
                viewModel.DisclosureFormVo.Providers = new List<ProviderDisclosureFormViewModel>();
            }
            var encryptDisclosureFormData =
                EncryptHelper.Encrypt(JsonConvert.SerializeObject(viewModel.DisclosureFormVo), encyptKey);

            var encryptMid = EncryptHelper.Encrypt(JsonConvert.SerializeObject(GetMid(viewModel)), encyptKey);

            var extensionVm = new ExtensionAssessment
            {
                DisclosureFormIsComplete = IsDisclosureFormComplete,
                ErrorDisclosureForm = listDisclodureError
            };

            var extensionStr = JsonConvert.SerializeObject(extensionVm);
            using (var context = new AssessmentContext())
            {
                //Update
                if (viewModel.AssessmentPcsId > 0)
                {
                    var assessment = context.Assessments.FirstOrDefault(o => o.Id == viewModel.AssessmentPcsId);
                    if (assessment != null)
                    {
                        assessment.FileName = viewModel.AssessmentName;
                        assessment.ModifiedOn = DateTime.Now;
                        assessment.AssessmentData = encryptAssessmentData;
                        assessment.DisclosureFormData = encryptDisclosureFormData;
                        assessment.Mid = encryptMid;
                        assessment.Extension = extensionStr;

                        context.Entry(assessment).State = EntityState.Modified;
                        context.SaveChanges();

                        var result = new ObjectReturnVo();
                        result.Id = assessment.Id;
                        result.Error = listError.Count > 0 ? listError : null;
                        return result;
                    }
                    else
                    {
                        var result = new ObjectReturnVo();
                        result.Error = new List<MessageErrorVo>
                        {
                            new MessageErrorVo
                            {
                                MessageError = "This record was delete."
                            }
                        };
                        result.Id = 0;

                        return result;
                    }
                }
                //Add
                else
                {
                    var entity = new Assessment
                    {
                        FileName = viewModel.AssessmentName,
                        FilePath = "",
                        CreatedOn = DateTime.Now,
                        ModifiedOn = DateTime.Now,
                        AssessmentData = encryptAssessmentData,
                        DisclosureFormData = encryptDisclosureFormData,
                        Mid = encryptMid,
                        Extension = extensionStr
                    };
                    context.Entry(entity).State = EntityState.Added;
                    context.SaveChanges();

                    var result = new ObjectReturnVo();
                    result.Id = entity.Id;
                    result.Error = listError;
                    return result;
                }
            }
        }

        public List<MessageErrorVo> CheckInValidPcstForm(List<AssQuestionVo> assessmentSectionQuestions)
        {
            var listError = new List<MessageErrorVo>();
            if (assessmentSectionQuestions != null)
            {
                foreach (var item in assessmentSectionQuestions)
                {
                    if (!string.IsNullOrEmpty(item.MessageError))
                    {
                        var listMessageError = JsonConvert.DeserializeObject<List<MessageErrorVo>>(item.MessageError);
                        if (listMessageError.Count > 0)
                        {
                            //foreach (var mess in listMessageError)
                            //{
                            //    listError.Add(mess.MessageError);
                            //}
                            listError.AddRange(listMessageError);
                        }

                    }
                }

            }
            return listError;
        }

        public List<MessageErrorVo> CheckInValidDisclosureForm(DisclosureFormVo disclosureFormVm)
        {
            var listError = new List<MessageErrorVo>();
            var disclosureFormVo = disclosureFormVm;
            #region Member
            var member = disclosureFormVo.Member;

            if (string.IsNullOrEmpty(member.Name))
            {
                listError.Add(new MessageErrorVo
                {
                    MessageError = "Full Name is required.(Disclosure Form)"
                });
            }

            if (string.IsNullOrEmpty(member.Address))
            {
                listError.Add(new MessageErrorVo
                {
                    MessageError = "Full Address is required.(Disclosure Form)"
                });
            }
            if (string.IsNullOrEmpty(member.Mid))
            {
                listError.Add(new MessageErrorVo
                {
                    MessageError = "ForwardHealth ID # is required.(Disclosure Form)"
                });
            }
            if (string.IsNullOrEmpty(member.DobStr))
            {
                listError.Add(new MessageErrorVo
                {
                    MessageError = "DOB is required.(Disclosure Form)"
                });
            }
            else
            {
                try
                {
                    //var valDate = DateTime.ParseExact(valStr, "MM/dd/yyyy", provider);
                    DateTime dt = DateTime.Parse(member.DobStr, new CultureInfo("en-US"));
                    if (CaculatorHelper.CompareDateTime(DateTime.Now, dt, "MM/dd/yyyy") == -1)
                    {
                        listError.Add(new MessageErrorVo
                        {
                            MessageError = "DOB should not be greater than the current date.(Disclosure Form)"
                        });
                    }
                }
                catch (FormatException)
                {

                }
            }

            #endregion
            #region Physician
            var physician = disclosureFormVo.Physician;
            if (physician != null && physician.IsHasPhysician)
            {
                if (string.IsNullOrEmpty(physician.FullName))
                {
                    listError.Add(new MessageErrorVo
                    {
                        MessageError = "Physician's Name is required.(Disclosure Form)"
                    });
                }

                if (string.IsNullOrEmpty(physician.ClinicName))
                {
                    listError.Add(new MessageErrorVo
                    {
                        MessageError = "Physician's Clinic Name is required.(Disclosure Form)"
                    });
                }

                if (string.IsNullOrEmpty(physician.Phone.RemoveFormatPhone()))
                {
                    listError.Add(new MessageErrorVo
                    {
                        MessageError = "Physician's Phone is required.(Disclosure Form)"
                    });
                }

                if (string.IsNullOrEmpty(physician.Fax.RemoveFormatPhone()))
                {
                    listError.Add(new MessageErrorVo
                    {
                        MessageError = "Physician's Fax is required.(Disclosure Form)"
                    });
                }
            }
            #endregion
            #region Other Healthcare Professtional
            var ohp = disclosureFormVo.OtherHealthcareProfessional;
            if (ohp != null && ohp.IsHasOtherHealthcareProfessional)
            {
                if (string.IsNullOrEmpty(ohp.FullName))
                {
                    listError.Add(new MessageErrorVo
                    {
                        MessageError = "Other Healthcare Professional's Name is required.(Disclosure Form)"
                    });
                }

                if (string.IsNullOrEmpty(ohp.ClinicName))
                {
                    listError.Add(new MessageErrorVo
                    {
                        MessageError = "Other Healthcare Professional's Clinic Name is required.(Disclosure Form)"
                    });
                }

                if (string.IsNullOrEmpty(ohp.Phone.RemoveFormatPhone()))
                {
                    listError.Add(new MessageErrorVo
                    {
                        MessageError = "Other Healthcare Professional's Phone is required.(Disclosure Form)"
                    });
                }

                if (string.IsNullOrEmpty(ohp.Fax.RemoveFormatPhone()))
                {
                    listError.Add(new MessageErrorVo
                    {
                        MessageError = "Other Healthcare Professional's Fax is required.(Disclosure Form)"
                    });
                }
            }
            #endregion
            #region Other As Listed
            var oal = disclosureFormVo.OtherAsListed;
            if (oal != null && oal.IsHasOtherAsListed)
            {
                foreach (var item in oal.OtherDisclosureForms)
                {
                    if (string.IsNullOrEmpty(item.Name) || string.IsNullOrEmpty(item.Relationship))
                    {
                        listError.Add(new MessageErrorVo
                        {
                            MessageError = "All fields in Other as listed are required.(Disclosure Form)"
                        });
                        break;
                    }
                }
            }
            #endregion
            #region Providers
            if (disclosureFormVo.IsHasProviderAgency)
            {
                var isHasFirstProvider = disclosureFormVo.Providers.Any(o => o.Order == 1);
                if (!isHasFirstProvider)
                {
                    listError.Add(new MessageErrorVo
                    {
                        MessageError = "Provider #1 is required.(Disclosure Form)"
                    });
                }
            }
            #endregion
            #region Other
            if (string.IsNullOrEmpty(disclosureFormVo.NotBeReleased))
            {
                listError.Add(new MessageErrorVo
                {
                    MessageError = "The following information should not be released is required.(Disclosure Form)"
                });
            }

            if (disclosureFormVo.IsOnTheFollowingDate)
            {
                if (string.IsNullOrEmpty(disclosureFormVo.TheFollowingDateStr))
                {
                    listError.Add(new MessageErrorVo
                    {
                        MessageError = "On the following date is required.(Disclosure Form)"
                    });
                }
            }


            #endregion
            #region Guardian
            var guardian = disclosureFormVo.Guardian;
            if (guardian != null)
            {
                if (!string.IsNullOrEmpty(guardian.Name) || !string.IsNullOrEmpty(guardian.Relationship) ||
                    (guardian.Signature != "_blank" && guardian.Signature != null))
                {

                    if (string.IsNullOrEmpty(guardian.Name))
                    {
                        listError.Add(new MessageErrorVo
                        {
                            MessageError = "Print Name is required.(Disclosure Form)"
                        });
                    }

                    if (string.IsNullOrEmpty(guardian.Relationship))
                    {
                        listError.Add(new MessageErrorVo
                        {
                            MessageError = "Relationship To Member is required.(Disclosure Form)"
                        });
                    }


                    if (guardian.Signature == "_blank")
                    {
                        listError.Add(new MessageErrorVo
                        {
                            MessageError = "Legal Guardian Signature is required.(Disclosure Form)"
                        });
                    }
                }

                if (string.IsNullOrEmpty(disclosureFormVo.DateSignedStr))
                {
                    listError.Add(new MessageErrorVo
                    {
                        MessageError = "Date Signed is required.(Disclosure Form)"
                    });
                }

                if (member.Signature == "_blank" || member.Signature == null)
                {
                    listError.Add(new MessageErrorVo
                    {
                        MessageError = "Member Signature is required.(Disclosure Form)"
                    });
                }

            }
            #endregion
            return listError;
        }

        public List<MessageErrorVo> CheckMidDisclosureFormAndPcstForm(RequestAssessmentPcsVo viewModel)
        {
            var listError = new List<MessageErrorVo>();
            var disclosureFormVo = viewModel.DisclosureFormVo;
            var fieldMid = viewModel.AssessmentSectionQuestions.FirstOrDefault(o => o.Order == 13);
            if (fieldMid != null)
            {
                if (!string.IsNullOrEmpty(disclosureFormVo.Member.Mid) && !string.IsNullOrEmpty(fieldMid.Field01))
                {
                    if (disclosureFormVo.Member.Mid != fieldMid.Field01)
                    {
                        listError.Add(new MessageErrorVo
                        {
                            MessageError = "MID at Disclosure Form not match PCST Form."
                        });
                    }
                }
            }
            return listError;
        }

        public string GetMid(RequestAssessmentPcsVo viewModel)
        {
            var disclosureFormVo = viewModel.DisclosureFormVo;
            var fieldMid = viewModel.AssessmentSectionQuestions.FirstOrDefault(o => o.Order == 13);
            if (fieldMid != null)
            {
                if (!string.IsNullOrEmpty(disclosureFormVo.Member.Mid))
                {
                    return disclosureFormVo.Member.Mid;
                }
                if (!string.IsNullOrEmpty(fieldMid.Field01))
                {
                    return disclosureFormVo.Member.Mid;
                }
            }
            return "";
        }

        public dynamic Verify(string parameters)
        {
            string encyptKey = ConfigurationManager.AppSettings["EncyptKey"];
            if (string.IsNullOrEmpty(encyptKey))
            {
                throw new Exception("EncyptKey not found in App.config");
            }

            var dataJson = EncryptHelper.Base64Decode(parameters);
            var jSettings = new JsonSerializerSettings
            {
                Formatting = Formatting.Indented,
                DateTimeZoneHandling = DateTimeZoneHandling.Utc
            };
            jSettings.Converters.Add(new DefaultWrongFormatDeserialize());
            var viewModel = JsonConvert.DeserializeObject<RequestAssessmentPcsVo>(dataJson, jSettings);
            //if tabSelected == 1 , Disclose form
            if (viewModel.TabSelected == 1)
            {
                var checkDisclosureForm = CheckInValidDisclosureForm(viewModel.DisclosureFormVo);
                if (checkDisclosureForm.Count > 0)
                {
                    var result = new ObjectReturnVo();
                    result.Error = checkDisclosureForm;
                    result.Id = viewModel.AssessmentPcsId;
                    return result;
                }
            }
            //if tabSelected == 2 , PCST form
            else
            {
                TrackingCompleteInformation(viewModel);
                if (viewModel.CurrentSectionId == null)
                {

                    var checkMid = CheckMidDisclosureFormAndPcstForm(viewModel);
                    if (checkMid.Count > 0)
                    {
                        if (viewModel.MessageErrorTotal == null)
                        {
                            viewModel.MessageErrorTotal = new List<MessageErrorVo>();
                            viewModel.MessageErrorTotal.AddRange(checkMid);
                        }
                        else
                        {
                            viewModel.MessageErrorTotal.AddRange(checkMid);
                        }
                    }
                    var checkErrorExpedited = CheckErrorExpedited(viewModel);
                    if (checkErrorExpedited.Count > 0)
                    {
                        viewModel.MessageErrorTotal.AddRange(checkErrorExpedited);
                    }

                }


                if (viewModel.MessageErrorTotal != null && viewModel.MessageErrorTotal.Count > 0)
                {
                    var index = 0;
                    foreach (var item in viewModel.MessageErrorTotal)
                    {
                        index++;
                        item.Index = index;
                    }
                    var result = new ObjectReturnVo();
                    result.Error = viewModel.MessageErrorTotal;
                    result.Id = viewModel.AssessmentPcsId;
                    return result;
                }
            }

            var result1 = new ObjectReturnVo();
            result1.Id = viewModel.AssessmentPcsId;
            return result1;
        }

        private List<MessageErrorVo> CheckErrorExpedited(RequestAssessmentPcsVo viewModel)
        {
            var listError = new List<MessageErrorVo>();
            var fieldRequestType = viewModel.AssessmentSectionQuestions.FirstOrDefault(o => o.Order == 5);
            var fieldPeriod = viewModel.AssessmentSectionQuestions.FirstOrDefault(o => o.Order == 64);
            if (fieldRequestType != null && fieldRequestType.Field01 != null)
            {
                if (fieldRequestType.Field01.ToString() == "2")
                {
                    if (fieldPeriod != null && fieldPeriod.Field01 != null)
                    {
                        if (fieldPeriod.Field01.ToString() != "5")
                        {
                            listError.Add(new MessageErrorVo
                            {
                                MessageError = "Item 64: You must be chosen 1 months (4 weeks) because this request is Expedited Request."
                            });
                        }
                    }
                }
            }
            return listError;
        }

        private void GetContentHtml(RequestAssessmentPcsVo objAssessmentPcs, AssessmentDataVo assessmentDataVo)
        {
            if (objAssessmentPcs.Sections != null && objAssessmentPcs.Sections.Count > 0)
            {
                var header = objAssessmentPcs.Sections.FirstOrDefault(o => o.Order == 0);

                if (header != null)
                {
                    for (int i = 1; i < 16; i++)
                    {
                        var field = "ContentHtml" + (i > 9 ? i.ToString() : "0" + i);
                        var contentHtmlSection = GetPropValue(objAssessmentPcs.Sections[i], "ResultContent");
                        if (contentHtmlSection != null && !string.IsNullOrEmpty(contentHtmlSection.ToString()))
                        {
                            SetPropValue(assessmentDataVo, field, contentHtmlSection);
                        }
                        else
                        {
                            var contentSelected = GetPropValue(assessmentDataVo, field);
                            if (contentSelected == null)
                            {
                                objAssessmentPcs.Sections[i].ResultContent = GetRootContentSection(objAssessmentPcs.Sections[i].Content, objAssessmentPcs, i);
                            }
                            else
                            {
                                objAssessmentPcs.Sections[i].ResultContent = assessmentDataVo.ContentHtml15;
                            }
                        }
                    }

                    assessmentDataVo.ContentHtml = CreateFileHtmlContent(TemplateHelpper.FormatTemplateWithContentTemplate(WebUtility.HtmlDecode(header.Content), new
                    {
                        section1 = string.IsNullOrEmpty(objAssessmentPcs.Sections[1].ResultContent) ? "" : objAssessmentPcs.Sections[1].ResultContent,
                        section2 = string.IsNullOrEmpty(objAssessmentPcs.Sections[2].ResultContent) ? "" : objAssessmentPcs.Sections[2].ResultContent,
                        section3 = string.IsNullOrEmpty(objAssessmentPcs.Sections[3].ResultContent) ? "" : objAssessmentPcs.Sections[3].ResultContent,
                        section4 = string.IsNullOrEmpty(objAssessmentPcs.Sections[4].ResultContent) ? "" : objAssessmentPcs.Sections[4].ResultContent,
                        section5 = string.IsNullOrEmpty(objAssessmentPcs.Sections[5].ResultContent) ? "" : objAssessmentPcs.Sections[5].ResultContent,
                        section6 = string.IsNullOrEmpty(objAssessmentPcs.Sections[6].ResultContent) ? "" : objAssessmentPcs.Sections[6].ResultContent,
                        section7 = string.IsNullOrEmpty(objAssessmentPcs.Sections[7].ResultContent) ? "" : objAssessmentPcs.Sections[7].ResultContent,
                        section8 = string.IsNullOrEmpty(objAssessmentPcs.Sections[8].ResultContent) ? "" : objAssessmentPcs.Sections[8].ResultContent,
                        section9 = string.IsNullOrEmpty(objAssessmentPcs.Sections[9].ResultContent) ? "" : objAssessmentPcs.Sections[9].ResultContent,
                        section10 = string.IsNullOrEmpty(objAssessmentPcs.Sections[10].ResultContent) ? "" : objAssessmentPcs.Sections[10].ResultContent,
                        section11 = string.IsNullOrEmpty(objAssessmentPcs.Sections[11].ResultContent) ? "" : objAssessmentPcs.Sections[11].ResultContent,
                        section12 = string.IsNullOrEmpty(objAssessmentPcs.Sections[12].ResultContent) ? "" : objAssessmentPcs.Sections[12].ResultContent,
                        section13 = string.IsNullOrEmpty(objAssessmentPcs.Sections[13].ResultContent) ? "" : objAssessmentPcs.Sections[13].ResultContent,
                        section14 = string.IsNullOrEmpty(objAssessmentPcs.Sections[14].ResultContent) ? "" : objAssessmentPcs.Sections[14].ResultContent,
                        section15 = string.IsNullOrEmpty(objAssessmentPcs.Sections[15].ResultContent) ? "" : objAssessmentPcs.Sections[15].ResultContent,
                    }));
                }
            }

        }

        private static string GetRootContentSection(string contentRoot, RequestAssessmentPcsVo s, int order)
        {
            var result = contentRoot;
            if (s.Sections[order] != null && s.Sections[order].SectionQuestions.Count > 0)
            {
                foreach (var item in s.Sections[order].SectionQuestions)
                {
                    result = result.Replace("{{Order" + item.Order + "}}", item.Content);
                }
            }
            return result;
        }

        private static string CreateFileHtmlContent(string content)
        {
            return content;
        }
        private static void SetPropValue(object src, string propName, object val)
        {
            src.GetType().GetProperty(propName).SetValue(src, val);
        }

        public List<MessageErrorVo> CheckInValidBeforeExport(DisclosureFormVo disclosureFormVm,AssessmentDataVo assessmentForm)
        {
            var listError = new List<MessageErrorVo>();
            ////check error disclosure form
            //var listErrorDisclosureForm = CheckInValidDisclosureForm(disclosureFormVm);
            //if (listErrorDisclosureForm.Count > 0)
            //{
            //    listError.AddRange(listErrorDisclosureForm);
            //}

            //check match MID
            var fieldMid = assessmentForm.AssessmentSectionQuestions.FirstOrDefault(o => o.Order == 13);
            if (fieldMid != null)
            {
                if (string.IsNullOrEmpty(fieldMid.Field01))
                {
                    listError.Add(new MessageErrorVo
                    {
                        MessageError = "MID at PCST Form is required."
                    });
                }
                else if (!string.IsNullOrEmpty(disclosureFormVm.Member.Mid) && !string.IsNullOrEmpty(fieldMid.Field01))
                {
                    if (disclosureFormVm.Member.Mid != fieldMid.Field01)
                    {
                        listError.Add(new MessageErrorVo
                        {
                            MessageError = "MID at Disclosure Form not match PCST Form."
                        });
                    }
                }
            }
            //check is Expedited Request
            var fieldRequestType = assessmentForm.AssessmentSectionQuestions.FirstOrDefault(o => o.Order == 5);
            var fieldPeriod = assessmentForm.AssessmentSectionQuestions.FirstOrDefault(o => o.Order == 64);
            if (fieldRequestType != null && fieldRequestType.Field01 != null)
            {
                if (fieldRequestType.Field01.ToString() == "2")
                {
                    if (fieldPeriod != null && fieldPeriod.Field01 != null)
                    {
                        if (fieldPeriod.Field01.ToString() != "5")
                        {
                            listError.Add(new MessageErrorVo
                            {
                                MessageError = "PCST Form - Item 64:  You must be chosen 1 months (4 weeks) because this request is Expedited Request."
                            });
                        }
                    }
                }
            }

            
            return listError;
        }
    }
}
