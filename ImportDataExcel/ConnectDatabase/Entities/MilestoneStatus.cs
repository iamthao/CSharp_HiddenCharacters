using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConnectDatabase.Entities
{
    public class MilestoneStatus : Entity
    {
        public MilestoneStatus()
        {
            LibTasks = new List<LibTask>();
        }
        public string Name { get; set; }
        public int MilestoneId { get; set; }
        public virtual Milestone Milestone { get; set; }
        public virtual ICollection<LibTask> LibTasks { get; set; }
    }
}
