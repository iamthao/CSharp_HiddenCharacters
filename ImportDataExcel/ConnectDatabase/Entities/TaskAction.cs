using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConnectDatabase.Entities
{
    public class TaskAction : Entity
    {
        public int TaskId { get; set; }
        public int ActionId { get; set; }
        public int EventType { get; set; }
        public virtual LibAction LibAction { get; set; }
        public virtual LibTask LibTask { get; set; }
    }
}
