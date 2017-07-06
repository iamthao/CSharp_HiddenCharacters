using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConnectDatabase.Entities.Mapping
{
    public class LibActionMap : EntityTypeConfiguration<LibAction>
    {
        public LibActionMap()
        {
            this.Property(t => t.Name)
                .IsRequired()
                .HasMaxLength(100);

            this.Property(t => t.Description)
                .IsRequired()
                .HasMaxLength(500);

            // Table & Column Mappings
            this.ToTable("action");
            this.Property(t => t.Name).HasColumnName("Name");
            this.Property(t => t.ActionNumber).HasColumnName("ActionNumber");
            this.Property(t => t.ExecuteType).HasColumnName("ExecuteType");
            this.Property(t => t.RouteName).HasColumnName("RouteName");
            this.Property(t => t.Description).HasColumnName("Description");
            this.Property(t => t.ActionProperty).HasColumnName("ActionProperty");
        }
    }
}
