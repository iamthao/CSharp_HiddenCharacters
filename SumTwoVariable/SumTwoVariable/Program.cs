using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DotLiquid;

namespace SumTwoVariable
{
    class Program
    {
        static void Main(string[] args)
        {
            PrameterData value = new PrameterData
            {
                name = "car",
                my_name = "Thao"
            };

            var text = "This is my <strong>{{name}}</strong>\nMy name is {{my_name}}";
            var data = (object) value;

            var content = FormatTemplateWithContentTemplate(System.Net.WebUtility.HtmlDecode(text), data);           
            Console.WriteLine(content);
            Console.ReadLine();
        }

        public class PrameterData
        {
            public string name { get; set; }
            public string my_name { get; set; }
        }

        public static string FormatTemplateWithContentTemplate(string contentTempalte, object data)
        {
            var template = Template.Parse(contentTempalte);
            return template.Render(Hash.FromAnonymousObject(data));

        }

    }


}
