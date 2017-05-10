using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReadXml
{
    public class Test
    {
        public class InclusionTerm
        {
            public object note { get; set; }
        }

        public class InclusionTerm2
        {
            public object note { get; set; }
        }

        public class Diag3
        {
            public string name { get; set; }
            public string desc { get; set; }
            public InclusionTerm2 inclusionTerm { get; set; }
        }

        public class Excludes1
        {
            public object note { get; set; }
        }

        public class Diag2
        {
            public string name { get; set; }
            public string desc { get; set; }
            public InclusionTerm inclusionTerm { get; set; }
            public List<Diag3> diag { get; set; }
            public Excludes1 excludes1 { get; set; }
        }

        public class Includes
        {
            public string note { get; set; }
        }

        public class Excludes12
        {
            public object note { get; set; }
        }

        public class Excludes2
        {
            public List<string> note { get; set; }
        }

        public class InclusionTerm3
        {
            public List<string> note { get; set; }
        }

        public class Diag
        {
            public string name { get; set; }
            public string desc { get; set; }
            public List<Diag2> diag { get; set; }
            public Includes includes { get; set; }
            public Excludes12 excludes1 { get; set; }
            public Excludes2 excludes2 { get; set; }
            public InclusionTerm3 inclusionTerm { get; set; }
        }

        public class Section
        {
            public string desc { get; set; }
            public List<Diag> diag { get; set; }
        }

        public class RootObject
        {
            public Section section { get; set; }
        }
    }
}
