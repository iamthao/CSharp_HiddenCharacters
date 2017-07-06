using PcstLib.Sqlite.Base;

namespace PcstLib.Sqlite.Entities
{
    public class County : Entity
    {
        public string Name { get; set; }
        public string Code { get; set; }
        public int StateId { get; set; }
    }
}
