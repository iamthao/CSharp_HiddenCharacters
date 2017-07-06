using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PcstLib.Sqlite.Base
{
    public class SqliteCustomizeMaping<T> : EntityTypeConfiguration<T> where T : Entity
    {
        public SqliteCustomizeMaping()
        {
            // Primary Key
            HasKey(t => t.Id);
        }
    }
}
