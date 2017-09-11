﻿using System;
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
        public TestDbContext() : base("TestMysql") { }
        //public DbSet<LibAction> LibActions { get; set; }
        //public DbSet<LibTask> LibTasks { get; set; }
        //public DbSet<Milestone> Milestones { get; set; }
        //public DbSet<MilestoneStatus> MilestoneStatuses { get; set; }
        //public DbSet<TaskAction> TaskActions { get; set; }
        //public DbSet<Section> Sections { get; set; }
        //public DbSet<SectionQuestion> SectionQuestions { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<DatabaseVersion> DatabaseVersions { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //modelBuilder.Configurations.Add(new LibActionMap());
            //modelBuilder.Configurations.Add(new LibTaskMap());
            //modelBuilder.Configurations.Add(new MilestoneMap());
            //modelBuilder.Configurations.Add(new MilestoneStatusMap());
            //modelBuilder.Configurations.Add(new TaskActionMap());
            //modelBuilder.Configurations.Add(new SectionMap());
            //modelBuilder.Configurations.Add(new SectionQuestionMap());
            modelBuilder.Configurations.Add(new UserMap());
            modelBuilder.Configurations.Add(new DatabaseVersionMap());
        }
    }
}
