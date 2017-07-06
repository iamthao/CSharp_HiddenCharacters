using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PcstLib.Sqlite.ValueObject
{
    public class QueryGridPhysicianVo
    {
        public int pageSize { get; set; }
        public int skip { get; set; }
        public int take { get; set; }
        public string NPI { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }

    public class EffectiveDate
    {
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}
