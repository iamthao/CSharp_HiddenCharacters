using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PcstLib.Sqlite.Entities;
using PcstLib.Sqlite.Maps;

namespace PcstLib.Sqlite
{
    public class DefaulDataContext: DbContext
    {
        public DefaulDataContext() : base("Name=DefaulDataContext") { }
        public DbSet<County> Counties { get; set; }
        public DbSet<Frequency> Frequencies { get; set; }
        public DbSet<Icd> Icds { get; set; }
        public DbSet<PrimaryLanguage> PrimaryLanguages { get; set; }
        public DbSet<Route> Routes { get; set; }
        public DbSet<Section> Sections { get; set; }
        public DbSet<SectionQuestion> SectionQuestions { get; set; }
        public DbSet<PhysicianNpi> PhysicianNpis { get; set; }
        public DbSet<ProviderAgency> ProviderAgencies { get; set; }
        public DbSet<ProviderMpi> ProviderMpis { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new CountyMap());
            modelBuilder.Configurations.Add(new FrequencyMap());
            modelBuilder.Configurations.Add(new IcdMap());
            modelBuilder.Configurations.Add(new PrimaryLanguageMap());
            modelBuilder.Configurations.Add(new RouteMap());
            modelBuilder.Configurations.Add(new SectionMap());
            modelBuilder.Configurations.Add(new SectionQuestionMap());
            modelBuilder.Configurations.Add(new PhysicianNpiMap());
            modelBuilder.Configurations.Add(new ProviderAgencyMap());
            modelBuilder.Configurations.Add(new ProviderMpiMap());
        }
    }
}
