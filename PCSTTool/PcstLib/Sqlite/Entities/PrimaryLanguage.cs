using PcstLib.Sqlite.Base;

namespace PcstLib.Sqlite.Entities
{
    public class PrimaryLanguage : Entity
    {
        public string Name { get; set; }
        public string LanguageCodes { get; set; }
        public bool IsDefault { get; set; }
    }
}
