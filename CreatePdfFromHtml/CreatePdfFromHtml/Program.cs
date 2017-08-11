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
            

            // Set Full path
            var start = DateTime.Now;
            Console.WriteLine(start.ToString("yyyy-MM-dd HH:mm:ss") +" Start");

            var marginBottom = 20;//modify
            var marginTop = 43;//modify 37
            var marginLeft = 12;
            var marginRight = 12;

            object data = GetDataForTemplate();

            var pathContent = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Content");
            var contentNoData = File.ReadAllText(Path.Combine(pathContent, "content.html"), Encoding.UTF8);
            var headerNoData = File.ReadAllText(Path.Combine(pathContent, "header.html"), Encoding.UTF8);
            var footerNoData = File.ReadAllText(Path.Combine(pathContent, "footer.html"), Encoding.UTF8);

            var header = TemplateHelpper.FormatTemplateWithContentTemplate(HttpUtility.HtmlDecode(headerNoData), data);
            var footer = TemplateHelpper.FormatTemplateWithContentTemplate(HttpUtility.HtmlDecode(footerNoData), data);
            var content = TemplateHelpper.FormatTemplateWithContentTemplate(HttpUtility.HtmlDecode(contentNoData), data);

            //----Start-------
            var fileNameSave = Guid.NewGuid().ToString("D") + ".pdf";
            var localPath = ConfigurationManager.AppSettings["LocalPath"];
            string destPath = Path.Combine(localPath, fileNameSave);
            SystemPdfService.ExportPdfWithHeaderFooter(destPath, content, header, footer, marginTop: marginTop,
                marginBottom: marginBottom, marginLeft: marginLeft, marginRigth: marginRight);

            //SystemPdfService.ExportHtml(destPath, content);
            //-------------End--------

            //var listFile = new List<byte[]>();
            //for (int i = 0; i < 2; i++)
            //{
            //    var start1 = DateTime.Now;
            //    var fileNameSave = Guid.NewGuid().ToString("D") + ".pdf";
            //    var localPath = ConfigurationManager.AppSettings["LocalPath"];
            //    string destPath = Path.Combine(localPath, fileNameSave);

            //    listFile.Add(GetByteFromFile(SystemPdfService.ExportPdfWithHeaderFooter(destPath, content, header, footer, marginTop: marginTop,
            //    marginBottom: marginBottom, marginLeft: marginLeft, marginRigth: marginRight)));

            //    var end1 = DateTime.Now;
            //    Console.WriteLine("Template " + (i + 1) + " : " + (end1 - start1).TotalSeconds);
            //}

            //var fileNameSaveDes = Guid.NewGuid().ToString("D") + ".pdf";
            //var localPathDes = ConfigurationManager.AppSettings["LocalPath"];
            //var pathResult = Path.Combine(localPathDes, fileNameSaveDes);

            //var bytesResult = MergePdf.CombineMultiplePdfsByByte(listFile);
            //File.WriteAllBytes(pathResult, bytesResult);

            var end = DateTime.Now;
            Console.WriteLine(end.ToString("yyyy-MM-dd HH:mm:ss") + " End");
            Console.WriteLine("Success!!!" + ReturnStringHour((end - start).TotalSeconds));
            Console.ReadLine();
        }

        private static object GetDataForTemplate()
        {
            return new
            {
                img_logo1 = "http://libris-staging.caminois.com/Content/images/LibertyHealthcareLogo.png",
                img_translationbox = "http://libris-staging.caminois.com/Content/images/translationbox.png",
                member_mid = "123-456-7890",
                member_name = "Thao Nguyen",
                member_address1 = "205 Nguyen Xi",
                member_address2 = "Tang 9",
                member_city = "HCM",
                member_state = "TX",
                member_zip = "77014",
                created_date = DateTime.Now.ToShortDateString(),
                customer_support_specialist = "Thao Support",
                document_number = "DOC00002"
            };
        }

        public static byte[] GetByteFromFile(string path)
        {
            return System.IO.File.ReadAllBytes(path);
        }

        public static string ReturnStringHour(double second)
        {
            TimeSpan time = TimeSpan.FromSeconds(second);

            //here backslash is must to tell that colon is
            //not the part of format, it just a character that we want in output
            return time.ToString(@"hh\:mm\:ss");
        }
    }
}
