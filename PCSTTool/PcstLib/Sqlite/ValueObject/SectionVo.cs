using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PcstLib.Sqlite.ValueObject
{
    public class SectionVo
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Content { get; set; }
        public string ResultContent { get; set; }
        public int Order { get; set; }
        public List<SectionQuestionVo> SectionQuestions { get; set; }
        public bool? IsSignature { get; set; }
    }
}
