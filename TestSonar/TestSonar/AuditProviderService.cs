using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace TestSonar
{
    public enum AuditReferType
    {
        Scheduler = 1,
        Assessor = 2,
        RegionalManager = 3,
        RequestProcessor = 4,
        ReferralRelationshipType = 5,
        MemberSettingType = 7,
        RegionId = 8,
        SubRegionId = 9,
        PhysicianPosition = 10,
        ChangeOfStatusRequestorType = 11,
        ChangeOfStatusReasonType = 12,
        ChangeOfProviderRequestedType = 13,
        ChangeOfProviderReasonType = 14,
        ChangeOfProviderStatusOfProviderType = 15,
        Icd = 16,
        PrescriptionOrOtc = 17,
        AttachmentType = 18,
        DiaryEntryTypeId = 19,
        DiaryOutcomeId = 20,
        DiarySpokeWithId = 21,
        MemberOfDairyLog = 22,
        Assignee = 23,
        RequestTaskStatus = 24,
        Request = 25,
        PrimaryLanguage = 26,
        Gender = 27,
        RequestTaskId = 28,
        Milestone = 29,
        MilestoneStatus = 30,
        Task = 31,
        ProviderAgency = 32,
        LivingSituation = 33,
        Attention = 34,
        MemberRelationshipEnum = 35,
        MemberEmergencyContactRelationship = 36,
        EnrollmentService = 37,
        RequestedService = 38,
    }
    public class ReferAuditVo
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public AuditReferType Type { get; set; }
        public string PropertyName { get; set; }
        public int Option { get; set; }
        public Guid Guid { get; set; }
    }
    public
        class RequestAudit
    {
        public int KeyId { get; set; }
        public string OldValues { get; set; }
        public string NewValues { get; set; }
        public string Info { get; set; }
        public int ObjectState { get; set; }
        public string TransactionIdentifier { get; set; }
    }

    public class AuditConfigurationLable 
    {
        public int TableId { get; set; }
        public string PropertyName { get; set; }
        public string Lable { get; set; }
        public AuditDataType AuditDataType { get; set; }
        public AuditReferType? AuditReferType { get; set; }
        public string GroupName { get; set; }
        public bool? IsConvertUtc { get; set; }
    }

    public enum AuditDataType
    {
        String = 1,
        Number = 2,
        Boolean = 3,
        Date = 4,
        Refer = 5,
        Phone = 6,
        Image = 7
    }
    class AuditProviderService
    {
        private void SetDynObj(KeyValuePair<string, object> item, AuditConfigurationLable objLableConfig, ref IDictionary<string, object> valDic, Guid? guid = null)
        {
            var str = item.Value;
            if (objLableConfig.AuditDataType == AuditDataType.Phone && str != null && !string.IsNullOrEmpty(str.ToString()))
            {
                str = item.Value.ToString();
            }
            if (guid == null)
            {
                valDic.Remove(objLableConfig.PropertyName);
                valDic.Add(new KeyValuePair<string, object>(objLableConfig.PropertyName, new { Label = objLableConfig.Lable, Group = objLableConfig.GroupName, DataType = objLableConfig.AuditDataType, Value = str, IsConvertUtc = objLableConfig.IsConvertUtc.GetValueOrDefault() }));
            }
            else
            {
                valDic.Remove(objLableConfig.PropertyName);
                valDic.Add(new KeyValuePair<string, object>(objLableConfig.PropertyName, new { Label = objLableConfig.Lable, Group = objLableConfig.GroupName, DataType = objLableConfig.AuditDataType, Value = str, Guid = guid, IsConvertUtc = objLableConfig.IsConvertUtc.GetValueOrDefault() }));
            }
        }

        private void SetPropertyForSingle(ref IDictionary<string, object> newValDic, List<AuditConfigurationLable> listLableConfig, KeyValuePair<string, object> item, List<ReferAuditVo> listRefer)
        {
            var objLableConfig = listLableConfig.FirstOrDefault(o => o.PropertyName == item.Key);

            if (objLableConfig != null)
            {
                Guid? guid = null;
                if (objLableConfig.AuditDataType == AuditDataType.Refer)
                {
                    guid = Guid.NewGuid();
                    if (item.Value != null && !string.IsNullOrEmpty(item.Value.ToString()))
                    {
                        var referObj = new ReferAuditVo();
                        int idRefer;
                        if (int.TryParse(item.Value.ToString(), out idRefer))
                        {
                            referObj.Id = idRefer;
                            if (objLableConfig.AuditReferType != null)
                            {
                                referObj.Type = (AuditReferType)objLableConfig.AuditReferType;
                                referObj.Option = 1;
                                referObj.PropertyName = objLableConfig.PropertyName;
                                referObj.Guid = (Guid)guid;
                                listRefer.Add(referObj);
                            }
                        }
                    }
                }
                SetDynObj(item, objLableConfig, ref newValDic, guid);
            }
            else
            {
                if (!item.Key.Equals("ObjectState") && !item.Key.Equals("KeyId"))
                {
                    newValDic.Remove(item.Key);
                }

            }
        }

        private void SetPropertyForArrayObject(ref IDictionary<string, object> newValDic, List<AuditConfigurationLable> listLableConfig, KeyValuePair<string, object> item, List<ReferAuditVo> listRefer)
        {
            var serializeStr = JsonConvert.SerializeObject(item.Value);
            var arrayDic = JsonConvert.DeserializeObject<List<IDictionary<string, object>>>(serializeStr);
            arrayDic.ForEach(valDic =>
            {
                var listDic = valDic.ToList();
                foreach (var o in listDic)
                {
                    SetPropertyForSingle(ref valDic, listLableConfig, o, listRefer);
                }
            });

            var resultStr = JsonConvert.SerializeObject(arrayDic);
            var result = JsonConvert.DeserializeObject<dynamic>(resultStr);
            newValDic.Remove(item.Key);
            newValDic.Add(new KeyValuePair<string, object>(item.Key, result));
        }

        public RequestAudit GetById(int id)
        {
            return new RequestAudit();
        }
        private void SetPropertyForObject(ref IDictionary<string, object> newValDic, List<AuditConfigurationLable> listLableConfig, KeyValuePair<string, object> item, List<ReferAuditVo> listRefer)
        {
            var serializeStr = JsonConvert.SerializeObject(item.Value);
            var valDic = JsonConvert.DeserializeObject<IDictionary<string, object>>(serializeStr);
            var listDic = valDic.ToList();
            foreach (var o in listDic)
            {
                SetPropertyForSingle(ref valDic, listLableConfig, o, listRefer);
            }
            var resultStr = JsonConvert.SerializeObject(valDic);
            var result = JsonConvert.DeserializeObject<dynamic>(resultStr);
            newValDic.Remove(item.Key);
            newValDic.Add(new KeyValuePair<string, object>(item.Key, result));
        }
        public List<ReferAuditVo> GetInfoAudit(string param)
        {
            List<ReferAuditVo> ravs = JsonConvert.DeserializeObject<List<ReferAuditVo>>(param);
            foreach (var item in ravs)
            {
                switch (item.Type)
                {
                    case AuditReferType.Scheduler:
                    case AuditReferType.Assessor:
                    case AuditReferType.RegionalManager:
                    case AuditReferType.RequestProcessor:
                    case AuditReferType.Assignee:
                        item.Name = "";
                        break;
                    case AuditReferType.ReferralRelationshipType:
                        item.Name = "";
                        break;
                    //case AuditReferType.MemberSettingType:
                    //    item.Name = GetMemberSettingTypeDescription(item.Id);
                    //    break;
                    case AuditReferType.RegionId:
                        item.Name = "";
                        break;
                    case AuditReferType.SubRegionId:
                        item.Name = "";
                        break;
                    case AuditReferType.PhysicianPosition:
                        item.Name = "";
                        break;
                    case AuditReferType.ChangeOfStatusRequestorType:
                           item.Name = "";
                        break;
                    case AuditReferType.ChangeOfStatusReasonType:
                        item.Name = "";
                        break;
                    case AuditReferType.ChangeOfProviderRequestedType:
                        item.Name = "";
                        break;
                    case AuditReferType.ChangeOfProviderReasonType:
                        item.Name = "";
                        break;
                    case AuditReferType.ChangeOfProviderStatusOfProviderType:
                        item.Name = "";
                        break;
                    //case AuditReferType.Icd:
                    //    item.Name = _requestRepository.GetIcdDescription(item.Id);
                    //    break;
                    case AuditReferType.PrescriptionOrOtc:
                        item.Name = "";
                        break;
                    case AuditReferType.AttachmentType:
                        item.Name = "";
                        break;
                    case AuditReferType.DiaryEntryTypeId:
                        item.Name = "";
                        break;
                    case AuditReferType.DiaryOutcomeId:
                        item.Name = "";
                        break;
                    case AuditReferType.DiarySpokeWithId:
                        item.Name = "";
                        break;
                    case AuditReferType.MemberOfDairyLog:
                        item.Name = "";
                        break;
                    case AuditReferType.RequestTaskStatus:
                        item.Name = "";
                        break;
                    case AuditReferType.Request:
                        item.Name = "";
                        break;
                    case AuditReferType.PrimaryLanguage:
                        item.Name = "";
                        break;
                    case AuditReferType.Gender:
                        item.Name = "";
                        break;
                    case AuditReferType.RequestTaskId:
                        item.Name = "";
                        break;
                    case AuditReferType.Milestone:
                        item.Name = "";
                        break;
                    case AuditReferType.MilestoneStatus:
                        item.Name = "";
                        break;
                    case AuditReferType.Task:
                        item.Name = "";
                        break;
                    //case AuditReferType.ProviderAgency:
                    //    item.Name = _requestRepository.GetProviderAgencyName(item.Id);
                    //    break;
                    default:
                        item.Name = "";
                        break;
                }
            }

            return ravs;
        }
        private void BindingObjectWithConfig(ref IDictionary<string, object> newValDic, int tableId)
        {
            var listLableConfig = new List<AuditConfigurationLable>();
            var listRefer = new List<ReferAuditVo>();
            var listDic = newValDic.ToList();
            foreach (var item in listDic)
            {
                if (item.Value.GetType().Name.Equals("JArray"))
                {
                    SetPropertyForArrayObject(ref newValDic, listLableConfig, item, listRefer);
                }
                else if (item.Value.GetType().Name.Equals("JObject"))
                {
                    SetPropertyForObject(ref newValDic, listLableConfig, item, listRefer);
                }
                else
                {
                    SetPropertyForSingle(ref newValDic, listLableConfig, item, listRefer);
                }
            }
            if (listRefer.Count > 0)
            {
                listRefer = GetInfoAudit(listRefer);
                HandleListRefer(listRefer, ref newValDic, tableId);
            }
        }
        private void SetCreateObject(ref IDictionary<string, object> newValDic, string value, int tableId)
        {
            var newObjDyn = JsonConvert.DeserializeObject<IDictionary<string, object>>(value);
            newValDic = newObjDyn;
            BindingObjectWithConfig(ref newValDic, tableId);
        }

        public dynamic GetRequestAuditBydId(int requestAuditId)
        {
            dynamic oldVal = new ExpandoObject();
            dynamic newVal = new ExpandoObject();
            var oldValDic = oldVal as IDictionary<string, object>;
            var newValDic = newVal as IDictionary<string, object>;
            //_requestAuditRepository.SetAuditConfigurationLable();
            var obj = GetById(requestAuditId);
            if (obj != null)
            {
                if (obj.ObjectState == 1)
                {
                    SetCreateObject(ref newValDic, obj.NewValues, 1);
                    oldValDic = null;
                }
                else if (obj.ObjectState == 2)
                {
                    SetModifyObject(ref oldValDic, ref newValDic, obj.NewValues, obj.OldValues, 1);
                }
                dynamic val = HandleMergeRequest(oldValDic, newValDic);
                return new { Value = val, obj.ObjectState };
            }
            return null;
        }
        public dynamic GetRequestAuditDetailByTransactionIdentifier(string transactionIdentifier, int? requestId)
        {
            if (!string.IsNullOrEmpty(transactionIdentifier))
            {
                dynamic oldVal = new ExpandoObject();
                dynamic newVal = new ExpandoObject();
                var oldValDic = oldVal as IDictionary<string, object>;
                var newValDic = newVal as IDictionary<string, object>;
                //_requestAuditRepository.SetAuditConfigurationLable();

                var list = Get(o => o.TransactionIdentifier == transactionIdentifier && o.KeyId == requestId);
                if (list.Any())
                {
                    var result = new List<object>();
                    foreach (var obj in list)
                    {
                        if (obj != null)
                        {
                            if (obj.ObjectState == 1)
                            {
                                SetCreateObject(ref newValDic, obj.NewValues, 1);
                                oldValDic = null;
                            }
                            else if (obj.ObjectState == 2)
                            {
                                SetModifyObject(ref oldValDic, ref newValDic, obj.NewValues, obj.OldValues, 1);
                            }
                            dynamic val = HandleMergeRequest(oldValDic, newValDic);
                            result.Add(new { Value = val, obj.ObjectState });
                        }
                    }
                    return result;
                }
            }
            return null;
        }
        #region Handle Merge Request
        private dynamic HandleMergeRequest(IDictionary<string, object> oldValDic, IDictionary<string, object> newValDic)
        {
            var resultExpandoObject = new ExpandoObject();
            var result = resultExpandoObject as IDictionary<string, object>;
            foreach (var newVal in newValDic)
            {
                HandleMergeRequest(oldValDic, newVal, ref result);
            }
            HandleMergeRequestForDelete(oldValDic, ref result);
            return GetDynFromObject(result);
        }
        private void HandleMergeRequestForDelete(IDictionary<string, object> oldValDic, ref IDictionary<string, object> result)
        {
            if (oldValDic != null)
            {
                foreach (var itemOld in oldValDic)
                {
                    if (itemOld.Value.GetType().Name.Equals("JArray"))
                    {
                        var listDic = GetDicFromList(itemOld.Value);
                        var cloneListDic = listDic.ToList();
                        object outDic = null;
                        foreach (var item in cloneListDic)
                        {
                            var listDicResult = GetDicFromObject(item);
                            if (listDicResult.TryGetValue("ObjectState", out outDic) && outDic.ToString().Equals("3"))
                            {
                                var cloneListDicResult = listDicResult.ToList();
                                var flagProcess = false;
                                foreach (var itemClone in cloneListDicResult)
                                {
                                    object objPropResult;
                                    if (listDicResult.TryGetValue(itemClone.Key, out objPropResult))
                                    {
                                        if (objPropResult.GetType().Name.Equals("JObject"))
                                        {
                                            listDic.Remove(item);
                                            var objPropResultObject = GetDicFromObject(objPropResult);
                                            objPropResultObject.Add("OldValue", objPropResultObject["Value"]);

                                            objPropResultObject.Remove("Value");
                                            objPropResultObject.Add("Value", "");
                                            if (itemClone.Key.Equals("AssigneeId"))
                                            {
                                                if (objPropResultObject["Value"] == null || string.IsNullOrEmpty(objPropResultObject["Value"].ToString()))
                                                {
                                                    objPropResultObject["Value"] = "Unassigned";
                                                }
                                                if (objPropResultObject["OldValue"] == null || string.IsNullOrEmpty(objPropResultObject["OldValue"].ToString()))
                                                {
                                                    objPropResultObject["OldValue"] = "Unassigned";
                                                }
                                            }
                                            listDicResult.Remove(itemClone.Key);
                                            listDicResult.Add(itemClone.Key, GetDynFromObject(objPropResultObject));

                                            flagProcess = true;
                                        }
                                    }
                                }
                                if (flagProcess)
                                {
                                    //Tram modified
                                    //Nghiep review please
                                    listDic.Remove(item);
                                    listDic.Add(listDicResult);
                                }
                            }
                        }
                        //Tram modified
                        //Nghiep review please
                        if (result.ContainsKey(itemOld.Key))
                        {
                            if (outDic != null && outDic.ToString().Equals("3"))
                            {
                                result.Add(GetNewKey(result, itemOld.Key), listDic);
                            }
                        }
                        else
                        {
                            result.Add(itemOld.Key, listDic);
                        }

                    }
                }
            }

        }

        private string GetNewKey(IDictionary<string, object> result, string key)
        {
            if (result.ContainsKey(key))
            {
                return GetNewKey(result, key + "1");
            }
            return key;
        }

        private void HandleMergeRequest(IDictionary<string, object> oldValDic, KeyValuePair<string, object> val, ref IDictionary<string, object> result)
        {

            if (val.Value.GetType().Name.Equals("JObject"))
            {
                RequestMergeWithObject(oldValDic, val, ref result);
            }
            else if (val.Value.GetType().Name.Equals("JArray"))
            {
                RequestMergeWithArray(oldValDic, val, ref result);
            }
            else
            {
                RequestMergeWithSingal(oldValDic, val, ref result);
            }

        }

        private void RequestMergeWithSingal(IDictionary<string, object> oldValDic, KeyValuePair<string, object> val, ref IDictionary<string, object> result)
        {

            if (oldValDic != null)
            {
                object requesttemp;
                IDictionary<string, object> requestTempDic = null;
                IDictionary<string, object> requestTempDicInner = null;
                if (oldValDic.TryGetValue("requesttemp", out requesttemp))
                {
                    requestTempDic = GetDicFromObject(requesttemp);
                }
                // If val.Value equals true.
                IDictionary<string, object> dicObject;
                if (val.Value.ToString() == "True")
                {
                    dicObject = GetDicFromObject(val);
                }
                else
                {
                    dicObject = GetDicFromObject(val.Value);
                }
                //var dicObject = GetDicFromObject(val.Value);
                object oldObject, requestTempOldObject;
                if (requestTempDic != null && (requestTempDic.TryGetValue(val.Key, out requestTempOldObject) || CheckLableInnerValue(requestTempDic, dicObject, out requestTempOldObject)))
                {
                    requestTempDicInner = GetDicFromObject(requestTempOldObject);
                }
                if (oldValDic.TryGetValue(val.Key, out oldObject))
                {
                    logger.Debug("oldValDic------------------------------------------------------------");
                    logger.Debug(oldValDic.Values.FirstOrDefault());
                    //if (oldObject.ToString() == "")
                    //{
                    //    oldObject = new {a = ""};
                    //}
                    dynamic valueInOldObject = oldObject;
                    if (requestTempDicInner != null)
                    {
                        if (!requestTempDicInner["Value"].ToString().Equals(dicObject["Value"].ToString()))
                        {
                            dicObject.Add("OldValue", requestTempDicInner["Value"]);
                            if (!result.ContainsKey(val.Key))
                            {
                                result.Add(val.Key, dicObject);
                            }
                        }
                    }
                    else
                    {
                        //var a = valueInOldObject == "";
                        dicObject.Add("OldValue", valueInOldObject.Value);
                        if (!result.ContainsKey(val.Key))
                        {
                            result.Add(val.Key, dicObject);
                        }
                    }
                }
            }
            else
            {
                //if (val.Value.GetType().Name.Equals("JObject"))
                //{
                var dicObject = GetDicFromObject(val.Value);
                dicObject.Add("OldValue", "");
                if (!result.ContainsKey(val.Key))
                {
                    result.Add(val.Key, dicObject);
                }
                //}

            }

        }

        private bool CheckLableInnerValue(IDictionary<string, object> requestTempDic, IDictionary<string, object> dicObject, out object requestTempOldObject)
        {
            object lableObj, labelTempDic;
            if (requestTempDic != null && dicObject.TryGetValue("Label", out lableObj))
            {
                if (lableObj != null)
                {
                    foreach (var item in requestTempDic)
                    {
                        if (item.Value.GetType().Name.Equals("JObject"))
                        {
                            var innerObj = GetDicFromObject(item.Value);
                            if (innerObj["Label"].ToString() == "Setting Type")
                            {

                            }
                            if (innerObj.TryGetValue("Label", out labelTempDic) && labelTempDic != null && labelTempDic.ToString().Equals(lableObj.ToString()))
                            {
                                requestTempOldObject = item.Value;
                                return true;
                            }
                        }
                    }
                }
            }
            requestTempOldObject = null;
            return false;
        }



        private void RequestMergeWithArray(IDictionary<string, object> oldValDic, KeyValuePair<string, object> val, ref IDictionary<string, object> result)
        {
            object objList, objNew, objOld;
            var listDic = GetDicFromList(val.Value);
            var cloneListDic = listDic.ToList();
            if (oldValDic != null && oldValDic.TryGetValue(val.Key, out objList))
            {
                var listOldDic = GetDicFromList(objList);
                foreach (var item in cloneListDic)
                {
                    if (item.TryGetValue("KeyId", out objNew))
                    {
                        foreach (IDictionary<string, object> itemOld in listOldDic)
                        {
                            if (itemOld.TryGetValue("KeyId", out objOld) && objNew.Equals(objOld))
                            {
                                var listDicResult = GetDicFromObject(item);
                                var listOldDicResult = GetDicFromObject(itemOld);
                                var cloneListDicResult = listDicResult.ToList();
                                var flagProcess = false;
                                foreach (var itemClone in cloneListDicResult)
                                {
                                    object objProp, objPropResult;
                                    if (listOldDicResult.TryGetValue(itemClone.Key, out objProp) && listDicResult.TryGetValue(itemClone.Key, out objPropResult))
                                    {
                                        if (objProp.GetType().Name.Equals("JObject"))
                                        {
                                            flagProcess = true;
                                            var dynObjProp = objProp as dynamic;
                                            listDic.Remove(item);
                                            var objPropResultObject = GetDicFromObject(objPropResult);
                                            objPropResultObject.Add("OldValue", dynObjProp.Value);
                                            listDicResult.Remove(itemClone.Key);
                                            IDictionary<string, object> objWithRequestTask = GetDicFromObject(GetDynFromObject(objPropResultObject));
                                            listDicResult.Add(itemClone.Key, GetDynFromObject(objPropResultObject));
                                            object objWithRequestTaskTemp;
                                            if (val.Key.Equals("RequestTask"))
                                            {
                                                if (!listDicResult.TryGetValue("Name", out objWithRequestTaskTemp))
                                                {
                                                    SetPropAndValueForDic(ref objWithRequestTask, "Label", "Name");
                                                    SetPropAndValueForDic(ref objWithRequestTask, "DataType", 1);
                                                    SetPropAndValueForDic(ref objWithRequestTask, "IsConvertUtc", false);
                                                    var taskName = _requestRepository.GetTaskNameByRequestTaskId(int.Parse(objOld.ToString()));
                                                    SetPropAndValueForDic(ref objWithRequestTask, "Value", taskName);
                                                    SetPropAndValueForDic(ref objWithRequestTask, "OldValue", taskName);
                                                    listDicResult = InsertDicWithPosition(listDicResult, 0, "Name", GetDynFromObject(objWithRequestTask));
                                                }
                                                if (itemClone.Key.Equals("AssigneeId"))
                                                {
                                                    object assignee;
                                                    if (listDicResult.TryGetValue("AssigneeId", out assignee))
                                                    {
                                                        IDictionary<string, object> assigneeDictionary =
                                                            GetDicFromObject(assignee);
                                                        if (assigneeDictionary["Value"] == null || string.IsNullOrEmpty(assigneeDictionary["Value"].ToString()))
                                                        {
                                                            assigneeDictionary["Value"] = "Unassigned";
                                                        }
                                                        if (assigneeDictionary["OldValue"] == null || string.IsNullOrEmpty(assigneeDictionary["OldValue"].ToString()))
                                                        {
                                                            assigneeDictionary["OldValue"] = "Unassigned";
                                                        }
                                                        listDicResult.Remove("AssigneeId");
                                                        listDicResult.Add("AssigneeId", assigneeDictionary);
                                                    }
                                                    else
                                                    {
                                                        if (objWithRequestTask["Value"] == null || string.IsNullOrEmpty(objWithRequestTask["Value"].ToString()))
                                                        {
                                                            objWithRequestTask["Value"] = "Unassigned";
                                                        }
                                                        if (objWithRequestTask["OldValue"] == null || string.IsNullOrEmpty(objWithRequestTask["OldValue"].ToString()))
                                                        {
                                                            objWithRequestTask["OldValue"] = "Unassigned";
                                                        }
                                                        listDicResult.Remove("AssigneeId");
                                                        listDicResult.Add("AssigneeId", objWithRequestTask);
                                                    }
                                                }
                                            }
                                            if (val.Key.Equals("MemberCondition"))
                                            {
                                                if (itemClone.Key.Equals("Impact"))
                                                {
                                                    if (objWithRequestTask["Value"] == null || string.IsNullOrEmpty(objWithRequestTask["Value"].ToString()) || objWithRequestTask["Value"].ToString().ToLower().Equals("false"))
                                                    {
                                                        objWithRequestTask["Value"] = "No";
                                                    }
                                                    else
                                                    {
                                                        objWithRequestTask["Value"] = "Yes";
                                                    }
                                                    if (objWithRequestTask["OldValue"] == null || string.IsNullOrEmpty(objWithRequestTask["OldValue"].ToString()) || objWithRequestTask["OldValue"].ToString().ToLower().Equals("false"))
                                                    {
                                                        objWithRequestTask["OldValue"] = "No";
                                                    }
                                                    else
                                                    {
                                                        objWithRequestTask["OldValue"] = "Yes";
                                                    }
                                                    listDicResult.Remove("Impact");
                                                    listDicResult.Add("Impact", objWithRequestTask);
                                                }
                                            }
                                        }
                                    }
                                }
                                if (flagProcess)
                                {
                                    listDic.Add(listDicResult);
                                }
                            }
                        }
                    }
                    else
                    {
                        var listDicResult = GetDicFromObject(item);
                        var cloneListDicResult = listDicResult.ToList();
                        var flagProcess = false;
                        foreach (var itemClone in cloneListDicResult)
                        {
                            if (itemClone.Value.GetType().Name.Equals("JObject"))
                            {
                                listDicResult.Remove(itemClone);
                                IDictionary<string, object> objWithRequestTask = GetDicFromObject(itemClone.Value);
                                objWithRequestTask.Add("OldValue", "");
                                if (itemClone.Key.Equals("AssigneeId"))
                                {
                                    if (objWithRequestTask["Value"] == null || string.IsNullOrEmpty(objWithRequestTask["Value"].ToString()))
                                    {
                                        objWithRequestTask["Value"] = "Unassigned";
                                    }
                                    //if (objWithRequestTask["OldValue"] == null || string.IsNullOrEmpty(objWithRequestTask["OldValue"].ToString()))
                                    //{
                                    //    objWithRequestTask["OldValue"] = "Unassigned";
                                    //}
                                }
                                if (itemClone.Key.Equals("Impact"))
                                {
                                    if (objWithRequestTask["Value"] == null ||
                                        string.IsNullOrEmpty(objWithRequestTask["Value"].ToString()) ||
                                        objWithRequestTask["Value"].ToString().ToLower().Equals("false"))
                                    {
                                        objWithRequestTask["Value"] = "No";
                                    }
                                    else
                                    {
                                        objWithRequestTask["Value"] = "Yes";
                                    }
                                    if (objWithRequestTask["OldValue"] == null ||
                                        string.IsNullOrEmpty(objWithRequestTask["OldValue"].ToString()) ||
                                        objWithRequestTask["OldValue"].ToString().ToLower().Equals("false"))
                                    {
                                        objWithRequestTask["OldValue"] = "No";
                                    }
                                    else
                                    {
                                        objWithRequestTask["OldValue"] = "Yes";
                                    }

                                }
                                listDicResult.Add(itemClone.Key, GetDynFromObject(objWithRequestTask));
                                flagProcess = true;
                            }

                        }
                        if (flagProcess)
                        {
                            listDic.Remove(item);
                            listDic.Add(listDicResult);
                        }
                    }
                }
                result.Add(val.Key, listDic);

            }
            else
            {
                foreach (var item in cloneListDic)
                {
                    var listDicResult = GetDicFromObject(item);
                    var cloneListDicResult = listDicResult.ToList();
                    var flagProcess = false;
                    foreach (var itemClone in cloneListDicResult)
                    {
                        if (itemClone.Value != null && itemClone.Value.GetType().Name.Equals("JObject"))
                        {
                            listDicResult.Remove(itemClone);
                            IDictionary<string, object> objWithRequestTask = GetDicFromObject(itemClone.Value);
                            objWithRequestTask.Add("OldValue", "");
                            if (itemClone.Key.Equals("Impact"))
                            {
                                if (objWithRequestTask["Value"] == null ||
                                    string.IsNullOrEmpty(objWithRequestTask["Value"].ToString()) ||
                                    objWithRequestTask["Value"].ToString().ToLower().Equals("false"))
                                {
                                    objWithRequestTask["Value"] = "No";
                                }
                                else
                                {
                                    objWithRequestTask["Value"] = "Yes";
                                }
                            }
                            if (itemClone.Key.Equals("AssigneeId"))
                            {
                                if (objWithRequestTask["Value"] == null || string.IsNullOrEmpty(objWithRequestTask["Value"].ToString()))
                                {
                                    objWithRequestTask["Value"] = "Unassigned";
                                }
                                //if (objWithRequestTask["OldValue"] == null || string.IsNullOrEmpty(objWithRequestTask["OldValue"].ToString()))
                                //{
                                //    objWithRequestTask["OldValue"] = "Unassigned";
                                //}
                            }
                            if (itemClone.Key.Equals("AttachmentType"))
                            {
                                if (objWithRequestTask["Value"] == null || string.IsNullOrEmpty(objWithRequestTask["Value"].ToString()))
                                {
                                    objWithRequestTask["Value"] = "General";
                                }
                            }
                            listDicResult.Add(itemClone.Key, GetDynFromObject(objWithRequestTask));
                            flagProcess = true;
                        }
                    }

                    if (flagProcess)
                    {
                        listDic.Remove(item);
                        listDic.Add(listDicResult);
                    }
                }
                result.Add(val.Key, listDic);
            }
        }

        private IDictionary<string, object> MoveNameFirst(IDictionary<string, object> objWithRequestTask)
        {
            IDictionary<string, object> result = new Dictionary<string, object>();
            object outNameVal;
            if (objWithRequestTask.TryGetValue("", out outNameVal))
            {
                objWithRequestTask.Remove("Name");
                return InsertDicWithPosition(objWithRequestTask, 0, "Name", outNameVal);
            }
            return objWithRequestTask;

        }



        private IDictionary<string, object> InsertDicWithPosition(IDictionary<string, object> dic, int position, string key, object value)
        {
            IDictionary<string, object> result = new Dictionary<string, object>();
            var listDic = dic.ToList();
            listDic.Insert(0, new KeyValuePair<string, object>(key, value));
            foreach (var item in listDic)
            {
                result.Add(item);
            }
            return result;
        }

        private void SetPropAndValueForDic(ref IDictionary<string, object> objWithRequestTask, string prop, object val)
        {
            var cloneList = objWithRequestTask.ToList();
            var flagProcess = false;
            foreach (var item in cloneList)
            {
                if (item.Key.Equals(prop))
                {
                    flagProcess = true;
                    objWithRequestTask.Remove(prop);
                    objWithRequestTask.Add(prop, val);
                }
            }
            if (!flagProcess)
            {
                objWithRequestTask.Add(prop, val);
            }
        }

        private void RequestMergeWithObject(IDictionary<string, object> oldValDic, KeyValuePair<string, object> val, ref IDictionary<string, object> result)
        {
            object requestinfo = null;
            object requesttemp = null;
            var listDic = GetDicFromObject(val.Value);
            if (oldValDic != null)
            {
                if (oldValDic.TryGetValue("requesttemp", out requesttemp))
                {
                    var listOldDic = GetDicFromObject(requesttemp);
                    foreach (var item in listDic)
                    {
                        if (item.Value != null && item.Value.GetType().Name.Equals("JObject"))
                        {
                            var dicObject = GetDicFromObject(item.Value);
                            object oldObject;
                            // Get oldObject by Key
                            if (listOldDic.TryGetValue(item.Key, out oldObject))
                            {
                                dynamic valueInOldObject = oldObject;
                                dicObject.Add("OldValue", valueInOldObject.Value);
                            }
                            if (!EqualNullOrEmpty(dicObject["OldValue"], dicObject["Value"]))
                            {
                                result.Add(item.Key, dicObject);
                            }

                        }
                    }
                }
                else if (oldValDic.TryGetValue("requestinfo", out requestinfo))
                {
                    var listOldDic = GetDicFromObject(requestinfo);
                    foreach (var item in listDic)
                    {
                        if (item.Value != null && item.Value.GetType().Name.Equals("JObject"))
                        {
                            var dicObject = GetDicFromObject(item.Value);
                            object oldObject;
                            if (listOldDic.TryGetValue(item.Key, out oldObject))
                            {
                                dynamic valueInOldObject = oldObject;
                                dicObject.Add("OldValue", valueInOldObject.Value);
                            }
                            else if (listDic.TryGetValue(item.Key, out oldObject))
                            {
                                dynamic valueInOldObject = oldObject;
                                dicObject.Add("OldValue", valueInOldObject.Value);
                            }
                            if (!EqualNullOrEmpty(dicObject["OldValue"], dicObject["Value"]))
                            {
                                result.Add(item.Key, dicObject);
                            }

                        }
                    }
                }
                else
                {
                    var listOldDic = GetDicFromObject(val.Value);
                    foreach (var item in listDic)
                    {
                        if (item.Value != null && item.Value.GetType().Name.Equals("JObject"))
                        {
                            var dicObject = GetDicFromObject(item.Value);
                            object oldObject;
                            if (listOldDic.TryGetValue(item.Key, out oldObject))
                            {
                                dynamic valueInOldObject = oldObject;
                                dicObject.Add("OldValue", valueInOldObject.Value);
                            }
                            else
                            {
                                dicObject.Add("OldValue", "");
                            }
                            if (!EqualNullOrEmpty(dicObject["OldValue"], dicObject["Value"]))
                            {
                                result.Add(val.Key, dicObject);
                            }
                        }
                    }
                }
            }
            else
            {
                if (val.Key.Equals("requesttemp"))
                {
                    foreach (var item in listDic)
                    {
                        if (item.Value != null && item.Value.GetType().Name.Equals("JObject"))
                        {
                            var dicObject = GetDicFromObject(item.Value);
                            dicObject.Add("OldValue", "");
                            if (!EqualNullOrEmpty(dicObject["OldValue"], dicObject["Value"]))
                            {
                                result.Add(item.Key, dicObject);
                            }

                        }

                    }
                }
                else if (val.Key.Equals("requestinfo"))
                {
                    foreach (var item in listDic)
                    {
                        if (item.Value != null && item.Value.GetType().Name.Equals("JObject"))
                        {
                            var dicObject = GetDicFromObject(item.Value);
                            dicObject.Add("OldValue", "");
                            if (!dicObject["OldValue"].Equals(dicObject["Value"]))
                            {
                                result.Add(item.Key, dicObject);
                            }
                        }
                    }
                }
                else
                {
                    var cloneDic = listDic.ToList();
                    foreach (var item in cloneDic)
                    {
                        if (item.Value != null && item.Value.GetType().Name.Equals("JObject"))
                        {
                            var dicObject = GetDicFromObject(item.Value);
                            dicObject.Add("OldValue", "");
                            listDic.Remove(item.Key);
                            listDic.Add(item.Key, dicObject);
                        }
                    }
                    if (!EqualNullOrEmpty(listDic["OldValue"], listDic["Value"]))
                    {
                        result.Add(val.Key, listDic);
                    }

                }
            }

        }

        private bool EqualNullOrEmpty(object p1, object p2)
        {
            var r1 = p1 == null ? "" : p1.ToString();
            var r2 = p2 == null ? "" : p2.ToString();
            return r1.Equals(r2);
        }


        private IDictionary<string, object> GetDicFromObject(object val)
        {
            var serializeStr = JsonConvert.SerializeObject(val);
            return JsonConvert.DeserializeObject<IDictionary<string, object>>(serializeStr);
        }
        private dynamic GetDynFromObject(IDictionary<string, object> val)
        {
            var serializeStr = JsonConvert.SerializeObject(val);
            return JsonConvert.DeserializeObject<dynamic>(serializeStr);
        }
        private dynamic GetDynFromObject(List<KeyValuePair<string, object>> val)
        {
            var serializeStr = JsonConvert.SerializeObject(val);
            return JsonConvert.DeserializeObject<dynamic>(serializeStr);
        }

        private List<IDictionary<string, object>> GetDicFromList(object val)
        {
            var serializeStr = JsonConvert.SerializeObject(val);
            return JsonConvert.DeserializeObject<List<IDictionary<string, object>>>(serializeStr);
        }

        private dynamic GetDynFromList(List<IDictionary<string, object>> val)
        {
            var serializeStr = JsonConvert.SerializeObject(val);
            return JsonConvert.DeserializeObject<dynamic>(serializeStr);
        }
        #endregion
    }
}
