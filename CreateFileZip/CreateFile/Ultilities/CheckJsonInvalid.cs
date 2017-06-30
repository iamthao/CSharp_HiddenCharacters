using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Schema;

namespace CreateFile.Ultilities
{
    public static class CheckJsonInvalid
    {
        public static T TryParseJson<T>(this string json, string schema) where T : new()
        {
            JSchema parsedSchema = JSchema.Parse(schema);
            JObject jObject = JObject.Parse(json);

            return jObject.IsValid(parsedSchema) ?
                JsonConvert.DeserializeObject<T>(json) : default(T);
        }
    }
}
