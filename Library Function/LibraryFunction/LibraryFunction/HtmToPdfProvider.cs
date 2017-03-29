using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryFunction
{
    public class HtmToPdfProvider
    {
        private string _pathCombine;

        #region Function Export Pdf

        private string GetFormatContentHtml(string htmlContent)
        {
            return "<html> " + "<head>" + "<style type=\"text/css\">" + ContentCss + "</style>" + "</head>" + "<body>" +
                   htmlContent + "</body>" + "</html>";
        }

        private string GetContentFileCss(IEnumerable<string> pathFilePdf)
        {
            if (pathFilePdf != null)
            {
                return pathFilePdf.Aggregate("", (current, s) => current + ReadFileCss(s));
            }
            return "";
        }

        private void WritePdf()
        {
            var psi = new ProcessStartInfo();

            if (!Directory.Exists(PathStore))
            {
                Directory.CreateDirectory(PathStore);
            }

            // run the conversion utility
            psi.UseShellExecute = false;
            var settingsReader = new AppSettingsReader();
            psi.FileName = (string)settingsReader.GetValue("ExportHtmlToPdfFile", typeof(String));
            psi.CreateNoWindow = true;
            psi.RedirectStandardInput = true;
            psi.RedirectStandardOutput = true;
            psi.RedirectStandardError = true;

            // note that we tell wkhtmltopdf to be quiet and not run scripts
            // NOTE: I couldn't figure out a way to get both stdin and stdout redirected so we have to write to a file and then clean up afterwards
            psi.Arguments = "--footer-center [page]/[topage] -q -n -s A4 - " + Path.Combine(PathStore, FileName);

            var p = Process.Start(psi);

            try
            {
                if (p != null)
                {
                    var stdin = p.StandardInput;
                    stdin.AutoFlush = true;

                    stdin.Write(HtmlContent);
                    stdin.Close();
                }

                if (p != null && p.WaitForExit(15000))
                {
                }
            }
            finally
            {
                if (p != null)
                {
                    p.Close();
                    p.Dispose();
                }
            }
        }

        #endregion

        #region Extention

        private string GetPathFile()
        {
            if (File.Exists(_pathCombine))
            {
                return _pathCombine;
            }
            return null;
        }

        private string ReadFileCss(string path)
        {
            if (File.Exists(path))
            {
                return File.ReadAllText(path);
            }
            return "";
        }

        #endregion Extention

        public string PathStore { get; set; }
        public string FileName { get; set; }
        public string HtmlContent { get; set; }
        public string ContentCss { get; private set; }
        public IEnumerable<string> PathFileCss { get; set; }

        public void Dispose()
        {
            HtmlContent = null;
            PathStore = null;
            FileName = null;
        }

        public string Export(string pathStore, string fileName, string htmlContent, params string[] pathFileCss)
        {
            PathStore = pathStore;
            string extension = Path.GetExtension(fileName);
            if (extension != null && extension.ToLower() == ".pdf")
            {
                FileName = fileName;
            }
            else
            {
                FileName = fileName + ".pdf";
            }
            _pathCombine = Path.Combine(PathStore, FileName);
            PathFileCss = pathFileCss;
            ContentCss = GetContentFileCss(pathFileCss);
            HtmlContent = GetFormatContentHtml(htmlContent);
            WritePdf();
            return GetPathFile();
        }

    }
}
