using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace ModifyWebconfig
{
    public class XmlLibrary
    {
        public static void ModifyXmlWebconfig()
        {
            string path = @"D:\\WebTest.config";
            XmlDocument doc = new XmlDocument();
            doc.Load(path);
            XmlNodeList elementList = doc.GetElementsByTagName("add");

            List<KeyValueChange> data = new List<KeyValueChange>
            {
                new KeyValueChange
                {
                    Key = "EmailContactUs",
                    Value = "thao.nguyen@caminois.com"
                },
                new KeyValueChange
                {
                    Key = "Url",
                    Value = "thaotest.com"
                }
            };

            for (int i = 0; i < elementList.Count; i++)
            {
                if (elementList[i].Attributes["key"] != null)
                {
                    var item = data.FirstOrDefault(o => o.Key == elementList[i].Attributes["key"].Value);
                    if (item != null)
                    {
                        elementList[i].Attributes["value"].Value = item.Value;
                        doc.Save(path);
                    }
                }
            }
        }

        public class KeyValueChange
        {
            public string Key { get; set; }
            public string Value { get; set; }
        }


        //
        public static void ReadXmlToList()
        {
            string path = @"D:\\SystemMessage.xml";//path to xml file

            XmlDocument doc = new XmlDocument();
            doc.Load(path);

            XmlNodeList elementList = doc.GetElementsByTagName("Message");
            for (int i = 0; i < elementList.Count; i++)
            {            
                for (int j = 0; j < elementList[i].ChildNodes.Count; j++)
                {
                    var a = elementList[i].ChildNodes[j];
                    if (a.Name == "Content")
                    {
                       Console.WriteLine("Content" + a.InnerText); 
                    }
                    if (a.Name == "Description")
                    {
                        Console.WriteLine("Description" + a.InnerText);
                    }
                }
            }
           
            //list.Add(node.InnerText);
        }
        
    }
}
