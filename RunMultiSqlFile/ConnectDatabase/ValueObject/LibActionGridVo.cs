using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConnectDatabase.ValueObject
{
    public class LibActionGridVo : ReadGridVo
    {
        public string Name { get; set; }
        public int ActionNumber { get; set; }
        public int ExecuteType { get; set; }
        public string Description { get; set; }
        public string RouteName { get; set; }
    }
}
