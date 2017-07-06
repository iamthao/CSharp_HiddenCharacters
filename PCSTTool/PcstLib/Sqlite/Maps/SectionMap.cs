using PcstLib.Sqlite.Base;
using PcstLib.Sqlite.Entities;

namespace PcstLib.Sqlite.Maps
{
    public class SectionMap : SqliteCustomizeMaping<Section>
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
