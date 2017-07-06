using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using PcstLib.Sqlite.Entities;
using PcstLib.Sqlite.ValueObject;
using PcstLib.Utility;

namespace PcstLib.Services
{
    public partial class AssessmentService
    {
        public static void TrackingCompleteInformation(RequestAssessmentPcsVo viewModel)
        {
            var exceptions = new List<string>();
            var listMessageErrorTotal = new List<MessageErrorVo>();
            List<SectionTempleteVo> parameters = null;
            var listSectionQuestion = new List<SectionQuestionVo>();
            foreach (var sectionVo in viewModel.Sections)
            {
                listSectionQuestion.AddRange(sectionVo.SectionQuestions);
            }
            listSectionQuestion = listSectionQuestion.OrderBy(o => o.Order).ToList();

            foreach (var item in viewModel.AssessmentSectionQuestions)
            {
                if (item.Order == 44)
                {

                }
                item.IsValid = null;
                var objSection = listSectionQuestion.FirstOrDefault(o => o.Order == item.Order);
                if (objSection != null)
                {
                    var str = objSection.Parameters;
                    parameters = JsonConvert.DeserializeObject<List<SectionTempleteVo>>(str);
                    var countParameter = parameters.Count;
                    var index = 0;
                    var listMessageError = new List<MessageErrorVo>();
                    foreach (var parameter in parameters)
                    {
                        if (item.Order == 49 && parameter.Name.Contains("08"))
                        {

                        }

                        index++;
                        var val = GetPropValue(item, parameter.Name);

                        //To check Staffing Schedule of Each Agency or Provider Providing Services
                        if (parameter.CheckListStaffingScheduleServices == true)
                        {
                            CheckListStaffingScheduleServices(parameter, item, val, listMessageError);
                        }
                        //Schedule of any informal supports 
                        else if (parameter.CheckListInformalSupports == true)
                        {
                            CheckListInformalSupports(parameter, item, val, listMessageError);
                        }
                        //List of Diagnoses Conditions 
                        else if (parameter.CheckTypeListDiagnosesConditions == true)
                        {
                            if (val == null)
                            {
                                item.IsValid = false;
                                AddMessageError(parameter, listMessageError, item);
                            }
                            else
                            {
                                CheckTypeListDiagnosesConditions(parameter, item, val, listMessageError);
                            }
                        }
                        //MOT List Other Miscellaneous
                        else if (parameter.CheckTypeListOtherMiscellaneous == true)
                        {
                            #region
                            //if (item.IsValid != false)
                            //{
                            var referField = parameter.ReferRequiredField;
                            var referFieldVal = parameter.ReferRequiredValueField;
                            if (referField != null && referFieldVal != null)
                            {
                                var valOfReferField = GetPropValue(item, referField);
                                if (valOfReferField != null)
                                {
                                    if (referFieldVal.Contains(valOfReferField.ToString().ToLower()))
                                    {
                                        if (val == null)
                                        {
                                            item.IsValid = false;
                                            AddMessageError(parameter, listMessageError, item);
                                        }
                                        else
                                        {
                                            CheckTypeListOtherMiscellaneous(parameter, item, val, listMessageError);
                                            //check Max value
                                            //var row = 0;
                                            //var listObj = JsonConvert.DeserializeObject<List<OrderItemReport>>(val.ToString());
                                            //foreach (var obj in listObj)
                                            //{
                                            //    //Max per day 
                                            //    if (parameter.MaxValuePerDay != null)
                                            //    {
                                            //        if (!string.IsNullOrEmpty(obj.Field02))
                                            //        {
                                            //            row++;
                                            //            var perDay = Convert.ToInt32(obj.Field02);
                                            //            if (perDay > parameter.MaxValuePerDay.GetValueOrDefault())
                                            //            {
                                            //                item.IsValid = false;
                                            //                AddMessageErrorMaxValueMiscellaneous(parameter, listMessageError, item, parameter.MaxValuePerDay.GetValueOrDefault(), row, 1);
                                            //            }

                                            //            var perWeek = Convert.ToInt32(obj.Field03);
                                            //            if (perWeek > parameter.MaxValuePerWeek.GetValueOrDefault())
                                            //            {
                                            //                item.IsValid = false;
                                            //                AddMessageErrorMaxValueMiscellaneous(parameter, listMessageError, item, parameter.MaxValuePerWeek.GetValueOrDefault(), row, 2);
                                            //            }

                                            //        }
                                            //    }
                                            //}


                                        }
                                    }
                                }
                                //}
                            }
                            #endregion                       
                        }
                        //Check  Demonstrated Ability to required option
                        else if (parameter.AbilityField != null && parameter.AbilityFieldToRequred != null)
                        {
                            CheckReferRequiredFieldDemonstratedAbility(parameter, item, parameters, val, listMessageError);
                        }
                        else if (val == null || string.IsNullOrEmpty(val.ToString()))
                        {
                            #region
                            //Check required
                            if (parameter.IsValidation == true)
                            {
                                item.IsValid = false;
                                AddMessageError(parameter, listMessageError, item);
                            }

                            //Check Refer Field
                            if (!string.IsNullOrEmpty(parameter.ReferRequiredField))
                            {
                                CheckReferRequiredField(parameter, item, parameters, val, listMessageError);
                            }

                            //Check group Field DataType = string
                            if (parameter.GroupRequiredFieldString != null)
                            {
                                CheckGroupRequiredString(parameter, item, listMessageError);
                            }

                            //Check group Field DataType = bool
                            if (parameter.GroupRequiredFieldBool != null)
                            {
                                CheckGroupRequiredBool(parameter, item, listMessageError);
                            }

                            if (parameter.RefFieldToCheck != null && parameter.ListValRefFieldToCheck != null && parameter.ListSameField != null)
                            {
                                CheckReferRequiredFieldWasCheckAleast(parameter, item, listMessageError);
                            }

                            //Check Group Field is required
                            if (parameter.GroupFieldToRequired != null)
                            {
                                CheckGroupFieldToRequired(parameter, item, parameters, val, listMessageError);
                            }
                            //Check at least checkbox is checked
                            if (parameter.GroupRequiredALeastField != null && parameter.GroupRequiredALeastFieldRefer != null)
                            {
                                GroupRequiredALeastField(parameter, item, listMessageError);
                            }
                            #endregion
                        }
                        else
                        {
                            #region
                            var valStr = val.ToString();
                            switch (parameter.DataType)
                            {
                                case SectionDataType.Hour:
                                    try
                                    {
                                        DateTime dt = DateTime.Parse(DateTime.Now.ToShortDateString() + " " + valStr, new CultureInfo("en-US"));
                                    }
                                    catch (FormatException)
                                    {
                                        item.IsValid = false;
                                        AddMessageError(parameter, listMessageError, item);
                                    }
                                    break;

                                //case SectionDataType.Int:
                                //    int valInt;
                                //    if (int.TryParse(valStr, out valInt))
                                //    {
                                //        //if (parameter.IsNullIfValue != null && valInt == parameter.IsNullIfValue)
                                //        //{
                                //        //    AddMessageError(parameter, listMessageError, item);
                                //        //}
                                //        if (parameter.MaxValue != null)
                                //        {
                                //            if (parameter.MaxValue.GetValueOrDefault() < valInt)
                                //            {
                                //                item.IsValid = false;
                                //                AddMessageErrorMaxValue(parameter, listMessageError, item, parameter.MaxValue.GetValueOrDefault());
                                //            }
                                //        }
                                //    }

                                //    break;
                            }
                            #endregion
                        }
                    }

                    if (item.IsValid != false)
                    {
                        item.IsValid = true;
                    }
                    item.MessageError = JsonConvert.SerializeObject(listMessageError);
                    if (countParameter == index && listMessageError.Count > 0)
                    {
                        if (viewModel.CurrentSectionId != null)
                        {
                            if (objSection.SectionId == viewModel.CurrentSectionId + 1)
                            {
                                listMessageErrorTotal.AddRange(listMessageError);
                            }
                        }
                        else
                        {
                            listMessageErrorTotal.AddRange(listMessageError);
                        }
                    }

                }

            }
            if (exceptions.Count > 0)
            {
                viewModel.Exceptions = exceptions;
            }
            if (listMessageErrorTotal.Count > 0)
            {
                viewModel.MessageErrorTotal = listMessageErrorTotal;
            }
        }

        private static void AddMessageError(SectionTempleteVo parameter, List<MessageErrorVo> listMessageError, AssQuestionVo item)
        {
            if (!string.IsNullOrEmpty(parameter.MessageError))
            {
                var order = CaculatorHelper.GetNumberFromString(parameter.Name);
                if (listMessageError.Any())
                {
                    var checkOrderExist = listMessageError.FirstOrDefault(o => o.Order == order);
                    if (checkOrderExist == null)
                    {
                        listMessageError.Add(new MessageErrorVo
                        {
                            Order = order,
                            Id = "Order" + item.Order + "-" + parameter.Name,
                            MessageError = string.Format(parameter.MessageError, item.Order)
                        });
                    }
                }
                else
                {
                    listMessageError.Add(new MessageErrorVo
                    {
                        Order = order,
                        Id = "Order" + item.Order + "-" + parameter.Name,
                        MessageError = string.Format(parameter.MessageError, item.Order)
                    });
                }
            }
        }

        private static void AddMessageErrorMaxValue(SectionTempleteVo parameter, List<MessageErrorVo> listMessageError, AssQuestionVo item, int maxValue)
        {

            if (!string.IsNullOrEmpty(parameter.MessageErrorMaxValue))
            {
                var order = CaculatorHelper.GetNumberFromString(parameter.Name);
                if (listMessageError.Any())
                {
                    var checkOrderExist = listMessageError.FirstOrDefault(o => o.Order == order);
                    if (checkOrderExist == null)
                    {
                        listMessageError.Add(new MessageErrorVo
                        {
                            Order = order,
                            Id = "Order" + item.Order + "-" + parameter.Name,
                            MessageError = string.Format(parameter.MessageErrorMaxValue, item.Order, maxValue)
                        });
                    }
                }
                else
                {
                    listMessageError.Add(new MessageErrorVo
                    {
                        Order = order,
                        Id = "Order" + item.Order + "-" + parameter.Name,
                        MessageError = string.Format(parameter.MessageErrorMaxValue, item.Order, maxValue)
                    });
                }
            }
        }

        private static void AddMessageErrorMaxValueMiscellaneous(SectionTempleteVo parameter, List<MessageErrorVo> listMessageError, AssQuestionVo item, int maxValue, int row, int typeMess)
        {
            //var message = "Item {0}: Value input is greater than Max Value Allow";
            if (!string.IsNullOrEmpty(parameter.MessageErrorMaxValueMiscellaneousPerDay)
                || !string.IsNullOrEmpty(parameter.MessageErrorMaxValueMiscellaneousPerWeek))
            {
                var mess = string.Empty;
                if (!string.IsNullOrEmpty(parameter.MessageErrorMaxValueMiscellaneousPerDay) && typeMess == 1)
                {
                    mess = parameter.MessageErrorMaxValueMiscellaneousPerDay;
                }

                if (!string.IsNullOrEmpty(parameter.MessageErrorMaxValueMiscellaneousPerWeek) && typeMess == 2)
                {
                    mess = parameter.MessageErrorMaxValueMiscellaneousPerWeek;
                }
                if (!string.IsNullOrEmpty(mess))
                {
                    var order = CaculatorHelper.GetNumberFromString(parameter.Name);
                    //if (listMessageError.Any())
                    //{
                    //    var checkOrderExist = listMessageError.FirstOrDefault(o => o.Order == order);
                    //    if (checkOrderExist == null)
                    //    {
                    //        listMessageError.Add(new MessageErrorVo
                    //        {
                    //            Order = order,
                    //            Id = "Order" + item.Order + "-" + parameter.Name,
                    //            MessageError = string.Format(mess, item.Order, row, maxValue)
                    //        });
                    //    }
                    //}
                    //else
                    //{
                    //    listMessageError.Add(new MessageErrorVo
                    //    {
                    //        Order = order,
                    //        Id = "Order" + item.Order + "-" + parameter.Name,
                    //        MessageError = string.Format(mess, item.Order, row, maxValue)
                    //    });
                    //}
                    listMessageError.Add(new MessageErrorVo
                    {
                        Order = order,
                        Id = "Order" + item.Order + "-" + parameter.Name,
                        MessageError = string.Format(mess, item.Order, row, maxValue)
                    });
                }
            }
        }

        private static void AddMessageErrorMiscellaneousRequired(SectionTempleteVo parameter, List<MessageErrorVo> listMessageError, AssQuestionVo item, int row, int typeMess)
        {
            if (!string.IsNullOrEmpty(parameter.MessageErrorMiscellaneousName)
                || !string.IsNullOrEmpty(parameter.MessageErrorMiscellaneousPerDay)
                || !string.IsNullOrEmpty(parameter.MessageErrorMiscellaneousPerWeek))
            {
                var mess = string.Empty;
                if (!string.IsNullOrEmpty(parameter.MessageErrorMiscellaneousName) && typeMess == 1)
                {
                    mess = parameter.MessageErrorMiscellaneousName;
                }

                if (!string.IsNullOrEmpty(parameter.MessageErrorMiscellaneousPerDay) && typeMess == 2)
                {
                    mess = parameter.MessageErrorMiscellaneousPerDay;
                }

                if (!string.IsNullOrEmpty(parameter.MessageErrorMiscellaneousPerWeek) && typeMess == 3)
                {
                    mess = parameter.MessageErrorMiscellaneousPerWeek;
                }

                if (!string.IsNullOrEmpty(mess))
                {
                    var order = CaculatorHelper.GetNumberFromString(parameter.Name);
                    listMessageError.Add(new MessageErrorVo
                    {
                        Order = order,
                        Id = "Order" + item.Order + "-" + parameter.Name,
                        MessageError = string.Format(mess, item.Order, row)
                    });
                }
            }
        }
        private static void CheckTypeListOtherMiscellaneous(SectionTempleteVo parameter, AssQuestionVo item, object val, List<MessageErrorVo> listMessageError)
        {
            var listObj = JsonConvert.DeserializeObject<List<OrderItemReport>>(val.ToString());
            foreach (var obj in listObj)
            {
                var flag = false;
                for (int i = 1; i <= 3; i++)
                {
                    var strField = i >= 10 ? "Field" + i : "Field0" + i;
                    var objVal = GetPropValue(obj, strField);
                    if (objVal != null && !string.IsNullOrEmpty(objVal.ToString()))
                    {
                        flag = true;
                    }
                }
                if (!flag)
                {
                    AddMessageError(parameter, listMessageError, item);
                    item.IsValid = false;
                    return;
                }
            }

            var row = 0;
            foreach (var obj1 in listObj)
            {
                row++;
                for (int i = 1; i <= 3; i++)
                {
                    var strField = i >= 10 ? "Field" + i : "Field0" + i;
                    var objVal = GetPropValue(obj1, strField);
                    if (strField.Equals("Field01"))
                    {
                        if (objVal == null || string.IsNullOrEmpty(objVal.ToString()))
                        {
                            item.IsValid = false;
                            AddMessageErrorMiscellaneousRequired(parameter, listMessageError, item, row, 1);
                        }
                    }
                    if (strField.Equals("Field02"))
                    {
                        if (objVal == null || string.IsNullOrEmpty(objVal.ToString()))
                        {
                            item.IsValid = false;
                            AddMessageErrorMiscellaneousRequired(parameter, listMessageError, item, row, 2);
                        }
                    }
                    if (strField.Equals("Field03"))
                    {
                        if (objVal == null || string.IsNullOrEmpty(objVal.ToString()))
                        {
                            item.IsValid = false;
                            AddMessageErrorMiscellaneousRequired(parameter, listMessageError, item, row, 3);
                        }
                    }
                }
            }
        }

        private static void CheckTypeListDiagnosesConditions(SectionTempleteVo parameter, AssQuestionVo item, object val, List<MessageErrorVo> listMessageError)
        {
            var listObj = JsonConvert.DeserializeObject<List<OrderItemReport>>(val.ToString());
            if (listObj.Count == 0)
            {
                item.IsValid = false;
                AddMessageError(parameter, listMessageError, item);
                return;
            }
            foreach (var obj in listObj)
            {
                var flag = false;
                for (int i = 1; i <= 4; i++)
                {
                    var strField = i >= 10 ? "Field" + i : "Field0" + i;
                    var objVal = GetPropValue(obj, strField);
                    if (objVal != null && !string.IsNullOrEmpty(objVal.ToString()))
                    {
                        flag = true;
                    }
                }
                if (!flag)
                {
                    item.IsValid = false;
                    AddMessageError(parameter, listMessageError, item);
                    return;
                }
            }
        }
        private static void AddMessageErrorImformalSupport(SectionTempleteVo parameter, List<MessageErrorVo> listMessageError,
            AssQuestionVo item, int row, string fieldName)
        {
            var order = CaculatorHelper.GetNumberFromString(parameter.Name);
            listMessageError.Add(new MessageErrorVo
            {
                Order = order,
                Id = "Order" + item.Order + "-" + parameter.Name,
                MessageError = string.Format("Item " + item.Order + ": Row " + row + " - " + fieldName + " is required.")
            });
        }
        private static void CheckListInformalSupports(SectionTempleteVo parameter, AssQuestionVo item, object val, List<MessageErrorVo> listMessageError)
        {
            var valField02 = GetPropValue(item, "Field02");
            {
                if (valField02 != null && valField02.ToString().ToLower().Equals("true"))
                {
                    return;
                }
            }

            if (val == null)
            {
                item.IsValid = false;
                AddMessageError(parameter, listMessageError, item);
                return;
            }

            var listObj = JsonConvert.DeserializeObject<List<OrderItemReport>>(val.ToString());
            var flag = false;
            var index = 0;
            foreach (var obj in listObj)
            {
                index++;
                //Check fir last mid
                if (string.IsNullOrEmpty(obj.Field01))
                {
                    item.IsValid = false;
                    //AddMessageError(parameter, listMessageError, item);
                    AddMessageErrorImformalSupport(parameter, listMessageError, item, index, "Full Name");
                    //return;
                }


                //check Relationship to Member
                if (string.IsNullOrEmpty(obj.Field02))
                {
                    item.IsValid = false;
                    //AddMessageError(parameter, listMessageError, item);
                    AddMessageErrorImformalSupport(parameter, listMessageError, item, index, "Relationship to Member");
                    //return;
                }

                //check Other Relative dc chon phai dien text
                if (!string.IsNullOrEmpty(obj.Field02) && Convert.ToInt32(obj.Field02) == 8)
                {
                    if (string.IsNullOrEmpty(obj.Field03))
                    {
                        item.IsValid = false;
                        //AddMessageError(parameter, listMessageError, item);
                        AddMessageErrorImformalSupport(parameter, listMessageError, item, index, "Other Relative");
                        //return;
                    }
                }

                //check Lives with Member 
                if (string.IsNullOrEmpty(obj.Field04))
                {
                    item.IsValid = false;
                    //AddMessageError(parameter, listMessageError, item);
                    AddMessageErrorImformalSupport(parameter, listMessageError, item, index, "Lives with Member");
                    //return;
                }

                //check list Monday,Tuesday,... phai co 1 checkbox dc chon
                var flagFieldCbWeek = false;
                for (int i = 5; i <= 32; i++)
                {
                    var strField = i >= 10 ? "Field" + i : "Field0" + i;
                    var objVal = GetPropValue(obj, strField);
                    if (objVal != null && !string.IsNullOrEmpty(objVal.ToString()))
                    {
                        if (objVal.ToString().ToLower().Equals("true"))
                        {
                            flagFieldCbWeek = true;
                        }
                    }
                }
                if (!flagFieldCbWeek)
                {
                    item.IsValid = false;
                    //AddMessageError(parameter, listMessageError, item);
                    AddMessageErrorImformalSupport(parameter, listMessageError, item, index, "Monday to Sunday");
                    //return;
                }
            }

        }

        private static void CheckListStaffingScheduleServices(SectionTempleteVo parameter, AssQuestionVo item, object val, List<MessageErrorVo> listMessageError)
        {
            var valField02 = GetPropValue(item, "Field02");
            {
                if (valField02 != null && valField02.ToString().ToLower().Equals("true"))
                {
                    return;
                }
            }
            if (val == null)
            {
                item.IsValid = false;
                AddMessageError(parameter, listMessageError, item);
                return;
            }
            var listObj = JsonConvert.DeserializeObject<List<OrderItemReport>>(val.ToString());
            foreach (var obj in listObj)
            {
                for (int i = 1; i <= 28; i++)
                {
                    var strField = i >= 10 ? "Field" + i : "Field0" + i;
                    var objVal = GetPropValue(obj, strField);
                    if (objVal != null && !string.IsNullOrEmpty(objVal.ToString()))
                    {
                        if (objVal.ToString().ToLower().Equals("true"))
                        {
                            item.IsValid = true;
                            return;
                        }
                    }
                }
            }

            item.IsValid = false;
            AddMessageError(parameter, listMessageError, item);
        }       

        private static void CheckReferRequiredField(SectionTempleteVo parameter, AssQuestionVo item, List<SectionTempleteVo> parameters, object val, List<MessageErrorVo> listMessageError)
        {
            if (parameter.ReferRequiredValueField != null && parameter.ReferRequiredValueField.Any())
            {
                var valRefer = GetPropValue(item, parameter.ReferRequiredField);
                if (valRefer != null && !string.IsNullOrEmpty(valRefer.ToString()))
                {
                    if (parameter.ReferRequiredValueField.Contains(valRefer))
                    {
                        item.IsValid = false;
                        AddMessageError(parameter, listMessageError, item);
                    }
                }
            }
        }

        private static object GetPropValue(object src, string propName)
        {
            return src.GetType().GetProperty(propName).GetValue(src, null);
        }

        private static void CheckGroupFieldToRequired(SectionTempleteVo parameter, AssQuestionVo item,
            List<SectionTempleteVo> parameters, object val, List<MessageErrorVo> listMessageError)
        {
            if (parameter.GroupFieldToRequired != null && parameter.GroupFieldToRequired.Any())
            {
                var index = 0;
                var countParameter = parameter.GroupFieldToRequired.Count();
                foreach (var field in parameter.GroupFieldToRequired)
                {
                    var data = GetPropValue(item, field);
                    if (data != null && data.ToString().ToLower().Equals("true"))
                    {
                        index++;
                    }

                }
                if (index == countParameter)
                {
                    if (val == null || val.ToString().ToLower().Equals("false"))
                    {
                        item.IsValid = false;
                        AddMessageError(parameter, listMessageError, item);
                    }
                }
            }
        }

        //At aleast checkbox is checcked
        private static void GroupRequiredALeastField(SectionTempleteVo parameter, AssQuestionVo item, List<MessageErrorVo> listMessageError)
        {
            if (parameter.GroupRequiredALeastFieldRefer != null && !string.IsNullOrEmpty(parameter.GroupRequiredALeastFieldRefer))
            {
                var dataRefer = GetPropValue(item, parameter.GroupRequiredALeastFieldRefer) as string;
                bool valueOutRefer;
                if (!string.IsNullOrEmpty(dataRefer) && bool.TryParse(dataRefer, out valueOutRefer))
                {
                    if (valueOutRefer)
                    {
                        if (parameter.GroupRequiredALeastField != null && parameter.GroupRequiredALeastField.Any())
                        {
                            var listFieldGroup = parameter.GroupRequiredALeastField;
                            foreach (var field in listFieldGroup)
                            {
                                var data = GetPropValue(item, field) as string;
                                bool valueOut;
                                if (!string.IsNullOrEmpty(data) && bool.TryParse(data, out valueOut))
                                {
                                    if (valueOut)
                                    {
                                        return;
                                    }
                                }
                            }
                            item.IsValid = false;
                            AddMessageError(parameter, listMessageError, item);
                        }
                    }
                }
            }

        }

        private static void CheckReferRequiredFieldWasCheckAleast(SectionTempleteVo parameter, AssQuestionVo item, List<MessageErrorVo> listMessageError)
        {
            if (parameter.RefFieldToCheck != null)
            {
                var valRefer = GetPropValue(item, parameter.RefFieldToCheck);
                if (valRefer != null && !string.IsNullOrEmpty(valRefer.ToString()))
                {
                    if (parameter.ListValRefFieldToCheck != null)
                    {
                        var listValue = parameter.ListValRefFieldToCheck;
                        if (listValue.Length > 0)
                        {
                            if (listValue.Contains(valRefer))
                            {
                                if (parameter.ListSameField != null)
                                {
                                    var listSameField = parameter.ListSameField;
                                    if (listSameField.Length > 0)
                                    {
                                        foreach (var field in listSameField)
                                        {
                                            var value = GetPropValue(item, field.ToString());
                                            if (value != null && value.ToString().ToLower().Equals("true"))
                                            {
                                                return;
                                            }
                                        }

                                        item.IsValid = false;
                                        AddMessageError(parameter, listMessageError, item);
                                    }
                                }
                            }
                        }
                    }
                }               
            }
        }

        private static void CheckGroupRequiredString(SectionTempleteVo parameter, AssQuestionVo item, List<MessageErrorVo> listMessageError)
        {
            if (parameter.GroupRequiredFieldString != null && parameter.GroupRequiredFieldString.Any())
            {
                var index = 0;
                var countList = parameter.GroupRequiredFieldString.Count();
                foreach (var field in parameter.GroupRequiredFieldString)
                {
                    index++;
                    var val = GetPropValue(item, field);
                    if (val != null && !string.IsNullOrEmpty(val.ToString()))
                    {
                        break;
                    }
                }
                if (index == countList)
                {
                    item.IsValid = false;
                    AddMessageError(parameter, listMessageError, item);
                }
            }

        }

        private static void CheckGroupRequiredBool(SectionTempleteVo parameter, AssQuestionVo item, List<MessageErrorVo> listMessageError)
        {
            if (parameter.GroupRequiredFieldBool != null && parameter.GroupRequiredFieldBool.Any())
            {
                var index = 0;
                var countList = parameter.GroupRequiredFieldBool.Count();
                foreach (var field in parameter.GroupRequiredFieldBool)
                {
                    index++;
                    var val = GetPropValue(item, field);
                    if (val != null && !string.IsNullOrEmpty(val.ToString()))
                    {
                        if (val.ToString().ToLower().Equals("true"))
                        {
                            return;
                        }
                    }
                }
                if (index == countList)
                {
                    item.IsValid = false;
                    AddMessageError(parameter, listMessageError, item);
                }
            }

        }

        private static void CheckReferRequiredFieldDemonstratedAbility(SectionTempleteVo parameter, AssQuestionVo item, List<SectionTempleteVo> parameters, object val, List<MessageErrorVo> listMessageError)
        {
            if (parameter.AbilityField != null && parameter.AbilityFieldToRequred.Any())
            {
                var valRefer = GetPropValue(item, parameter.AbilityField);
                if (valRefer != null && !string.IsNullOrEmpty(valRefer.ToString()))
                {
                    if (parameter.AbilityFieldToRequred.Contains(valRefer))
                    {
                        //TH : select option parameter.IsNullIfValue
                        if (parameter.IsNullIfValue != null)
                        {
                            if (val != null && !string.IsNullOrEmpty(val.ToString()))
                            {
                                int valInt;
                                if (int.TryParse(val.ToString(), out valInt))
                                {
                                    if (parameter.IsNullIfValue != null && valInt == parameter.IsNullIfValue)
                                    {
                                        item.IsValid = false;
                                        AddMessageError(parameter, listMessageError, item);
                                    }
                                }
                            }
                            else
                            {
                                item.IsValid = false;
                                AddMessageError(parameter, listMessageError, item);
                            }
                        }

                        //TH: select multicheckbox Item 50
                        if (parameter.AbilityGroupRequiredFieldBool != null)
                        {
                            if (parameter.AbilityGroupRequiredFieldBool != null && parameter.AbilityGroupRequiredFieldBool.Any())
                            {
                                var index = 0;
                                var countList = parameter.AbilityGroupRequiredFieldBool.Count();
                                foreach (var field in parameter.AbilityGroupRequiredFieldBool)
                                {
                                    index++;
                                    val = GetPropValue(item, field);
                                    if (val != null && !string.IsNullOrEmpty(val.ToString()))
                                    {
                                        if (val.ToString().ToLower().Equals("true"))
                                        {
                                            return;
                                        }
                                    }
                                }
                                if (index == countList)
                                {
                                    item.IsValid = false;
                                    AddMessageError(parameter, listMessageError, item);
                                }
                            }
                        }
                    }
                }
            }
        }
    }
}
