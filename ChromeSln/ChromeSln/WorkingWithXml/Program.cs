using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration;
using System.Dynamic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using Microsoft.Owin.Hosting;
using Newtonsoft.Json;
using PcstLib.Entry;
using System.Data.SQLite;

namespace WorkingWithXml
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    public class UserMap : EntityTypeConfiguration<User>
    {
        public UserMap()
        {
            ToTable("user");
            // Primary Key
            HasKey(t => t.Id);
            Property(s => s.Name).HasColumnName("Name");
        }
    }
    public class UserContext : DbContext
    {
        public UserContext() : base("Name=UserContext") { }
        public DbSet<User> Users { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new UserMap());
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            using (var context = new UserContext())
            {
                var list = context.Users.ToList();
                context.Users.Add(new User {Name = "Abc"});
                context.SaveChanges();
            }
        }
    }
}
