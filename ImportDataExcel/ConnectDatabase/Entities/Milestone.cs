

using System.Collections.Generic;

namespace ConnectDatabase.Entities
{
    public class Milestone : Entity
    {
        public Milestone()
        {
            MilestoneStatuss = new List<MilestoneStatus>();
        }

        public string Name { get; set; }
        public virtual ICollection<MilestoneStatus> MilestoneStatuss { get; set; }
    }
}
