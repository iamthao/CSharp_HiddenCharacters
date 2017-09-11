using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConnectDatabase.Entities.Mapping
{
    public class SectionMap : EntityTypeConfiguration<Section>
    {
        public SectionMap()
        {
            // Table & Column Mappings
            this.ToTable("section");
            Property(s => s.Name).HasColumnName("Name");
            Property(s => s.Order).HasColumnName("Order");
            Property(s => s.Content).HasColumnName("Content");
            Property(s => s.PcstVersion).HasColumnName("PcstVersion");
            Property(s => s.Calculator).HasColumnName("Calculator");
        }
    }
}
