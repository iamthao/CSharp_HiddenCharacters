using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConnectDatabase.Entities;
using ConnectDatabase.Entities.Mapping;

namespace ConnectDatabase
{
    public class TestDbContext : DbContext
    {
        public TestDbContext() : base(nameOrConnectionString: "TestMysql") { }
        public DbSet<LibAction> LibActions { get; set; }
        public DbSet<LibTask> LibTasks { get; set; }
        public DbSet<Milestone> Milestones { get; set; }
        public DbSet<MilestoneStatus> MilestoneStatuses { get; set; }
        public DbSet<TaskAction> TaskActions { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new LibActionMap());
            modelBuilder.Configurations.Add(new LibTaskMap());
            modelBuilder.Configurations.Add(new MilestoneMap());
            modelBuilder.Configurations.Add(new MilestoneStatusMap());
            modelBuilder.Configurations.Add(new TaskActionMap());
        }
    }
}
