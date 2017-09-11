using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConnectDatabase.Entities.Mapping
{
    public class SectionQuestionMap : EntityTypeConfiguration<SectionQuestion>
    {
        public SectionQuestionMap()
        {
            ToTable("sectionquestion");

            Property(s => s.Content).HasColumnName("Content");
            Property(s => s.Parameters).HasColumnName("Parameters");
            Property(s => s.Calculator).HasColumnName("Calculator");
            Property(s => s.Name).HasColumnName("Name");
        }
    }
}
