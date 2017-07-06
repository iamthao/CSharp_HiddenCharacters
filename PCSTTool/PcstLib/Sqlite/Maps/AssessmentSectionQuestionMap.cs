using PcstLib.Sqlite.Base;
using PcstLib.Sqlite.Entities;

namespace PcstLib.Sqlite.Maps
{
    public class AssessmentSectionQuestionMap : SqliteCustomizeMaping<AssessmentSectionQuestion>
    {
        public AssessmentSectionQuestionMap()
        {
            ToTable("assessmentsectionquestion");
            Property(s => s.AssessmentId).HasColumnName("AssessmentId").IsRequired();
            HasRequired(s => s.Assessment)
                .WithMany(o => o.AssessmentSectionQuestions)
                .HasForeignKey(o => o.AssessmentId);
            Property(s => s.SectionQuestionId).HasColumnName("SectionQuestionId").IsRequired();
            Property(s => s.Order).HasColumnName("Order").IsRequired();
            Property(s => s.Field01).HasColumnName("Field01");
            Property(s => s.Field02).HasColumnName("Field02");
            Property(s => s.Field03).HasColumnName("Field03");
            Property(s => s.Field04).HasColumnName("Field04");
            Property(s => s.Field05).HasColumnName("Field05");
            Property(s => s.Field06).HasColumnName("Field06");
            Property(s => s.Field07).HasColumnName("Field07");
            Property(s => s.Field08).HasColumnName("Field08");
            Property(s => s.Field09).HasColumnName("Field09");
            Property(s => s.Field10).HasColumnName("Field10");
            Property(s => s.Field11).HasColumnName("Field11");
            Property(s => s.Field12).HasColumnName("Field12");
            Property(s => s.Field13).HasColumnName("Field13");
            Property(s => s.Field14).HasColumnName("Field14");
            Property(s => s.Field15).HasColumnName("Field15");
            Property(s => s.Field16).HasColumnName("Field16");
            Property(s => s.Field17).HasColumnName("Field17");
            Property(s => s.Field18).HasColumnName("Field18");
            Property(s => s.Field19).HasColumnName("Field19");
            Property(s => s.Field20).HasColumnName("Field20");
            Property(s => s.Field21).HasColumnName("Field21");
            Property(s => s.Field22).HasColumnName("Field22");
            Property(s => s.Field23).HasColumnName("Field23");
            Property(s => s.Field24).HasColumnName("Field24");
            Property(s => s.Field25).HasColumnName("Field25");
            Property(s => s.Field26).HasColumnName("Field26");
            Property(s => s.Field27).HasColumnName("Field27");
            Property(s => s.Field28).HasColumnName("Field28");
            Property(s => s.Field29).HasColumnName("Field29");
            Property(s => s.Field30).HasColumnName("Field30");
            Property(s => s.Field31).HasColumnName("Field31");
            Property(s => s.Field32).HasColumnName("Field32");
            Property(s => s.Field33).HasColumnName("Field33");
            Property(s => s.Field34).HasColumnName("Field34");
            Property(s => s.Field35).HasColumnName("Field35");
            Property(s => s.Field36).HasColumnName("Field36");
            Property(s => s.Field37).HasColumnName("Field37");
            Property(s => s.Field38).HasColumnName("Field38");
            Property(s => s.Field39).HasColumnName("Field39");
            Property(s => s.Field40).HasColumnName("Field40");
            Property(s => s.Field41).HasColumnName("Field41");
            Property(s => s.Field42).HasColumnName("Field42");
            Property(s => s.Field43).HasColumnName("Field43");
            Property(s => s.Field44).HasColumnName("Field44");
            Property(s => s.Field45).HasColumnName("Field45");
            Property(s => s.Field46).HasColumnName("Field46");
            Property(s => s.Field47).HasColumnName("Field47");
            Property(s => s.Field48).HasColumnName("Field48");
            Property(s => s.Field49).HasColumnName("Field49");
            Property(s => s.Field50).HasColumnName("Field50");
            Property(s => s.Field51).HasColumnName("Field51");
            Property(s => s.Field52).HasColumnName("Field52");
            Property(s => s.Field53).HasColumnName("Field53");
            Property(s => s.Field54).HasColumnName("Field54");
            Property(s => s.Field55).HasColumnName("Field55");
            Property(s => s.Field56).HasColumnName("Field56");
            Property(s => s.Field57).HasColumnName("Field57");
            Property(s => s.Field58).HasColumnName("Field58");
            Property(s => s.Field59).HasColumnName("Field59");
            Property(s => s.Field60).HasColumnName("Field60");
            Property(s => s.Field61).HasColumnName("Field61");
            Property(s => s.Field62).HasColumnName("Field62");
            Property(s => s.Field63).HasColumnName("Field63");
            Property(s => s.Field64).HasColumnName("Field64");
            Property(s => s.Field65).HasColumnName("Field65");
            Property(s => s.Field66).HasColumnName("Field66");
            Property(s => s.Field67).HasColumnName("Field67");
            Property(s => s.Field68).HasColumnName("Field68");
            Property(s => s.Field69).HasColumnName("Field69");
            Property(s => s.Field70).HasColumnName("Field70");
            Property(s => s.Field71).HasColumnName("Field71");
            Property(s => s.Field72).HasColumnName("Field72");
            Property(s => s.Field73).HasColumnName("Field73");
            Property(s => s.Field74).HasColumnName("Field74");
            Property(s => s.Field75).HasColumnName("Field75");
            Property(s => s.Field76).HasColumnName("Field76");
            Property(s => s.Field77).HasColumnName("Field77");
            Property(s => s.Field78).HasColumnName("Field78");
            Property(s => s.Field79).HasColumnName("Field79");
            Property(s => s.Field80).HasColumnName("Field80");
            Property(s => s.Field81).HasColumnName("Field81");
            Property(s => s.Field82).HasColumnName("Field82");
            Property(s => s.Field83).HasColumnName("Field83");
            Property(s => s.Field84).HasColumnName("Field84");
            Property(s => s.Field85).HasColumnName("Field85");
            Property(s => s.Field86).HasColumnName("Field86");
            Property(s => s.Field87).HasColumnName("Field87");
            Property(s => s.Field88).HasColumnName("Field88");
            Property(s => s.Field89).HasColumnName("Field89");
            Property(s => s.Field90).HasColumnName("Field90");
            Property(s => s.Field91).HasColumnName("Field91");
            Property(s => s.Field92).HasColumnName("Field92");
            Property(s => s.Field93).HasColumnName("Field93");
            Property(s => s.Field94).HasColumnName("Field94");
            Property(s => s.Field95).HasColumnName("Field95");
            Property(s => s.Field96).HasColumnName("Field96");
            Property(s => s.Field97).HasColumnName("Field97");
            Property(s => s.Field98).HasColumnName("Field98");
            Property(s => s.Field99).HasColumnName("Field99");
        }
    }
}
