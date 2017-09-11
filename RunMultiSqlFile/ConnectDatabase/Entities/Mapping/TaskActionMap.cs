using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConnectDatabase.Entities.Mapping
{
    public class TaskActionMap : EntityTypeConfiguration<TaskAction>
    {
        public TaskActionMap()
        {

            // Table & Column Mappings
            this.ToTable("taskaction");
            this.Property(t => t.TaskId).HasColumnName("TaskId");
            this.Property(t => t.ActionId).HasColumnName("ActionId");
            this.Property(t => t.EventType).HasColumnName("EventType");

            // Relationships
            this.HasRequired(t => t.LibAction)
                .WithMany(t => t.TaskActions)
                .HasForeignKey(d => d.ActionId);
            this.HasRequired(t => t.LibTask)
                .WithMany(t => t.TaskActions)
                .HasForeignKey(d => d.TaskId);

        }
    }
}
