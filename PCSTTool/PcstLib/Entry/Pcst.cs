using System;

namespace PcstLib.Entry
{
    public class PcstEntry
    {
        public int Id { get; set; }
        public string FileName { get; set; }
        public string FilePath { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime ModifiedOn { get; set; }
        public bool IsSystem { get; set; }
    }
}
