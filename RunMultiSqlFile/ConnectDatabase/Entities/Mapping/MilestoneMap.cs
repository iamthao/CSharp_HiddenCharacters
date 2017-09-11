using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConnectDatabase.Entities.Mapping
{
    public class MilestoneMap : EntityTypeConfiguration<Milestone>
    {
        public MilestoneMap()
        {
            this.Property(t => t.Name)
                .IsRequired()
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("Milestone");
            this.Property(t => t.Name).HasColumnName("Name");
        }
    }
}
