using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConnectDatabase.Entities
{
    public class SectionQuestion :Entity
    {
        public SectionQuestion()
        {

        }
        public string Name { get; set; }
        public string Content { get; set; }
        public string Parameters { get; set; }
        public string Calculator { get; set; }
    }
}
