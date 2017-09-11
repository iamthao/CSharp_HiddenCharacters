using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConnectDatabase.Entities
{
    public class Section : Entity
    {
        public Section()
        {
            
        }
        public string Name { get; set; }
        public string Content { get; set; }
        public int Order { get; set; }
        public int PcstVersion { get; set; }
        public string Calculator { get; set; }
    }
}
