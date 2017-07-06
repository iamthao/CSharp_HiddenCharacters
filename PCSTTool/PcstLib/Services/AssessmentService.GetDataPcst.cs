using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using PcstLib.Sqlite;
using PcstLib.Sqlite.Entities;
using PcstLib.Sqlite.ValueObject;
using PcstLib.Utility;

namespace PcstLib.Services
{
    public partial class AssessmentService
    {

        public RequestAssessmentPcsVo GetDataNewPcst(int id)
        {
            if (id > 0)
            {
                return GetUpdateAssessment(id);
            }
            return GetNewAssessment();
        }

        private RequestAssessmentPcsVo GetUpdateAssessment(int id)
        {
            var result = new RequestAssessmentPcsVo();
            //var SectionVos = new List<SectionVo>();
            using (var context = new AssessmentContext())
            {
                var assessment = context.Assessments.FirstOrDefault(o => o.Id == id);
                if (assessment != null)
                {
                    //Case for the new assessment
                    if (string.IsNullOrEmpty(assessment.AssessmentData) &&
                        string.IsNullOrEmpty(assessment.DisclosureFormData))
                    {
                        return GetNewAssessment(assessment.FileName,id);
                    }



                    string encyptKey = ConfigurationManager.AppSettings["EncyptKey"];
                    if (string.IsNullOrEmpty(encyptKey))
                    {
                        throw new Exception("EncyptKey not found in App.config");
                    }

                    var dataJsonAssessmentData = new AssessmentDataVo();
                    if (!string.IsNullOrEmpty(assessment.AssessmentData))
                    {
                        var decryptAssessmentData = EncryptHelper.Decrypt(assessment.AssessmentData, encyptKey);
                        dataJsonAssessmentData = JsonConvert.DeserializeObject<AssessmentDataVo>(decryptAssessmentData);
                    }                   

                    var dataJsonDiscloseData = new DisclosureFormVo();
                    if (!string.IsNullOrEmpty(assessment.DisclosureFormData))
                    {
                        var decryptDiscloseData = EncryptHelper.Decrypt(assessment.DisclosureFormData, encyptKey);
                        dataJsonDiscloseData = JsonConvert.DeserializeObject<DisclosureFormVo>(decryptDiscloseData);
                    }

                    //always get content new
                    result.Sections = GetHtmlToDisplay();//dataJsonAssessmentData.Sections;



                    result.AssessmentSectionQuestions = dataJsonAssessmentData.AssessmentSectionQuestions;
                    result.AssessmentPcsId = assessment.Id;
                    result.AssessmentName = assessment.FileName;

                    if (dataJsonDiscloseData != null && dataJsonDiscloseData.Providers != null && dataJsonDiscloseData.Providers.Count >0)
                    {
                        foreach (var dt in dataJsonDiscloseData.Providers)
                        {
                            dt.Id = CaculatorHelper.TryParseIntFromStr(dt.Mpi);
                        }
                    }
                    result.DisclosureFormVo = dataJsonDiscloseData;
                    //parse string to DateTime
                    if (result.DisclosureFormVo != null)
                    {
                        if (result.DisclosureFormVo.Member != null)
                        {
                            result.DisclosureFormVo.Member.DobStr = result.DisclosureFormVo.Member.Dob!= null?
                                result.DisclosureFormVo.Member.Dob.GetValueOrDefault().ToShortDateString():"" ;

                        }
                        result.DisclosureFormVo.DateSignedStr = result.DisclosureFormVo.DateSigned!= null?
                            result.DisclosureFormVo.DateSigned.GetValueOrDefault().ToShortDateString():"";
                        result.DisclosureFormVo.TheFollowingDateStr = result.DisclosureFormVo.TheFollowingDate != null
                            ? result.DisclosureFormVo.TheFollowingDate.GetValueOrDefault().ToShortDateString()
                            : "";
                    }
                    return result;
                }
                return GetNewAssessment();
            }
            return result;
        }
        private RequestAssessmentPcsVo GetNewAssessment(string fileName = null, int id = 0)
        {
            var result = new RequestAssessmentPcsVo();
            var SectionVos = new List<SectionVo>();

            using (var context = new DefaulDataContext())
            {
                var sections = context.Sections.ToList();
                foreach (var section in sections)
                {
                    var obj = new SectionVo
                    {
                        Id = section.Id,
                        Content = section.Content,
                        Name = section.Name,
                        Order = section.Order,
                        SectionQuestions = new List<SectionQuestionVo>(),
                    };
                    foreach (var question in section.SectionQuestions)
                    {
                        var objSectionQuestionVo = new SectionQuestionVo
                        {
                            Id = question.Id,
                            Content = question.Content,
                            Order = question.Order,
                            Parameters = question.Parameters,
                            Calculator = question.Calculator,
                            Name = question.Name,
                            IsSignature = question.IsSignature.GetValueOrDefault(),
                            IsSignatureDate = question.IsSignatureDate.GetValueOrDefault(),
                            IsBathing = question.IsBathing.GetValueOrDefault(),
                            IsADLsCal = question.IsADLsCal.GetValueOrDefault(),
                            IsMOT = question.IsMOT.GetValueOrDefault(),
                            IsMedicalAppointments = question.IsMedicalAppointments.GetValueOrDefault(),
                            IsServicesIncidental = question.IsServicesIncidental.GetValueOrDefault(),
                            IsBehaviorsMedicalConditionsSeizures =
                                question.IsBehaviorsMedicalConditionsSeizures.GetValueOrDefault(),
                            IsDiagnoses = question.IsDiagnoses.GetValueOrDefault(),
                            IsMedications = question.IsMedications.GetValueOrDefault(),
                            IsDME = question.IsDME.GetValueOrDefault(),
                            IsAllergies = question.IsAllergies.GetValueOrDefault(),
                            IsFunctionalLimitation = question.IsFunctionalLimitation.GetValueOrDefault(),
                            IsActivitiesPermitted = question.IsActivitiesPermitted.GetValueOrDefault(),
                            IsMentalStatus = question.IsMentalStatus.GetValueOrDefault(),
                            IsReassessmentDue = question.IsReassessmentDue.GetValueOrDefault(),
                            IsCheckZeroMinutesPCST = question.IsCheckZeroMinutesPCST.GetValueOrDefault(),
                            IsMid = question.IsMid,
                            SectionId = question.SectionId
                        };

                        obj.SectionQuestions.Add(objSectionQuestionVo);
                        //SectionQuestionVos.Add(objSectionQuestionVo);
                    }
                    SectionVos.Add(obj);
                }
            }
            result.Sections = SectionVos;
            result.AssessmentSectionQuestions = GetAssessmentSectionQuestion(result.Sections, result);
            result.AssessmentPcsId = id;
            result.AssessmentName = !string.IsNullOrEmpty(fileName) ? fileName : "";
            result.DisclosureFormVo = new DisclosureFormVo();
            return result;
        }

        private List<AssQuestionVo> GetAssessmentSectionQuestion(List<SectionVo> list, RequestAssessmentPcsVo objVo)
        {
            var result = new List<AssQuestionVo>();
            foreach (var section in list)
            {
                if (section.Order != 0)
                {
                    foreach (var sectionQuestion in section.SectionQuestions)
                    {
                        var obj = new AssQuestionVo
                        {
                            SectionQuestionId = sectionQuestion.Id,
                            Order = sectionQuestion.Order,
                            IsSignature = sectionQuestion.IsSignature,
                            IsMid = sectionQuestion.IsMid,
                            Name = sectionQuestion.Name,
                            SectionId = section.Order
                        };
                        result.Add(obj);
                    }
                }
            }
            return result;
        }

        public List<SectionVo> GetHtmlToDisplay()
        {
            var SectionVos = new List<SectionVo>();

            using (var context = new DefaulDataContext())
            {
                var sections = context.Sections.ToList();
                foreach (var section in sections)
                {
                    var obj = new SectionVo
                    {
                        Id = section.Id,
                        Content = section.Content,
                        Name = section.Name,
                        Order = section.Order,
                        SectionQuestions = new List<SectionQuestionVo>(),
                    };
                    foreach (var question in section.SectionQuestions)
                    {
                        var objSectionQuestionVo = new SectionQuestionVo
                        {
                            Id = question.Id,
                            Content = question.Content,
                            Order = question.Order,
                            Parameters = question.Parameters,
                            Calculator = question.Calculator,
                            Name = question.Name,
                            IsSignature = question.IsSignature.GetValueOrDefault(),
                            IsSignatureDate = question.IsSignatureDate.GetValueOrDefault(),
                            IsBathing = question.IsBathing.GetValueOrDefault(),
                            IsADLsCal = question.IsADLsCal.GetValueOrDefault(),
                            IsMOT = question.IsMOT.GetValueOrDefault(),
                            IsMedicalAppointments = question.IsMedicalAppointments.GetValueOrDefault(),
                            IsServicesIncidental = question.IsServicesIncidental.GetValueOrDefault(),
                            IsBehaviorsMedicalConditionsSeizures =
                                question.IsBehaviorsMedicalConditionsSeizures.GetValueOrDefault(),
                            IsDiagnoses = question.IsDiagnoses.GetValueOrDefault(),
                            IsMedications = question.IsMedications.GetValueOrDefault(),
                            IsDME = question.IsDME.GetValueOrDefault(),
                            IsAllergies = question.IsAllergies.GetValueOrDefault(),
                            IsFunctionalLimitation = question.IsFunctionalLimitation.GetValueOrDefault(),
                            IsActivitiesPermitted = question.IsActivitiesPermitted.GetValueOrDefault(),
                            IsMentalStatus = question.IsMentalStatus.GetValueOrDefault(),
                            IsReassessmentDue = question.IsReassessmentDue.GetValueOrDefault(),
                            IsCheckZeroMinutesPCST = question.IsCheckZeroMinutesPCST.GetValueOrDefault(),
                            IsMid = question.IsMid,
                            SectionId = question.SectionId
                        };

                        obj.SectionQuestions.Add(objSectionQuestionVo);
                        //SectionQuestionVos.Add(objSectionQuestionVo);
                    }
                    SectionVos.Add(obj);
                }
            }
            return SectionVos;
        }

    }
}
