using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConnectDatabase.Entities
{
    public class LibTask : Entity
    {
        public LibTask()
        {
            this.TaskActions = new List<TaskAction>();
        }
        public string Name { get; set; }
        public string TaskNumber { get; set; }
        public int MilestoneStatusId { get; set; }
        public int Step { get; set; }
        public int Type { get; set; }

        public virtual MilestoneStatus MilestoneStatus { get; set; }
        public virtual ICollection<TaskAction> TaskActions { get; set; }
    }
}
