using PcstLib.Sqlite.Base;

namespace PcstLib.Sqlite.Entities
{
    public class Route :Entity
    {
        public string Name { get; set; }
        public bool IsDefault { get; set; }
        public int OrderNumber { get; set; }
    }
}
