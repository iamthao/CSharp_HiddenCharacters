using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace LibraryFunction
{
    class XmlDataHelpper
    {
        private static readonly string PathFile = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "FileUpload", "ConfigData",
            "SystemData.xml");

        private static readonly string MessageRegexReplaceItem = @"\[([^]]*)\]";

        private XmlDataHelpper()
        {
            _listAllData = new Dictionary<string, Dictionary<string, string>>();
            _listAllVersion = new Dictionary<string, Dictionary<string, string>>();
            var xmlDocument = XDocument.Load(PathFile);
            var root = xmlDocument.Root;
            if (root == null)
            {
                return;
            }
            foreach (var child in root.Elements())
            {
                var objAdd = new Dictionary<string, string>();
                var objVersion = new Dictionary<string, string>();
                foreach (var item in child.Elements())
                {
                    if (item.Attribute("value") != null)
                    {
                        objAdd.Add(item.Attribute("value").Value, item.Value);
                        if (item.Attribute("version") != null)
                        {
                            objVersion.Add(item.Attribute("value").Value, item.Attribute("version").Value);
                        }
                    }
                }
                _listAllData.Add(child.Name.ToString(), objAdd);
                _listAllVersion.Add(child.Name.ToString(), objVersion);
            }
        }

        public static XmlDataHelpper Instance
        {
            get { return Nested._instance; }
        }

        private class Nested
        {
            static Nested()
            {
            }

            internal static readonly XmlDataHelpper _instance = new XmlDataHelpper();
        }

        private static Dictionary<string, Dictionary<string, string>> _listAllData;
        private static Dictionary<string, Dictionary<string, string>> _listAllVersion;

        public Dictionary<string, string> GetData(string type)
        {
            if (_listAllData == null || _listAllData.Count == 0 || string.IsNullOrEmpty(type))
            {
                return new Dictionary<string, string>();
            }
            return !_listAllData.ContainsKey(type) ? new Dictionary<string, string>() : _listAllData[type];
        }

        public string GetValue(string type, string key)
        {
            if (string.IsNullOrEmpty(type) || string.IsNullOrEmpty(key) || !_listAllData.ContainsKey(type))
            {
                return "";
            }
            var objListItem = _listAllData[type];
            if (objListItem != null && objListItem.ContainsKey(key))
            {
                return objListItem[key];
            }
            return "";
        }
        public string GetVersion(string type, string key)
        {
            if (string.IsNullOrEmpty(type) || string.IsNullOrEmpty(key) || !_listAllVersion.ContainsKey(type))
            {
                return "";
            }
            var objListItem = _listAllVersion[type];
            if (objListItem != null && objListItem.ContainsKey(key))
            {
                return objListItem[key];
            }
            return "";
        }
    }
}
