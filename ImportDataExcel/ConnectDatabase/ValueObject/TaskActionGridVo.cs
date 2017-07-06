using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConnectDatabase.ValueObject
{
    public class TaskActionGridVo : ReadGridVo
    {
        public int TaskId { get; set; }
        public int ActionId { get; set; }
        public int EventType { get; set; }
    }
}
