using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryFunction
{
    public class CompareDateTime
    {
        /// <summary>
        /// Conpare datetime
        /// </summary>
        /// <param name="d1">destination</param>
        /// <param name="d2">source</param>
        /// <param name="format">foramt datetime</param>
        /// <returns>-1 is d2 > d1, 0 is d1 = d2, 1 is d1 > d2. </returns>
        public static int CompareDateTimeStr( DateTime d1, DateTime d2, string format = "MM/dd/yyyy HH:mm")
        {
            if (string.IsNullOrEmpty(format))
            {
                throw new Exception("Format invalid.");
            }

            var dr1 = DateTime.ParseExact(d1.ToString(format), format, CultureInfo.InvariantCulture);
            var dr2 = DateTime.ParseExact(d2.ToString(format), format, CultureInfo.InvariantCulture);
            return dr1 > dr2 ? 1 : dr2 > dr1 ? -1 : 0;
        }

    }
}
