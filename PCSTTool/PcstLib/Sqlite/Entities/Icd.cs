using System.ComponentModel;
using PcstLib.Sqlite.Base;

namespace PcstLib.Sqlite.Entities
{
    public enum IcdType
    {
        [Description("ICD9")]
        ICD9 = 1,
        [Description("ICD10")]
        ICD10 = 2
    }

    public class Icd : Entity
    {
        public string Code { get; set; }
        public string Description { get; set; }
        public IcdType IcdType { get; set; }
    }
}
