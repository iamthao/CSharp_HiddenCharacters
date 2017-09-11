using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConnectDatabase.ValueObject
{
    public class LibTaskGridVo : ReadGridVo
    {
        public string Name { get; set; }
        public string TaskNumber { get; set; }
        public int MilestoneStatusId { get; set; }
        public int Step { get; set; }
        public int Type { get; set; }
    }
}
