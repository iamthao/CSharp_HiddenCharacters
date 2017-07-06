using PcstLib.Sqlite.Base;
using PcstLib.Sqlite.Entities;

namespace PcstLib.Sqlite.Maps
{
    public class AssessmentMap : SqliteCustomizeMaping<Assessment>
    {
        public AssessmentMap()
        {
            ToTable("assessment");
            Property(o => o.FileName).HasColumnName("FileName").HasColumnType("NVARCHAR").IsRequired();
            Property(o => o.FilePath).HasColumnName("FilePath").HasColumnType("NVARCHAR").IsRequired();
            Property(o => o.CreatedOn).HasColumnName("CreatedOn").HasColumnType("DATETIME").IsRequired();
            Property(o => o.ModifiedOn).HasColumnName("ModifiedOn").HasColumnType("DATETIME").IsRequired();
            Property(o => o.AssessmentData).HasColumnName("AssessmentData");
            Property(o => o.DisclosureFormData).HasColumnName("DisclosureFormData");
            Property(o => o.Mid).HasColumnName("Mid");
            Property(o => o.Extension).HasColumnName("Extension");
        }
    }
}
