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

    public class County 
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public int StateId { get; set; }
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

    public class CountyMap : EntityTypeConfiguration<County>
    {
        public CountyMap()
        {
            ToTable("county");
            HasKey(t => t.Id);
            Property(s => s.Name).HasColumnName("Name").IsRequired();
            Property(s => s.StateId).HasColumnName("StateId").IsRequired();
            Property(s => s.Code).HasColumnName("Code");

        }
    }
    public class UserContext : DbContext
    {
        public UserContext() : base("Name=UserContext") { }
        public DbSet<User> Users { get; set; }
        public DbSet<County> Counties { get; set; }
        public DbSet<Section> Sections { get; set; }
        public DbSet<SectionQuestion> SectionQuestions { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new UserMap());
            modelBuilder.Configurations.Add(new CountyMap());
            modelBuilder.Configurations.Add(new SectionQuestionMap());
            modelBuilder.Configurations.Add(new SectionMap());
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            using (var context = new UserContext())
            {
                var list = context.Counties.ToList();
                //context.Users.Add(new User {Name = "Abc"});
                //context.SaveChanges();
            }
        }
    }

    public class SectionQuestion
    {
        public int Id { get; set; }//
        public string Name { get; set; }//
        public string Content { get; set; }//
        public string Parameters { get; set; }//
        public string Calculator { get; set; }//

        //[NotMapped]
        //public IList<SectionTempleteVo> SectionTempleteVos
        //{
        //    get { return JsonConvert.DeserializeObject<List<SectionTempleteVo>>(Parameters); }
        //}

        //[NotMapped]
        //public List<CalculatorVo> CalculatorVo
        //{
        //    get
        //    {
        //        return string.IsNullOrEmpty(Calculator) ? null : JsonConvert.DeserializeObject<List<CalculatorVo>>(Calculator);
        //    }
        //}

        public int Order { get; set; }//
        public int SectionId { get; set; }//
        public int PcstVersion { get; set; }//
        public bool? IsSignature { get; set; }//
        public bool? IsSignatureDate { get; set; }//
        public bool? IsBathing { get; set; }//
        public bool? IsADLsCal { get; set; }//
        public bool? IsMOT { get; set; }//
        public bool? IsMedicalAppointments { get; set; }//
        public bool? IsServicesIncidental { get; set; }//
        public bool? IsBehaviorsMedicalConditionsSeizures { get; set; }//
        public bool? IsDiagnoses { get; set; }//
        public bool? IsMedications { get; set; }//
        public bool? IsDME { get; set; }//
        public bool? IsAllergies { get; set; }//
        public bool? IsFunctionalLimitation { get; set; }//
        public bool? IsActivitiesPermitted { get; set; }//
        public bool? IsMentalStatus { get; set; }//
        public bool? IsReassessmentDue { get; set; }//
        public bool? IsCheckZeroMinutesPCST { get; set; }//
        public virtual Section Section { get; set; }
    }

    public class Section
    {
        public Section()
        {
            SectionQuestions = new List<SectionQuestion>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public string Content { get; set; }
        public int Order { get; set; }
        public int PcstVersion { get; set; }
        public string Calculator { get; set; }

        

        public virtual ICollection<SectionQuestion> SectionQuestions { get; set; }
    }

    public class SectionQuestionMap : EntityTypeConfiguration<SectionQuestion>
    {
        public SectionQuestionMap()
        {
            ToTable("sectionquestion");

            Property(s => s.Content).HasColumnName("Content");//
            Property(s => s.Parameters).HasColumnName("Parameters");//
            Property(s => s.Order).HasColumnName("Order");//
            Property(s => s.SectionId).HasColumnName("SectionId");//
            Property(s => s.Name).HasColumnName("Name");//
            Property(s => s.PcstVersion).HasColumnName("PcstVersion");//
            Property(s => s.Calculator).HasColumnName("Calculator");//
            Property(s => s.IsSignature).HasColumnName("IsSignature");//
            Property(s => s.IsSignatureDate).HasColumnName("IsSignatureDate");//
            Property(s => s.IsBathing).HasColumnName("IsBathing");//
            Property(s => s.IsADLsCal).HasColumnName("IsADLsCal");//
            Property(s => s.IsMOT).HasColumnName("IsMOT");//
            Property(s => s.IsMedicalAppointments).HasColumnName("IsMedicalAppointments");//
            Property(s => s.IsServicesIncidental).HasColumnName("IsServicesIncidental");//
            Property(s => s.IsBehaviorsMedicalConditionsSeizures).HasColumnName("IsBehaviorsMedicalConditionsSeizures");//

            Property(s => s.IsDiagnoses).HasColumnName("IsDiagnoses");
            Property(s => s.IsMedications).HasColumnName("IsMedications");
            Property(s => s.IsDME).HasColumnName("IsDME");
            Property(s => s.IsAllergies).HasColumnName("IsAllergies");
            Property(s => s.IsFunctionalLimitation).HasColumnName("IsFunctionalLimitation");
            Property(s => s.IsActivitiesPermitted).HasColumnName("IsActivitiesPermitted");
            Property(s => s.IsMentalStatus).HasColumnName("IsMentalStatus");
            Property(s => s.IsReassessmentDue).HasColumnName("IsReassessmentDue");
            Property(s => s.IsCheckZeroMinutesPCST).HasColumnName("IsCheckZeroMinutesPCST");
            HasRequired(o => o.Section).WithMany(o => o.SectionQuestions).HasForeignKey(o => o.SectionId);
        }

    }

    public class SectionMap : EntityTypeConfiguration<Section>
    {
        public SectionMap()
        {
            ToTable("section");
            Property(s => s.Name).HasColumnName("Name");
            Property(s => s.Order).HasColumnName("Order");
            Property(s => s.Content).HasColumnName("Content");
            Property(s => s.PcstVersion).HasColumnName("PcstVersion");
            Property(s => s.Calculator).HasColumnName("Calculator");
        }
    }
}

