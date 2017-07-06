using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Converters;

namespace PcstLib.Utility
{
    public class DefaultWrongFormatDeserialize : DateTimeConverterBase
    {
        public override object ReadJson(Newtonsoft.Json.JsonReader reader, Type objectType, object existingValue, Newtonsoft.Json.JsonSerializer serializer)
        {

            //if (reader.Value == null) return null;
            if (reader.Value == null && objectType == typeof(DateTime))
            {
                if (Nullable.GetUnderlyingType(objectType) != null) { return null; }
                else { return DateTime.MinValue; }
            }
            //DateTime result;

            //result = DateTime.TryParse(reader.Value.ToString(), out result) ? result : DateTime.MinValue;

            //if (reader.Value.ToString().Length > 10)
            //    return result.ToUniversalTime();

            //result = DateTime.SpecifyKind(result, DateTimeKind.Utc);

            //return result;

            if (reader.Value == null) return null;
            if (string.IsNullOrEmpty(reader.Value.ToString())) return null;
            DateTime result;
            return DateTime.TryParse(reader.Value.ToString(), out result) ? result : DateTime.MinValue;
        }

        public override void WriteJson(Newtonsoft.Json.JsonWriter writer, object value, Newtonsoft.Json.JsonSerializer serializer)
        {
            WriteJson(writer, value, serializer);
        }
    }
}
