using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace PcstLib.Sqlite.ValueObject
{
    public class QueryInfo
    {
        public QueryInfo()
        {
            // defaults
            Take = 50;
            //ActiveRecords = true;
            //InactiveRecords = true;
            Sort = new List<Sort>();
        }


        public int Take { get; set; }
        public int Skip { get; set; }
        public int QueryId { get; set; }
        public List<Sort> Sort { get; set; }
        public string SearchString { get; set; }
        public string AdditionalSearchString { get; set; }

        public string SearchTerms { get; set; }
        public DateTime? CreatedBefore { get; set; }
        public DateTime? CreatedAfter { get; set; }
        public int CreatedBy { get; set; }
        public DateTime? ModifiedBefore { get; set; }
        public DateTime? ModifiedAfter { get; set; }
        public int ModifiedBy { get; set; }
        public byte[] SearchStringByte { get; set; }
        //public bool ActiveRecords { get; set; }
        //public bool InactiveRecords { get; set; }
        public int TotalRecords { get; set; }
        public bool? IsLazyPaging { get; set; }
        public int? ClientTimeZoneOffset { get; set; }

        public string SortString
        {
            get
            {
                // order the results
                if (Sort != null && Sort.Count > 0)
                {
                    var sorts = new List<string>();
                    Sort.ForEach(x => sorts.Add(string.Format("{0} {1}", x.Field, x.Dir)));
                    return string.Join(",", sorts.ToArray());
                }
                return string.Empty;
            }
        }

        public virtual void ParseParameters(string xmlParams)
        {
            if (xmlParams == null)
                return;
            try
            {
                var xml = XDocument.Parse(xmlParams);
                foreach (var param in xml.Descendants("AdvancedQueryParameters"))
                {
                    var searchTerm = param.Element("SearchTerms");
                    if (searchTerm != null)
                        //Remove " because using dynamic linq
                        SearchTerms = searchTerm.Value.Replace("\"", "");
                }
            }
            catch (Exception)
            {

                var result =
                    xmlParams.Replace("<AdvancedQueryParameters><SearchTerms>", "")
                        .Replace("</SearchTerms></AdvancedQueryParameters>", "");
                //Remove " because using dynamic linq
                SearchTerms = result.Replace("\"", "");
            }

        }

        //protected string Base64Encode(string plainText)
        //{
        //    var plainTextBytes = System.Text.Encoding.UTF8.GetBytes(plainText);
        //    return System.Convert.ToBase64String(plainTextBytes);
        //}
        //protected string Base64Decode(string base64EncodedData)
        //{
        //    var base64EncodedBytes = System.Convert.FromBase64String(base64EncodedData);
        //    return System.Text.Encoding.UTF8.GetString(base64EncodedBytes);
        //}

        public string PathFileDefaultData { get; set; }
    }
}
