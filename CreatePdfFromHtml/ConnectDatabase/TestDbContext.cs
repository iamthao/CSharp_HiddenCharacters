using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConnectDatabase
{
    public class TestDbContext : DbContext
    {
        public TestDbContext() : base(nameOrConnectionString: "TestMysql") { }
       
       

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {          
          
        }
    }
}
