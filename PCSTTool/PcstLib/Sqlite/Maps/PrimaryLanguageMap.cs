using PcstLib.Sqlite.Base;
using PcstLib.Sqlite.Entities;

namespace PcstLib.Sqlite.Maps
{
    public class PrimaryLanguageMap : SqliteCustomizeMaping<PrimaryLanguage>
    {
        public PrimaryLanguageMap()
        {
            ToTable("primarylanguage");
            Property(s => s.Name).HasColumnName("Name");
            Property(s => s.LanguageCodes).HasColumnName("LanguageCodes");
            Property(s => s.IsDefault).HasColumnName("IsDefault");
        }
    }
}
