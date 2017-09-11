using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConnectDatabase.Entities.Mapping
{
    public class LibTaskMap : EntityTypeConfiguration<LibTask>
    {
        public LibTaskMap()
        {
            Property(s => s.Name).HasMaxLength(100);
            Property(s => s.TaskNumber).HasMaxLength(50);

            ToTable("Task");
            Property(s => s.Name).HasColumnName("Name");
            Property(s => s.TaskNumber).HasColumnName("TaskNumber");
            Property(s => s.MilestoneStatusId).HasColumnName("MilestoneStatusId");
            Property(s => s.Step).HasColumnName("Step");
            Property(s => s.Type).HasColumnName("Type");

            this.HasRequired(t => t.MilestoneStatus)
                .WithMany(t => t.LibTasks)
                .HasForeignKey(d => d.MilestoneStatusId);
        }
    }
}
