using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Management;
using iTextSharp.text;
using iTextSharp.text.pdf;


namespace Test
{
    class Program
    {
        static void Main(string[] args)
        {
            var listFileByte = new List<byte[]>();
            var listFile = new List<string> { @"D:\TestCallPdf\1.pdf", @"D:\TestCallPdf\2.pdf" };

            string fileName = Guid.NewGuid().ToString().Replace("-", "") + ".pdf";
            var pathResult = Path.Combine(@"D:\TestCallPdf\", fileName);
            Merge(listFile, pathResult);

            //foreach (var item in listFile)
            //{
            //    listFileByte.Add(GetByteFromFile(item));
            //}

            //var bytesResult = MergePdf.CombineMultiplePdfsByByte(listFileByte);
            
            
            //System.IO.File.WriteAllBytes(pathResult, bytesResult);

            Console.WriteLine("Success!!!");
            Console.ReadKey();
        }

        private static void SendToPrinter()
        {
            ProcessStartInfo info = new ProcessStartInfo(@"D:\pdf-test.pdf");
            info.Verb = "PrintTo";
            info.Arguments = "\"Foxit PhantomPDF Printer\"";
            info.CreateNoWindow = true;
            info.WindowStyle = ProcessWindowStyle.Hidden;
            Process.Start(info);
        }

        public static byte[] GetByteFromFile(string path)
        {
            return System.IO.File.ReadAllBytes(path);
        }

        public static void Merge(List<String> InFiles, String OutFile)
        {
            using (FileStream stream = new FileStream(OutFile, FileMode.Create))
            using (Document doc = new Document())
            using (PdfCopy pdf = new PdfCopy(doc, stream))
            {
                doc.Open();

                PdfReader reader = null;
                PdfImportedPage page = null;

                //fixed typo
                InFiles.ForEach(file =>
                {
                    reader = new PdfReader(file);

                    for (int i = 0; i < reader.NumberOfPages; i++)
                    {
                        page = pdf.GetImportedPage(reader, i + 1);
                        pdf.AddPage(page);
                    }

                    pdf.FreeReader(reader);
                    reader.Close();
                });
            }
        }
    }
}
