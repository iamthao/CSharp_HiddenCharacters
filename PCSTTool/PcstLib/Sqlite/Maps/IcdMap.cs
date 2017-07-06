using PcstLib.Sqlite.Base;
using PcstLib.Sqlite.Entities;

namespace PcstLib.Sqlite.Maps
{
    public class IcdMap : SqliteCustomizeMaping<Icd>
    {
        public IcdMap()
        {
            ToTable("icd");
            Property(s => s.Code).HasMaxLength(50);
            Property(s => s.Description).HasMaxLength(1000);
            Property(s => s.IcdType).IsRequired();
            Property(s => s.Code).HasColumnName("Code");
            Property(s => s.Description).HasColumnName("Description");
            Property(s => s.IcdType).HasColumnName("IcdType");
        }
    }
}
