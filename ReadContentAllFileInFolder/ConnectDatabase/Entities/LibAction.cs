using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConnectDatabase.Entities;

namespace ConnectDatabase.Entities
{
    public class LibAction 
    {
        public LibAction()
        {
            //TaskActions = new List<TaskAction>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public string ActionNumber { get; set; }
        public int ExecuteType { get; set; }
        public string Description { get; set; }
        public string RouteName { get; set; }
        public string ActionProperty { get; set; }

        //public virtual ICollection<TaskAction> TaskActions { get; set; }
    }
}
