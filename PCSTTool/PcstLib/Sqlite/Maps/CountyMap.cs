using PcstLib.Sqlite.Base;
using PcstLib.Sqlite.Entities;

namespace PcstLib.Sqlite.Maps
{
    public class CountyMap : SqliteCustomizeMaping<County>
    {
        public CountyMap()
        {
            ToTable("county");
            Property(s => s.Name).HasColumnName("Name").IsRequired();
            Property(s => s.StateId).HasColumnName("StateId").IsRequired();
            Property(s => s.Code).HasColumnName("Code");
            
        }
    }
}
