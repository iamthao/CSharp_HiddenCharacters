using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using Newtonsoft.Json;
using PcstLib.Sqlite;
using PcstLib.Sqlite.ValueObject;
using PcstLib.Utility;

namespace PcstLib.Services
{
    [JsonObject(MemberSerialization.OptIn)]
    public class AdvanceSearchPhysician
    {
        [JsonProperty]
        public string NPI { get; set; }
        [JsonProperty]
        public string PhysicianFullName { get; set; }
    }
    public class NpiService
    {
        public dynamic GetListNpi(QueryGridPhysicianVo queryInfo)
        {
            
            var finalResult = GetData(queryInfo);
            var total = finalResult.Count();

            dynamic result = new ExpandoObject();
            result.Data = finalResult.Skip(queryInfo.skip).Take(queryInfo.take);
            result.TotalRowCount = total;
            return result;
        }

        private List<PhysicianGridVo> GetData(QueryGridPhysicianVo queryInfo)
        {
            var resultNpi = new List<PhysicianGridVo>();
            var npiList = new List<PhysicianGridVo>();
            using (var context = new DefaulDataContext())
            {
                var npis = (from item in context.PhysicianNpis
                    select item);

                bool isQuery = false;
                if (!string.IsNullOrEmpty(queryInfo.NPI))
                {
                    npis = npis.Where(o => o.Npi == queryInfo.NPI);
                    isQuery = true;
                }
                else
                {
                    if (!string.IsNullOrEmpty(queryInfo.FirstName))
                    {
                        npis = npis.Where(o => o.FirstName.ToUpper() == queryInfo.FirstName.ToUpper());
                        isQuery = true;
                    }

                    if (!string.IsNullOrEmpty(queryInfo.LastName))
                    {
                        npis = npis.Where(o => o.LastName.ToUpper() == queryInfo.LastName.ToUpper());
                        isQuery = true;
                    }
                }

                if (!isQuery)
                {
                    return new List<PhysicianGridVo>();
                }

                npiList = (from p in npis
                    select new PhysicianGridVo()
                    {
                        Mpi = p.Mpi,
                        Npi = p.Npi,
                        FirstName = p.FirstName,
                        LastName = p.LastName,
                        MiddleName = p.MiddleName,
                        Address1 = p.Address1,
                        Address2 = p.Address2,
                        City = p.City,
                        State = p.State,
                        Zip = p.Zip,
                        ZipExtension = p.ZipExtension,
                        Phone = p.Phone,
                        Fax = "",
                        ClinicName = "",
                        EffectiveDateText = p.EffectiveDateText,
                    }).ToList();

                resultNpi = npiList.ToList();

            }

            foreach (var item in npiList.Where(item => !CheckEffectiveDate(item.Npi)))
                {
                    resultNpi.Remove(item);
                }

            return resultNpi;
           
        }

        public bool CheckEffectiveDate(string npi)
        {
            using (var context = new DefaulDataContext())
            {
                var npiObj = context.PhysicianNpis.FirstOrDefault(o => o.Npi == npi.Trim());
                if (npiObj != null && !string.IsNullOrEmpty(npiObj.EffectiveDateText))
                {
                    string effectiveStr = npiObj.EffectiveDateText;
                    if (string.IsNullOrEmpty(effectiveStr))
                    {
                        return false;
                    }
                    List<EffectiveDate> results = new List<EffectiveDate>();
                    int partLength = 8;
                    char symbol = ';';
                    string[] part = effectiveStr.Split(symbol);
                    for (int i = 0; i < part.Length; i++)
                    {
                        try
                        {
                            EffectiveDate efd = new EffectiveDate();
                            string startDateText = part[i].Substring(0, partLength);
                            int startYear = int.Parse(startDateText.Substring(0, 4));
                            int startMonth = int.Parse(startDateText.Substring(4, 2));
                            int startDay = int.Parse(startDateText.Substring(6, 2));
                            efd.StartDate = new DateTime(startYear, startMonth, startDay);

                            string endDateText = part[i].Substring(8, partLength);
                            int endYear = int.Parse(endDateText.Substring(0, 4));
                            int endMonth = int.Parse(endDateText.Substring(4, 2));
                            int endDay = int.Parse(endDateText.Substring(6, 2));
                            efd.EndDate = new DateTime(endYear, endMonth, endDay);

                            results.Add(efd);
                        }
                        catch
                        {
                            return false;
                        }
                    }

                    var now = DateTime.Now;
                    now = new DateTime(now.Year, now.Month, now.Day);
                    foreach (var item in results)
                    {
                        if (item.StartDate <= now && now <= item.EndDate)
                        {
                            return true;
                        }
                    }
                }

                return false;
            }
        }

        private string BuildCommandExecute(AdvanceSearchPhysician advance, string table)
        {
            string result = string.Format("select * from {0} where", table);
            if (!string.IsNullOrEmpty(advance.NPI))
            {
                result += string.Format(" NPI = '{0}'", advance.NPI);
                return result;
            }
            if (!string.IsNullOrEmpty(advance.PhysicianFullName))
            {
                //result += string.Format(" match(LastName, FirstName, MiddleName) against('{0}*' in boolean mode)", advance.PhysicianFullName);
                result += string.Format(" LastName MATCH '{0}*' OR FirstName MATCH '{0}*' OR MiddleName MATCH '{0}*'",advance.PhysicianFullName);
            }

            return result;
        }

        
    }

}
