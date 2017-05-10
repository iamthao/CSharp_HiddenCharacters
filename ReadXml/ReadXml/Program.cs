using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace ReadXml
{
    class Program
    {
        static void Main(string[] args)
        {
            Test[] test;
            // Create an instance of stream writer.
            TextReader txtReader = new StreamReader(@"D:\Tabular\Tabular.xml");
            // Create and instance of XmlSerializer class.
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(Test[]));
            // DeSerialize from the StreamReader
            test = (Test[])xmlSerializer.Deserialize(txtReader);
            Console.ReadLine();
        }

    }
}
