//using System;
//using System.Collections.Generic;
//using System.IO;
//using System.Reflection;
//using System.Text;
//using System.Text.RegularExpressions;
//using System.Web;
//using System.Xml.Serialization;
//using DotLiquid.Tags;
//using Newtonsoft.Json;

//namespace LibraryFunction
//{
//    public class SerializationHelper
//    {
//        public static string SerializeToXml<T>(T obj)
//        {
//            var xmlSerializer = new XmlSerializer(typeof(T));
//            var stringBuilder = new StringBuilder();
//            using (TextWriter writer = new StringWriter(stringBuilder))
//            {
//                xmlSerializer.Serialize(writer, obj);
//            }

//            return stringBuilder.ToString();
//        }
//        public static T Deserialize<T>(string xmlInput)
//        {
//            if (string.IsNullOrEmpty(xmlInput))
//                return default(T);

//            var ser = new XmlSerializer(typeof(T));

//            using (var sr = new StringReader(xmlInput))
//                return (T)ser.Deserialize(sr);
//        }
//        public static string EncodeSerializeObject(object model)
//        {
//            //var json = Regex.Replace(JsonConvert.SerializeObject(model), @"\\\\|\\(""|')|(""|')", match =>
//            //{
//            //    if (match.Groups[1].Value == "\"") return "\\\""; // Unescape \"
//            //    if (match.Groups[2].Value == "'") return "\\'"; // Escape '
//            //    return match.Value;                             // Leave \\ and \' unchanged
//            //});
//            EncodeObject(model);
//            var json = JsonConvert.SerializeObject(model);
//            return json;
//        }
//        public static void EncodeObject(object model)
//        {
//            var myType = model.GetType();
//            var props = new List<PropertyInfo>(myType.GetProperties());
//            var regexItem = new Regex("^[a-zA-Z0-9 ]*$");

//            foreach (var prop in props)
//            {
//                try
//                {
//                    object propValue = prop.GetValue(model, null);
//                    if (propValue != null)
//                    {
//                        if (prop.PropertyType.Name == "String")
//                        {
//                            if (!string.IsNullOrEmpty(propValue.ToString().Trim()) && !regexItem.IsMatch(propValue.ToString()) && prop.SetMethod != null)
//                            {
//                                propValue = propValue.ToString().Replace("\\", "\\\\");
//                                prop.SetValue(model, HttpUtility.HtmlEncode(propValue));
//                            }
//                        }
//                        else
//                        {
//                            if (prop.PropertyType.BaseType != null && prop.PropertyType.BaseType.FullName == "System.Object")
//                            {
//                                EncodeObject(propValue);
//                            }
//                        }
//                    }
//                }
//                catch 
//                {
                    
//                }
//            }
//        }
//    }
//}
