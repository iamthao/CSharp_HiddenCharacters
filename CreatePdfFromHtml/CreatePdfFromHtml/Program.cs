using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using Test2;

namespace CreatePdfFromHtml
{
    class Program
    {
        static void Main(string[] args)
        {
            var fileNameSave = Guid.NewGuid().ToString("D") + ".pdf";
            var localPath = ConfigurationManager.AppSettings["LocalPath"];

            // Set Full path
            string destPath = Path.Combine(localPath, fileNameSave);
            var marginBottom = 45;
            var marginTop = 45;
            var marginLeft = 24;
            var marginRight = 24;

            object data = GetDataForTemplate();

            var pathContent = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Content");
            var contentNoData = File.ReadAllText(Path.Combine(pathContent, "content.html"), Encoding.UTF8);
            var headerNoData = File.ReadAllText(Path.Combine(pathContent, "header.html"), Encoding.UTF8);
            var footerNoData = File.ReadAllText(Path.Combine(pathContent, "footer.html"), Encoding.UTF8);

            var header = TemplateHelpper.FormatTemplateWithContentTemplate(HttpUtility.HtmlDecode(headerNoData), data);
            var footer = TemplateHelpper.FormatTemplateWithContentTemplate(HttpUtility.HtmlDecode(footerNoData), data);
            var content = TemplateHelpper.FormatTemplateWithContentTemplate(HttpUtility.HtmlDecode(contentNoData), data);
           
            //SystemPdfService.ExportPdfWithHeaderFooter(destPath, content, header, footer, marginTop: marginTop,
            //    marginBottom: marginBottom, marginLeft: marginLeft, marginRigth: marginRight);

            CreateFilePdf.RunAction(content, destPath);

            Console.WriteLine("Success!!!");
            Console.ReadLine();
        }

        private static object GetDataForTemplate()
        {
           return new
            {
                img_logo1 = "http://libris-staging.caminois.com/Content/images/LibertyHealthcareLogo.png",
                img_translationbox = "http://libris-staging.caminois.com/Content/images/translationbox.png",
                member_mid =string.Concat(Enumerable.Repeat("_",12)),//"123-456-7890",
                member_name = string.Concat(Enumerable.Repeat("_", 20)),//"Thao Nguyen",
                member_address1 = string.Concat(Enumerable.Repeat("_", 20)),//"205 Nguyen Xi",
                member_address2 = string.Concat(Enumerable.Repeat("_", 15)),//"Tang 9",
                member_city = string.Concat(Enumerable.Repeat("_", 15)),//"HCM",
                member_state = string.Concat(Enumerable.Repeat("_", 2)),//"TX",
                member_zip = string.Concat(Enumerable.Repeat("_", 5)),//"77014",
            };
        }

      
    }
}
