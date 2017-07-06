using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PcstLib.Sqlite.ValueObject
{
    public enum RequestType
    {
        [Description("Initial")]
        Initial = 1,
        [Description("Expedited")]
        Expedited = 2,
        [Description("Change Of Status")]
        ChangeOfStatus = 3,
        [Description("Change Of Provider")]
        ChangeOfProvider = 4,
        [Description("Continuation")]
        Continuation = 5,
    }
}
