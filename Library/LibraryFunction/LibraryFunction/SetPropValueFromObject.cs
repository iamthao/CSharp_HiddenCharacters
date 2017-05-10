using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryFunction
{
    public class SetPropValueFromObject
    {

        public static void SetPropValue(object src, string propName, object val)
        {
            src.GetType().GetProperty(propName).SetValue(src, val);
        }
    }
}
