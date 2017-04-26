using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using iTextSharp.text;
using iTextSharp.text.pdf;

namespace Test
{
    class Program
    {
        static void Main(string[] args)
        {
            var pathContent = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Content");
            var pathFile = Path.Combine(pathContent, "TestWritePdf.pdf");
            string oldFile = pathFile;

            var fileName = Guid.NewGuid().ToString("D") + ".pdf";
            //var fileName = "123.pdf";
            string pathNewFile = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "OutFile");
            string newFile = Path.Combine(pathNewFile, fileName);

            // open the reader
            PdfReader reader = new PdfReader(oldFile);
            Rectangle size = reader.GetPageSizeWithRotation(1);
            Document document = new Document(size);

            // open the writer
            FileStream fs = new FileStream(newFile, FileMode.Create, FileAccess.Write);
            PdfWriter writer = PdfWriter.GetInstance(document, fs);
            document.Open();

            // the pdf content
            PdfContentByte cb = writer.DirectContent;

            // select the font properties
            BaseFont bf = BaseFont.CreateFont(BaseFont.TIMES_ROMAN, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);
            cb.SetColorFill(BaseColor.BLACK);
            cb.SetFontAndSize(bf, 12);

            // write the text in the pdf content
            cb.BeginText();
            string text = "123-1456-7890";
            // put the alignment and coordinates here
            cb.ShowTextAligned(1, text, 110, 705, 0);
            cb.EndText();

            cb.BeginText();
            text = "Other random blabla...";
            // put the alignment and coordinates here
            cb.ShowTextAligned(2, text, 100, 200, 0);
            cb.EndText();

            // create the new page and add it to the pdf
            PdfImportedPage page = writer.GetImportedPage(reader, 1);
            cb.AddTemplate(page, 0, 0);

            // close the streams and voilá the file should be changed :)
            document.Close();
            fs.Close();
            writer.Close();
            reader.Close();

            Console.WriteLine("Success!!!");
            Console.ReadKey();
        }
    }
}
