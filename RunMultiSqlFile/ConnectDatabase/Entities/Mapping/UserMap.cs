using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConnectDatabase.Entities.Mapping
{
    public class UserMap : EntityTypeConfiguration<User>
    {
        public UserMap()
        {          
            // Table & Column Mappings
            this.ToTable("user");
            this.Property(t => t.UserName).HasColumnName("username");
            this.Property(t => t.Password).HasColumnName("password");
        }
    }
}
