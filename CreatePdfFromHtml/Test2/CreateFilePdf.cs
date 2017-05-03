using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using iTextSharp.text;
using iTextSharp.text.html;
using iTextSharp.text.html.simpleparser;
using iTextSharp.text.pdf;
using Font = iTextSharp.text.Font;

namespace Test2
{
    public class CreateFilePdf
    {
        public static string RunAction(string html,string path)
        {
            File.WriteAllBytes(path, GetPDF(html));
            return path;
        }

        public static byte[] GetPDF(string pHTML)
        {
            byte[] bPDF = null;

            MemoryStream ms = new MemoryStream();
            TextReader txtReader = new StringReader(pHTML);

            // 1: create object of a itextsharp document class
            Document doc = new Document(PageSize.A4, 25, 25, 25, 25);

            // 2: we create a itextsharp pdfwriter that listens to the document and directs a XML-stream to a file
            PdfWriter oPdfWriter = PdfWriter.GetInstance(doc, ms);

            // 3: we create a worker parse the document
            HTMLWorker htmlWorker = new HTMLWorker(doc);

            StyleSheet styles = new StyleSheet();
            //styles.LoadTagStyle("th", "face", "helvetica");
            //styles.LoadTagStyle("span", "size", "10px");
            //styles.LoadTagStyle("span", "face", "helvetica");
            //styles.LoadTagStyle("td", "size", "10px");
            styles.LoadTagStyle("body", HtmlTags.FONTFAMILY, "times-roman");
            htmlWorker.SetStyleSheet(styles);

            // 4: we open document and start the worker on the document
            doc.Open();
            htmlWorker.StartDocument();

            // 5: parse the html into the document
            htmlWorker.Parse(txtReader);

            // 6: close the document and the worker
            htmlWorker.EndDocument();
            htmlWorker.Close();
            doc.Close();

            bPDF = ms.ToArray();

            return bPDF;
        }
    }
}
