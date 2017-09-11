using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConnectDatabase.Entities.Mapping
{
    public class DatabaseVersionMap : EntityTypeConfiguration<DatabaseVersion>
    {
        public DatabaseVersionMap()
        {          
            // Table & Column Mappings
            this.ToTable("databaseversion");
            this.Property(t => t.Version).HasColumnName("version");
        }
    }
}
