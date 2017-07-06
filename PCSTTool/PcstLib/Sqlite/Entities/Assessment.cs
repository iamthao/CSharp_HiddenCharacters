using System;
using System.Collections.Generic;
using PcstLib.Sqlite.Base;

namespace PcstLib.Sqlite.Entities
{
    public sealed class Assessment :Entity
    {
        public Assessment()
        {
            AssessmentSectionQuestions = new List<AssessmentSectionQuestion>();
        }
        public string FileName { get; set; }
        public string FilePath { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime ModifiedOn { get; set; }

        public ICollection<AssessmentSectionQuestion> AssessmentSectionQuestions { get; set; }

        public string AssessmentData { get; set; }
        public string DisclosureFormData { get; set; }
        public string Mid { get; set; }
        public string Extension { get; set; }
       
    }
}
