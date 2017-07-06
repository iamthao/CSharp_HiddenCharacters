using PcstLib.Sqlite.Base;
using PcstLib.Sqlite.Entities;

namespace PcstLib.Sqlite.Maps
{
    public class FrequencyMap : SqliteCustomizeMaping<Frequency>
    {
        public FrequencyMap()
        {
            ToTable("frequency");

            Property(t => t.Name).HasColumnName("Name").IsRequired();
            Property(t => t.IsDefault).HasColumnName("IsDefault");
            Property(t => t.OrderNumber).HasColumnName("OrderNumber");
        }
    }
}
