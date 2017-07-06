using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PcstLib.Sqlite.Base;

namespace PcstLib.Sqlite.Entities
{
    public class Frequency : Entity
    {
        public string Name { get; set; }
        public bool IsDefault { get; set; }
        public int OrderNumber { get; set; }
    }
}
