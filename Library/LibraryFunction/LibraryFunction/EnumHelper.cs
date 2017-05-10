using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryFunction
{
    class EnumHelper
    {
        public static string GetNameByValue<TEnum>( int value) where TEnum : struct, IConvertible, IComparable, IFormattable
        {
            if (!typeof(TEnum).IsEnum)
            {
                throw new ArgumentException("TEnum must be an enum.");
            }
            return Enum.GetName(typeof(TEnum), value);
        }

        public static string GetDescription( Enum value)
        {
            var field = value.GetType().GetField(value.ToString());
            if (field == null)
                return "";
            var attribute
                    = Attribute.GetCustomAttribute(field, typeof(DescriptionAttribute))
                        as DescriptionAttribute;
            return attribute == null ? value.ToString() : attribute.Description;
        }
        public static string GetVersion( Enum value)
        {
            var intValue = (int)Enum.Parse(value.GetType(), value.ToString());
            return XmlDataHelpper.Instance.GetVersion(value.GetType().Name, intValue.ToString());
        }
    }
}
