using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using Newtonsoft.Json;
using PcstLib.Sqlite.Base;
using PcstLib.Sqlite.ValueObject;
using PcstLib.Utility;

namespace PcstLib.Sqlite.Entities
{
    public enum SectionDataType
    {
        String = 1,
        Int = 2,
        Bool = 3,
        Date = 4,
        DateTime = 5,
        Double = 6,
        Phone = 7,
        ListType1 = 8,
        Hour = 9,
    }

    public class OrderItemReport
    {
        public string Field01 { get; set; }
        public string Field02 { get; set; }
        public string Field03 { get; set; }
        public string Field04 { get; set; }
        public string Field05 { get; set; }
        public string Field06 { get; set; }
        public string Field07 { get; set; }
        public string Field08 { get; set; }
        public string Field09 { get; set; }
        public string Field10 { get; set; }
        public string Field11 { get; set; }
        public string Field12 { get; set; }
        public string Field13 { get; set; }
        public string Field14 { get; set; }
        public string Field15 { get; set; }
        public string Field16 { get; set; }
        public string Field17 { get; set; }
        public string Field18 { get; set; }
        public string Field19 { get; set; }
        public string Field20 { get; set; }
        public string Field21 { get; set; }
        public string Field22 { get; set; }
        public string Field23 { get; set; }
        public string Field24 { get; set; }
        public string Field25 { get; set; }
        public string Field26 { get; set; }
        public string Field27 { get; set; }
        public string Field28 { get; set; }
        public string Field29 { get; set; }
        public string Field30 { get; set; }
        public string Field31 { get; set; }
        public string Field32 { get; set; }
        public string Field33 { get; set; }
        public string Field34 { get; set; }
        public string Field35 { get; set; }
        public string Field36 { get; set; }
        public string Field37 { get; set; }
        public string Field38 { get; set; }
        public string Field39 { get; set; }
        public string Field40 { get; set; }
        public string Field41 { get; set; }
        public string Field42 { get; set; }
        public string Field43 { get; set; }
        public string Field44 { get; set; }
        public string Field45 { get; set; }
        public string Field46 { get; set; }
        public string Field47 { get; set; }
        public string Field48 { get; set; }
        public string Field49 { get; set; }
        public string Field50 { get; set; }
        public int Order { get; set; }
    }

    public class ValInOut
    {
        public int ValIn { get; set; }
        public int? ValOut { get; set; }
        public int? ValOutRuleBathing { get; set; }
        public string ReferTo { get; set; }
        public int? MaxValue { get; set; }
        public List<ValInOut> ValOuts { get; set; }
    }

    public class ConfigItem
    {
        public List<ValInOut> ValInOuts { get; set; }
        public string ForField { get; set; }
    }

    public class ConfigRefer
    {
        public int Order { get; set; }
        public string Field { get; set; }
        public string Value { get; set; }
        public string ReferField { get; set; }
        public string ReferValue { get; set; }
        public string Operator { get; set; }
    }

    public class ConfigReferSum
    {
        public string Field { get; set; }
        public string Value { get; set; }
        public int TimeAllow { get; set; }
        public string ReferPerDayField { get; set; }
        public string ReferPerWeekField { get; set; }
        public string Operator { get; set; }
        public string ReferFieldListType { get; set; }
        public string CheckReferFieldIsTrue { get; set; }
    }

    public class ReferListType
    {
        public int Order { get; set; }
        public string Field01 { get; set; }
        public string Field02 { get; set; }
        public string Field03 { get; set; }
        public string Field04 { get; set; }
    }
    public class CalADLs
    {
        public string Field { get; set; }
        public string Value { get; set; }
        public string ForFieldCal { get; set; }
        public List<int> OrderCals { get; set; }
        public List<ReferOrder> ReferOrders { get; set; }
    }

    public class ConditionBind
    {
        public string Field { get; set; }
        public string Value { get; set; }
        public string Operator { get; set; }
    }
    public class ReferOrder
    {
        public int Order { get; set; }
        public string Field { get; set; }
        public string Value { get; set; }
        public string Operator { get; set; }
        public string OperatorValue { get; set; }
    }

    public class CalToileting
    {
        public string Field { get; set; }
        public string Value { get; set; }
        public string PerDayField { get; set; }
        public int Minutes { get; set; }
        public string PerWeekField { get; set; }
        public int? NumberDayPerWeek { get; set; }
    }
    public class CalculatorVo
    {
        public ConfigItem ConfigTime { get; set; }
        public ConfigItem ConfigDay { get; set; }
        public ConfigItem ConfigDataTime { get; set; }
        public ConfigItem ConfigDataDay { get; set; }
        public ConfigItem ConfigWeek { get; set; }
        public CalADLs CalADLs { get; set; }
        public string Formula { get; set; }

        public string GetFormula(int valConfigTime, int valConfigDay, int valConfigWeek, int valConfigDataTime, int valConfigDataDay, AssQuestionVo refer, List<AssQuestionVo> listRefer = null)
        {
            var result = Formula;
            var configTime = 0;
            var configTime2 = 0;

            #region calculator ConfigTime
            if (ConfigTime != null && ConfigTime.ValInOuts != null && ConfigTime.ValInOuts.Count > 0)
            {
                var valInOut = ConfigTime.ValInOuts.FirstOrDefault(o => o.ValIn == valConfigTime);
                if (valInOut != null)
                {
                    if (valInOut.ValOut != null)
                    {
                        result = result.Replace("ConfigTime", valInOut.ValOut.ToString());
                        configTime = valInOut.ValOut.GetValueOrDefault();
                    }
                    else if (valInOut.ValOuts != null && valInOut.ValOuts.Count > 0 && ConfigRefers != null &&
                             ConfigRefers.Count > 0)
                    {
                        var res = "";
                        foreach (var configRefer in ConfigRefers.OrderByDescending(o => o.Order))
                        {
                            var obj = GetPropValue(refer, configRefer.Field);
                            if (obj != null && obj.ToString().ToLower().Equals(configRefer.Value))
                            {
                                if (string.IsNullOrEmpty(configRefer.ReferValue))
                                {
                                    var objRes = GetPropValue(refer, configRefer.ReferField);
                                    var orderObj =
                                        valInOut.ValOuts.FirstOrDefault(o => o.ValIn == configRefer.Order);
                                    if (objRes != null && orderObj != null)
                                    {
                                        if (!string.IsNullOrEmpty(res))
                                        {
                                            res += configRefer.Operator;
                                        }

                                        res += "(" + objRes + "*" + orderObj.ValOut + ")";
                                    }
                                }
                                else
                                {
                                    res = "";
                                    break;
                                }
                            }
                        }
                        if (string.IsNullOrEmpty(res))
                        {
                            result = result.Replace("ConfigTime", "0");
                        }
                        else
                        {
                            result = result.Replace("ConfigTime", "(" + res + ")");
                        }
                    }
                    else
                    {
                        result = result.Replace("ConfigTime", "0");
                    }

                }
                else
                {
                    result = result.Replace("ConfigTime", "0");
                }
            }
            #endregion
            #region calculator ConfigDay
            if (ConfigDay != null && ConfigDay.ValInOuts != null && ConfigDay.ValInOuts.Count > 0)
            {
                var valOfAnyReferField = ConfigDay.ValInOuts.FirstOrDefault(o => o.ValIn == 0);
                if (valOfAnyReferField != null && !string.IsNullOrEmpty(valOfAnyReferField.ReferTo))
                {
                    var objRes = GetPropValue(refer, valOfAnyReferField.ReferTo);
                    if (objRes != null)
                    {
                        result = result.Replace("ConfigDay", objRes.ToString());
                    }
                    else
                    {
                        result = result.Replace("ConfigDay", "0");
                    }

                }
                else
                {
                    var valInOut = ConfigDay.ValInOuts.FirstOrDefault(o => o.ValIn == valConfigDay);
                    if (valInOut != null)
                    {
                        if (valInOut.ValOut != null)
                        {
                            result = result.Replace("ConfigDay", valInOut.ValOut.ToString());
                        }
                        else if (!string.IsNullOrEmpty(valInOut.ReferTo))
                        {
                            var objRes = GetPropValue(refer, valInOut.ReferTo);
                            if (objRes != null)
                            {
                                if (valInOut.MaxValue != null)
                                {
                                    var configDay = int.Parse(objRes.ToString());
                                    if (configTime * configDay > valInOut.MaxValue)
                                    {
                                        result = result.Replace(" ", "");
                                        result = result.Replace(configTime + "*ConfigDay", valInOut.MaxValue.ToString());
                                    }
                                    else
                                    {
                                        //result = result.Replace("ConfigDay", "0");
                                        result = result.Replace("ConfigDay", objRes.ToString());
                                    }
                                }
                                else
                                {
                                    if (valInOut.ValOuts != null && valInOut.ValOuts.Count > 0)
                                    {
                                        var valInOnList =
                                            valInOut.ValOuts.FirstOrDefault(o => o.ValIn == int.Parse(objRes.ToString()));
                                        result = result.Replace("ConfigDay",
                                            valInOnList != null ? valInOnList.ValOut.ToString() : "0");
                                    }
                                    else
                                    {
                                        result = result.Replace("ConfigDay", objRes.ToString());
                                    }

                                }
                            }
                            else
                            {
                                result = result.Replace("ConfigDay", "0");
                            }
                        }
                    }
                    else
                    {
                        result = result.Replace("ConfigDay", "0");
                    }
                }

            }
            #endregion
            #region calculator ConfigWeek
            if (ConfigWeek != null && ConfigWeek.ValInOuts != null && ConfigWeek.ValInOuts.Count > 0)
            {
                var valOfAnyReferField = ConfigWeek.ValInOuts.FirstOrDefault(o => o.ValIn == 0);
                if (valOfAnyReferField != null && !string.IsNullOrEmpty(valOfAnyReferField.ReferTo))
                {
                    var objRes = GetPropValue(refer, valOfAnyReferField.ReferTo);
                    result = result.Replace("ConfigWeek", objRes.ToString());
                }
                else
                {

                    var valInOut = ConfigWeek.ValInOuts.FirstOrDefault(o => o.ValIn == valConfigWeek);
                    if (valInOut != null)
                    {
                        if (valInOut.ValOut != null)
                        {
                            result = result.Replace("ConfigWeek", valInOut.ValOut.ToString());
                        }
                        else if (!string.IsNullOrEmpty(valInOut.ReferTo))
                        {
                            var objRes = GetPropValue(refer, valInOut.ReferTo);
                            if (objRes != null)
                            {
                                if (valInOut.ValOuts != null && valInOut.ValOuts.Count > 0)
                                {
                                    var valInOnList =
                                        valInOut.ValOuts.FirstOrDefault(o => o.ValIn == int.Parse(objRes.ToString()));
                                    result = result.Replace("ConfigWeek",
                                        valInOnList != null ? valInOnList.ValOut.ToString() : "0");
                                }
                                else
                                {
                                    result = result.Replace("ConfigWeek", objRes.ToString());
                                }
                            }
                            else
                            {
                                result = result.Replace("ConfigWeek", "0");
                            }
                        }


                    }
                    else
                    {
                        result = result.Replace("ConfigWeek", "0");
                    }
                }

            }
            #endregion

            #region calculator ConfigTime2
            if (ConfigDataTime != null && ConfigDataTime.ValInOuts != null && ConfigDataTime.ValInOuts.Count > 0)
            {
                var valInOut = ConfigDataTime.ValInOuts.FirstOrDefault(o => o.ValIn == valConfigDataTime);
                if (valInOut != null)
                {
                    if (valInOut.ValOut != null)
                    {
                        result = result.Replace("ConfigDataTime", valInOut.ValOut.ToString());
                    }
                    else
                    {
                        result = result.Replace("ConfigDataTime", "0");
                    }

                }
                else
                {
                    result = result.Replace("ConfigDataTime", "0");
                }
            }
            #endregion
            #region calculator ConfigDay2
            if (ConfigDataDay != null && ConfigDataDay.ValInOuts != null && ConfigDataDay.ValInOuts.Count > 0)
            {
                var valInOut = ConfigDay.ValInOuts.FirstOrDefault(o => o.ValIn == valConfigDataDay);
                if (valInOut != null)
                {
                    result = result.Replace("ConfigDataDay", valInOut.ValOut.ToString());
                }
                else
                {
                    result = result.Replace("ConfigDataDay", "0");
                }
            }
            #endregion
            #region calculator ConfigReferSums
            if (ConfigReferSums != null && ConfigReferSums.Count > 0)
            {
                var res = string.Empty;
                var total = ConfigReferSums.Count;
                for (int i = 0; i < total; i++)
                {
                    var isCalculated = true;
                    if (ConfigReferSums[i].CheckReferFieldIsTrue != null)
                    {
                        var fieldCheck = GetPropValue(refer, ConfigReferSums[i].CheckReferFieldIsTrue) as string;
                        if (fieldCheck == null)
                        {
                            isCalculated = false;
                        }
                        else
                        {
                            bool valueOut;
                            if (!string.IsNullOrEmpty(fieldCheck) && bool.TryParse(fieldCheck, out valueOut))
                            {
                                if (!valueOut)
                                {
                                    isCalculated = false;
                                }
                            }
                        }
                    }

                    var obj = GetPropValue(refer, ConfigReferSums[i].Field);
                    if (obj != null && obj.ToString().ToLower().Equals(ConfigReferSums[i].Value) && isCalculated)
                    {
                        if (!string.IsNullOrEmpty(ConfigReferSums[i].ReferPerDayField) && !string.IsNullOrEmpty(ConfigReferSums[i].ReferPerWeekField))
                        {
                            var referPerDayFieldObj = GetPropValue(refer, ConfigReferSums[i].ReferPerDayField);
                            var referPerWeekFieldObj = GetPropValue(refer, ConfigReferSums[i].ReferPerWeekField);
                            if (referPerDayFieldObj != null && referPerWeekFieldObj != null)
                            {
                                if (string.IsNullOrEmpty(res))
                                {
                                    res += "(" + ConfigReferSums[i].TimeAllow + "*" + referPerDayFieldObj + "*" +
                                           referPerWeekFieldObj + ") ";
                                }
                                else
                                {
                                    res += ConfigReferSums[i].Operator + "(" + ConfigReferSums[i].TimeAllow + "*" +
                                           referPerDayFieldObj + "*" + referPerWeekFieldObj + ") ";
                                }
                            }
                        }
                        else
                        {
                            if (!string.IsNullOrEmpty(ConfigReferSums[i].ReferFieldListType))
                            {
                                var jsonList = GetPropValue(refer, ConfigReferSums[i].ReferFieldListType);
                                var list = JsonConvert.DeserializeObject<List<ReferListType>>(jsonList.ToString());
                                var sum = 0;
                                foreach (var item in list)
                                {
                                    var valField02 = CaculatorHelper.TryParseIntFromStr(item.Field02);
                                    var valField03 = CaculatorHelper.TryParseIntFromStr(item.Field03);

                                    sum = sum + ConfigReferSums[i].TimeAllow * valField02 * valField03;
                                }
                                if (!string.IsNullOrEmpty(res))
                                {
                                    res += ConfigReferSums[i].Operator + sum;
                                }
                                else
                                {
                                    res += sum;
                                }

                            }
                        }
                    }
                }
                result = result.Replace("ConfigReferSums", string.IsNullOrEmpty(res) ? "0" : res);
            }
            #endregion
            #region calculator CalADLs
            if (CalADLs != null && listRefer != null)
            {
                var res = string.Empty;
                var obj = GetPropValue(refer, CalADLs.Field);
                if (obj != null && obj.ToString().ToLower().Equals(CalADLs.Value) && !string.IsNullOrEmpty(CalADLs.ForFieldCal) && CalADLs.OrderCals != null && CalADLs.OrderCals.Count > 0)
                {
                    foreach (var orderCal in CalADLs.OrderCals)
                    {
                        var calOrderObj = listRefer.FirstOrDefault(o => o.Order == orderCal);
                        if (calOrderObj != null)
                        {
                            var objCal = GetPropValue(calOrderObj, CalADLs.ForFieldCal);
                            if (string.IsNullOrEmpty(res))
                            {
                                res += objCal;
                            }
                            else
                            {
                                res += "+" + objCal;
                            }
                        }
                    }
                    if (CalADLs.ReferOrders != null && CalADLs.ReferOrders.Count > 0)
                    {
                        var flagNotDefault = false;
                        foreach (var source in CalADLs.ReferOrders.Where(o => o.Order != 0))
                        {
                            //With case 1.
                            var objRefer = listRefer.FirstOrDefault(o => o.Order == source.Order);
                            if (objRefer != null)
                            {
                                var objValue = GetPropValue(objRefer, source.Field);
                                if (objValue != null && objValue.ToString().ToLower().Equals(source.Value))
                                {
                                    result = result.Replace("CalADLs", "(" + res + ")" + source.Operator + source.OperatorValue);
                                    flagNotDefault = true;
                                }
                            }
                        }
                        if (!flagNotDefault)
                        {
                            var objSource = CalADLs.ReferOrders.FirstOrDefault(o => o.Order == 0);
                            if (objSource != null)
                            {
                                result = result.Replace("CalADLs", "(" + res + ")" + objSource.Operator + objSource.OperatorValue);
                            }
                        }
                    }
                    else
                    {
                        result = result.Replace("CalADLs", "0");
                    }
                }
                else
                {
                    result = result.Replace("CalADLs", "0");
                }
            }
            #endregion
            #region calculator ConditionBinds

            if (ConditionBinds != null && ConditionBinds.Count > 0)
            {
                bool res = true;
                foreach (var conditionBind in ConditionBinds)
                {
                    var objCondition = GetPropValue(refer, conditionBind.Field);
                    switch (conditionBind.Operator)
                    {
                        case "=":
                            res &= objCondition != null && String.Compare(objCondition.ToString().ToLower(), conditionBind.Value, StringComparison.Ordinal) == 0;
                            break;
                        case ">":
                            res &= objCondition != null && String.Compare(objCondition.ToString().ToLower(), conditionBind.Value, StringComparison.Ordinal) > 0;
                            break;
                        case "<":
                            res &= objCondition != null && String.Compare(objCondition.ToString().ToLower(), conditionBind.Value, StringComparison.Ordinal) < 0;
                            break;
                    }

                }
                result = result.Replace("ConditionBinds", res ? "1" : "0");
            }

            #endregion

            #region calculator CalHourToileting
            if (CalToiletings != null && CalToiletings.Count > 0)
            {
                //Get max Day per week
                var maxPerWeek = 0;
                if (CalToiletingFieldGetMaxPerWeek != null && CalToiletingFieldGetMaxPerWeek.Any())
                {
                    foreach (var field in CalToiletingFieldGetMaxPerWeek)
                    {
                        var valueOfField = GetPropValue(refer, field);
                        if (valueOfField != null && !string.IsNullOrEmpty(valueOfField.ToString()))
                        {
                            if (valueOfField.ToString().ToLower().Equals("true"))
                            {
                                //Get day per with of Field was selected
                                foreach (var dayPerWeekField in CalToiletings)
                                {
                                    if (dayPerWeekField.Field == field)
                                    {
                                        var valueOfDayPerWeekField = GetPropValue(refer, dayPerWeekField.PerWeekField);
                                        if (valueOfDayPerWeekField != null && !string.IsNullOrEmpty(valueOfDayPerWeekField.ToString()))
                                        {
                                            int flagIntDayPerWeek;

                                            if (valueOfDayPerWeekField != null && int.TryParse(valueOfDayPerWeekField.ToString(), out flagIntDayPerWeek))
                                            {
                                                if (flagIntDayPerWeek > 0)
                                                {
                                                    dayPerWeekField.NumberDayPerWeek = flagIntDayPerWeek;
                                                }
                                                if (flagIntDayPerWeek > maxPerWeek)
                                                {
                                                    maxPerWeek = flagIntDayPerWeek;
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }

                //Get Max minutes config
                var maxMinutes = CalToiletingMaxMinutes;

                //Loop to calculate for each day
                var sumPerDay = 0;

                if (maxPerWeek > 0)
                {
                    for (int i = 1; i <= maxPerWeek; i++)
                    {
                        var total = 0;
                        foreach (var itemCal in CalToiletings)
                        {
                            if (itemCal.NumberDayPerWeek >= i)
                            {
                                var valueOfPerDay = GetPropValue(refer, itemCal.PerDayField);
                                int flagIntPerDay;
                                if (valueOfPerDay != null && int.TryParse(valueOfPerDay.ToString(), out flagIntPerDay))
                                {
                                    total = total + itemCal.Minutes * flagIntPerDay;
                                }

                            }
                        }
                        sumPerDay = sumPerDay + (total <= maxMinutes ? total : maxMinutes);
                    }
                }

                result = result.Replace("CalToiletings", sumPerDay.ToString());
            }
            #endregion
            return result;
        }
        public string BindField { get; set; }
        public string Operator { get; set; }
        public List<ConfigRefer> ConfigRefers { get; set; }
        public List<ConfigReferSum> ConfigReferSums { get; set; }
        public List<ConditionBind> ConditionBinds { get; set; }
        public List<CalToileting> CalToiletings { get; set; }
        public int CalToiletingMaxMinutes { get; set; }
        public string[] CalToiletingFieldGetMaxPerWeek { get; set; }
        private static object GetPropValue(object src, string propName)
        {
            return src.GetType().GetProperty(propName).GetValue(src, null);
        }
    }
    public class SectionTempleteVo
    {
        public string Name { get; set; }
        public SectionDataType DataType { get; set; }
        public bool? IsValidation { get; set; }
        public int? MaxValue { get; set; }
        public string ReferRequiredField { get; set; }
        public string[] ReferRequiredValueField { get; set; }
        public string GroupRequired { get; set; }
        public string[] ReferRequiredFields { get; set; }
        public string ReferItemRequired { get; set; }
        public string ReferItemRequiredField { get; set; }
        public string ReferItemRequiredValue { get; set; }

        public string[] GroupFieldToRequired { get; set; }

        //MOT List Other Miscellaneous
        public int? MaxValuePerDay { get; set; }
        public int? MaxValuePerWeek { get; set; }
        public bool? CheckTypeListOtherMiscellaneous { get; set; }

        //Group field required DataType = bool
        public string[] GroupRequiredALeastField { get; set; }
        public string GroupRequiredALeastFieldRefer { get; set; }

        //Staffing Schedule of Each Agency or Provider Providing Services
        public bool? CheckListStaffingScheduleServices { get; set; }

        //Schedule of any informal supports 
        public bool? CheckListInformalSupports { get; set; }

        //List of medications 
        public bool? CheckTypeListDiagnosesConditions { get; set; }

        //Check Eating
        public string RefFieldToCheck { get; set; }
        public string[] ListValRefFieldToCheck { get; set; }
        public string[] ListSameField { get; set; }

        //message error
        public string MessageError { get; set; }
        public string MessageErrorMaxValue { get; set; }

        public string MessageErrorMaxValueMiscellaneousPerDay { get; set; }
        public string MessageErrorMaxValueMiscellaneousPerWeek { get; set; }
        public string MessageErrorMiscellaneousName { get; set; }
        public string MessageErrorMiscellaneousPerDay { get; set; }
        public string MessageErrorMiscellaneousPerWeek { get; set; }


        //Group field required DataType = string
        public string[] GroupRequiredFieldString { get; set; }

        //Group field required DataType = bool = true
        public string[] GroupRequiredFieldBool { get; set; }

        //Check Field is null if = value
        public int? IsNullIfValue { get; set; }

        //Check Demonstrated Ability to required option
        public string AbilityField { get; set; }
        public string[] AbilityFieldToRequred { get; set; }
        public string[] AbilityGroupRequiredFieldBool { get; set; }
    }

    public class DiagnosesPcst
    {
        public int Order { get; set; }
        public string Field01 { get; set; }
        public string Field02 { get; set; }
        public string Field03 { get; set; }
        public string Field04 { get; set; }
    }

    public class MessageErrorVo
    {
        public int? Index { get; set; }
        public int Order { get; set; }
        public string Id { get; set; }
        public string MessageError { get; set; }
    }

    public class SectionQuestion :Entity
    {
        public string Name { get; set; }
        public string Content { get; set; }
        public string Parameters { get; set; }
        public string Calculator { get; set; }

        //[NotMapped]
        //public IList<SectionTempleteVo> SectionTempleteVos
        //{
        //    get { return JsonConvert.DeserializeObject<List<SectionTempleteVo>>(Parameters); }
        //}

        //[NotMapped]
        //public List<CalculatorVo> CalculatorVo
        //{
        //    get
        //    {
        //        return string.IsNullOrEmpty(Calculator) ? null : JsonConvert.DeserializeObject<List<CalculatorVo>>(Calculator);
        //    }
        //}

        public int Order { get; set; }
        public int SectionId { get; set; }
        public int PcstVersion { get; set; }
        public bool? IsSignature { get; set; }
        public bool? IsSignatureDate { get; set; }
        public bool? IsBathing { get; set; }
        public bool? IsADLsCal { get; set; }
        public bool? IsMOT { get; set; }
        public bool? IsMedicalAppointments { get; set; }
        public bool? IsServicesIncidental { get; set; }
        public bool? IsBehaviorsMedicalConditionsSeizures { get; set; }
        public bool? IsDiagnoses { get; set; }
        public bool? IsMedications { get; set; }
        public bool? IsDME { get; set; }
        public bool? IsAllergies { get; set; }
        public bool? IsFunctionalLimitation { get; set; }
        public bool? IsActivitiesPermitted { get; set; }
        public bool? IsMentalStatus { get; set; }
        public bool? IsReassessmentDue { get; set; }
        public bool? IsCheckZeroMinutesPCST { get; set; }
        public bool? IsMid { get; set; }
        public string FieldCheckDME { get; set; }
        public virtual Section Section { get; set; }
    }
}
