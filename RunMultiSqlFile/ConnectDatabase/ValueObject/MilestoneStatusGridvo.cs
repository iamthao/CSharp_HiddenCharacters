using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConnectDatabase.ValueObject
{
    public class MilestoneStatusGridVo : ReadGridVo
    {
        public string Name { get; set; }
        public int MilestoneId { get; set; }
    }
}
