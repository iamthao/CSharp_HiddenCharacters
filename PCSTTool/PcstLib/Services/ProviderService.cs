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
    
    public class ProviderService
    {
        public dynamic GetListProvider(QueryGridProvider queryInfo)
        {
            
            var finalResult = GetData(queryInfo);
            var total = finalResult.Count();

            dynamic result = new ExpandoObject();
            result.Data = finalResult.Skip(queryInfo.skip).Take(queryInfo.take);
            result.TotalRowCount = total;
            return result;
        }

        private List<ProviderMpiVo> GetData(QueryGridProvider queryInfo)
        {
            var resultPro = new List<ProviderMpiVo>();
            var providerList = new List<ProviderMpiVo>();
            using (var context = new DefaulDataContext())
            {
                var provider = (from item in context.ProviderAgencies
                    select item);

                bool isQuery = false;
                if (!string.IsNullOrEmpty(queryInfo.Npi))
                {
                    provider = provider.Where(o => o.Npi.ToLower().Contains(queryInfo.Npi.ToLower()));
                    isQuery = true;
                }
                else if (!string.IsNullOrEmpty(queryInfo.Mpi))
                {
                    provider = provider.Where(o => o.Mpi.ToLower().Contains(queryInfo.Mpi.ToLower()));
                    isQuery = true;
                }
                else if (!string.IsNullOrEmpty(queryInfo.AgencyName))
                {
                    provider = provider.Where(o => o.Name.ToLower().Contains(queryInfo.AgencyName.ToLower()));
                    isQuery = true;
                }

                if (!isQuery)
                {
                    return new List<ProviderMpiVo>();
                }

                providerList = (from p in provider
                                    select new ProviderMpiVo()
                                    {
                                        Id = p.Mpi,
                                        Mpi = p.Mpi,
                                        Npi = p.Npi,
                                        Name = p.Name,
                                        Address1 = p.Address1,
                                        Address2 = p.Address2,
                                        City = p.City,
                                        State = p.State,
                                        Zip = p.Zip,
                                        Phone = p.Phone,
                                        Email = p.Email,
                                    }).ToList();

                resultPro = providerList.ToList();

            }

            foreach (var item in providerList.Where(item => !CheckEffectiveDate(item.Mpi)))
                {
                    resultPro.Remove(item);
                }

            return resultPro;
           
        }

        public bool CheckEffectiveDate(string mpi)
        {
            using (var context = new DefaulDataContext())
            {
                var mpiTrim = mpi.Trim();
                var mpiObj = context.ProviderMpis.FirstOrDefault(o => o.Mpi == mpiTrim);
                if (mpiObj != null && !string.IsNullOrEmpty(mpiObj.EffectiveDateText))
                {
                    string effectiveStr = mpiObj.EffectiveDateText;
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

        public ProviderMpiVo GetProviderFromName(string name)
        {
            var providerVo = new ProviderMpiVo();
            if (string.IsNullOrEmpty(name.Trim()))
                return providerVo;
            using (var context = new DefaulDataContext())
            {
                var provider = (from item in context.ProviderAgencies
                                where item.Name.ToLower().Contains(name.Trim().ToLower())
                                select item);
                var providerList = (from p in provider 
                                select new ProviderMpiVo()
                                {
                                    Id = p.Mpi,
                                    Mpi = p.Mpi,
                                    Npi = p.Npi,
                                    Name = p.Name,
                                    Address1 = p.Address1,
                                    Address2 = p.Address2,
                                    City = p.City,
                                    State = p.State,
                                    Zip = p.Zip,
                                    Phone = p.Phone,
                                    Email = p.Email,
                                }).ToList().FirstOrDefault();
                if (providerList != null)
                {
                    if (!string.IsNullOrEmpty(providerList.Mpi))
                    {
                        return providerList;
                    }
                }
            }
            return providerVo;
        }
        
    }

}
