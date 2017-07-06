using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PcstLib.Sqlite.ValueObject
{
    [Serializable]
    public class Sort
    {
        public string Field { get; set; }
        public string Dir { get; set; }
    }
}
