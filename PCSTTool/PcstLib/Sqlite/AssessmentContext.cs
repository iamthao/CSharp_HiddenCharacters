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
    public class AssessmentContext: DbContext
    {
        public AssessmentContext() : base("Name=AssessmentContext") { }
        public DbSet<Assessment> Assessments { get; set; }
        public DbSet<AssessmentSectionQuestion> AssessmentSectionQuestions { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new AssessmentMap());
            modelBuilder.Configurations.Add(new AssessmentSectionQuestionMap());
        }
    }
}
