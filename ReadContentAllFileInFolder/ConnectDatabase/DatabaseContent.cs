using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConnectDatabase.Entities;
using ConnectDatabase.Mapping;

namespace ConnectDatabase
{
    public class DatabaseContent : DbContext
    {

        public DatabaseContent() : base("LibrisDB") { }
        public DbSet<LibAction> LibActions { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new LibActionMap());
        }

    }
}
