using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConnectDatabase.Entities.Mapping
{
    public class MilestoneStatusMap : EntityTypeConfiguration<MilestoneStatus>
    {
        public MilestoneStatusMap()
        {
            this.Property(t => t.Name)
                .IsRequired()
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("MilestoneStatus");
            this.Property(t => t.Name).HasColumnName("Name");
            this.Property(t => t.MilestoneId).HasColumnName("MilestoneId");

            // Relationships
            this.HasRequired(t => t.Milestone)
                .WithMany(t => t.MilestoneStatuss)
                .HasForeignKey(d => d.MilestoneId);

        }
    }
}
