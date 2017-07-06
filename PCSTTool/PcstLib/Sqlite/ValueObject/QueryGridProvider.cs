using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PcstLib.Sqlite.ValueObject
{
    public class QueryGridProvider
    {
        public int pageSize { get; set; }
        public int skip { get; set; }
        public int take { get; set; }
        public string CurrentAgency { get; set; }
        public string Mid { get; set; }
        public bool SameCounty { get; set; }
        public string Npi { get; set; }
        public string Mpi { get; set; }
        public string AgencyName { get; set; }
    }

}
