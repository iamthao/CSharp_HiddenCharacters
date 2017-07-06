using PcstLib.Sqlite.Base;
using PcstLib.Sqlite.Entities;

namespace PcstLib.Sqlite.Maps
{
    public class SectionQuestionMap : SqliteCustomizeMaping<SectionQuestion>
    {
        public SectionQuestionMap()
        {
            ToTable("sectionquestion");

            Property(s => s.Content).HasColumnName("Content");
            Property(s => s.Parameters).HasColumnName("Parameters");
            Property(s => s.Order).HasColumnName("Order");
            Property(s => s.SectionId).HasColumnName("SectionId");
            Property(s => s.Name).HasColumnName("Name");
            Property(s => s.PcstVersion).HasColumnName("PcstVersion");
            Property(s => s.Calculator).HasColumnName("Calculator");
            Property(s => s.IsSignature).HasColumnName("IsSignature");
            Property(s => s.IsSignatureDate).HasColumnName("IsSignatureDate");
            Property(s => s.IsBathing).HasColumnName("IsBathing");
            Property(s => s.IsADLsCal).HasColumnName("IsADLsCal");
            Property(s => s.IsMOT).HasColumnName("IsMOT");
            Property(s => s.IsMedicalAppointments).HasColumnName("IsMedicalAppointments");
            Property(s => s.IsServicesIncidental).HasColumnName("IsServicesIncidental");
            Property(s => s.IsBehaviorsMedicalConditionsSeizures).HasColumnName("IsBehaviorsMedicalConditionsSeizures");

            Property(s => s.IsDiagnoses).HasColumnName("IsDiagnoses");
            Property(s => s.IsMedications).HasColumnName("IsMedications");
            Property(s => s.IsDME).HasColumnName("IsDME");
            Property(s => s.IsAllergies).HasColumnName("IsAllergies");
            Property(s => s.IsFunctionalLimitation).HasColumnName("IsFunctionalLimitation");
            Property(s => s.IsActivitiesPermitted).HasColumnName("IsActivitiesPermitted");
            Property(s => s.IsMentalStatus).HasColumnName("IsMentalStatus");
            Property(s => s.IsReassessmentDue).HasColumnName("IsReassessmentDue");
            Property(s => s.IsCheckZeroMinutesPCST).HasColumnName("IsCheckZeroMinutesPCST");
            Property(s => s.IsMid).HasColumnName("IsMid");
            Property(s => s.FieldCheckDME).HasColumnName("FieldCheckDME");
            HasRequired(o => o.Section).WithMany(o => o.SectionQuestions).HasForeignKey(o => o.SectionId);
        }
    }
}
