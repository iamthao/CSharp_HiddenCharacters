using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using PcstLib.Sqlite.Base;

namespace PcstLib.Sqlite.Entities
{
    public class ZeroPcstResult
    {
        public int Order { get; set; }
        public string Field { get; set; }
        public string Value { get; set; }
        public bool IsZeroPcstResult { get; set; }
    }

    public class Section : Entity
    {
        public Section()
        {
            SectionQuestions = new List<SectionQuestion>();
        }
        public string Name { get; set; }
        public string Content { get; set; }
        public int Order { get; set; }
        public int PcstVersion { get; set; }
        public string Calculator { get; set; }

        [NotMapped]
        public List<ZeroPcstResult> ZeroPcstResults
        {
            get
            {
                if (!string.IsNullOrEmpty(Calculator))
                {
                    return JsonConvert.DeserializeObject<List<ZeroPcstResult>>(Calculator);
                }
                return null;
            }
        }

        public virtual ICollection<SectionQuestion> SectionQuestions { get; set; }
    }
}
