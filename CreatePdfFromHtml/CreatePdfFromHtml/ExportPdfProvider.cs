using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.Drawing.Printing;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using iTextSharp.text;

namespace CreatePdfFromHtml
{
    public class ExportPdfProvider : IDisposable
    {
        private readonly string _pathApplicationExport;
        private readonly string _destinationSaveFilePdf;

        private string _contentHtml;

        private string _pathHeaderTemp;
        private string _pathFooterTemp;
        private string _pathContentTemp;

        private string _argument;
        private string _pageSize;
        private string _marginLeft;
        private string _marginRigth;
        private string _marginTop;
        private string _marginBottom;

        private string _header;
        private string _footer;

        private bool _landscape = false;

        public ExportPdfProvider(string destinationSaveFilePdf)
        {
            _pathApplicationExport = ConfigurationManager.AppSettings["ExportHtmlToPdfFile"];
            _destinationSaveFilePdf = destinationSaveFilePdf;
        }

        public string Export(string contentHtml, string headerHtml, string footerHtml, bool landscape = false)
        {
            _landscape = landscape;
            SetHeader(headerHtml);
            SetFooter(footerHtml);
            SetContent(contentHtml);
            SetArgumentForExport();
            WritePdf();
            return File.Exists(_destinationSaveFilePdf) ? _destinationSaveFilePdf : null;
        }

        #region Configuration Export

        /// <summary>
        /// Set page setup
        /// </summary>
        /// <param name="pageSize">Defaul "A4"</param>
        /// <param name="marginLeft">float type: margin Left page</param>
        /// <param name="marginRigth">float type: margin Rigth page</param>
        /// <param name="marginTop">float type: margin Top page</param>
        /// <param name="marginBottom">float type: margin Bottom page, if you set footer, set margin bottom > 20.0</param>
        public void ConfigPdfFile(string pageSize = "A4", float? marginLeft = null, float? marginRigth = null,
            float? marginTop = null, float? marginBottom = null)
        {
            _pageSize = string.Format(" --page-size {0} ", pageSize);
            _marginLeft = marginLeft == null ? "" : string.Format(" --margin-left {0}mm ", marginLeft);
            _marginRigth = marginRigth == null ? "" : string.Format(" --margin-right {0}mm ", marginRigth);
            _marginTop = marginTop == null ? "" : string.Format(" --margin-top {0}mm ", marginTop);
            _marginBottom = marginBottom == null ? "" : string.Format(" --margin-bottom {0}mm ", marginBottom);
        }

        private void SetArgumentForExport()
        {
            _argument = " --encoding utf-8 " + (_landscape ? " --orientation Landscape " : "") + _pageSize + _marginLeft + _marginRigth + _marginTop + _marginBottom + _header + _footer;
        }

        /// <summary>
        /// Write content Html footer to temp file and set configuration
        /// </summary>
        /// <param name="footerHtml"></param>
        public void SetFooter(string footerHtml)
        {
            _pathFooterTemp = Path.Combine(Path.GetTempPath(), Guid.NewGuid().ToString().Replace("-", "") + ".html");
            _footer = WriteHtml(_pathFooterTemp, footerHtml)
                ? " --footer-html " + _pathFooterTemp.Replace("\\", "/") + " "
                : "";
            //_footer = WriteHtml(_pathFooterTemp, footerHtml) ? " --header-html " + _pathFooterTemp.Replace("\\", "/") + " " : "";
        }

        /// <summary>
        /// Write content Html header to temp file and set configuration
        /// </summary>
        /// <param name="headerHtml"></param>
        public void SetHeader(string headerHtml)
        {
            if (!string.IsNullOrEmpty(headerHtml))
            {
                _pathHeaderTemp = Path.Combine(Path.GetTempPath(), Guid.NewGuid().ToString().Replace("-", "") + ".html");
                _header = WriteHtml(_pathHeaderTemp, headerHtml)
                    ? " --header-spacing 3 --header-html " + _pathHeaderTemp.Replace("\\", "/") + " "
                    : "";
            }
            else
            {
                _header = "";
            }

        }

        public void SetContent(string contentHtml)
        {
            _contentHtml = contentHtml;
        }

        private static bool WriteHtml(string path, string content)
        {
            try
            {
                using (var sw = new StreamWriter(path, false))
                {
                    sw.Write(content);
                    return true;
                }
            }
            catch (Exception)
            {
                return false;
            }

        }

        #endregion

        private void WritePdf()
        {
            var psi = new ProcessStartInfo
            {
                UseShellExecute = false,
                FileName = _pathApplicationExport,
                CreateNoWindow = true,
                RedirectStandardInput = true,
                RedirectStandardOutput = true,
                RedirectStandardError = true,
                Arguments = _argument + " -q -n - " + _destinationSaveFilePdf
            };

            // run the conversion utility


            // note that we tell wkhtmltopdf to be quiet and not run scripts
            // NOTE: I couldn't figure out a way to get both stdin and stdout redirected so we have to write to a file and then clean up afterwardspsi.Arguments = _argument + "-q -n - " + _destinationSaveFilePdf;
            var p = Process.Start(psi);

            try
            {
                if (p != null)
                {
                    var stdin = new StreamWriter(p.StandardInput.BaseStream, Encoding.UTF8) { AutoFlush = true };
                    stdin.Write(_contentHtml);

                    stdin.Close();
                }

                if (p != null && p.WaitForExit(60000))
                {

                }


            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {
                if (File.Exists(_pathFooterTemp))
                {
                    File.Delete(_pathFooterTemp);
                }
                if (File.Exists(_pathHeaderTemp))
                {
                    File.Delete(_pathHeaderTemp);
                }
                if (File.Exists(_pathContentTemp))
                {
                    File.Delete(_pathContentTemp);
                }
                if (p != null)
                {
                    p.Close();
                    p.Dispose();
                }
            }
        }
        public void WritePdfWithMultiContentHeaderFooter(List<PdfObject> list)
        {
            if (list.Any())
            {

                var argument = " --encoding utf-8 " + _pageSize + _marginLeft + _marginRigth + _marginTop + _marginBottom;
                var content = "";
                var listTemp = new List<string>();
                foreach (var item in list)
                {
                    var header = "";
                    var footer = "";
                    if (!string.IsNullOrEmpty(item.Header) && !string.IsNullOrEmpty(item.Header.Trim()))
                    {
                        header = @"<!DOCTYPE html><html lang='en' xmlns='http://www.w3.org/1999/xhtml'>
                                             <head>
                                            <meta http-equiv='Content-Type' content='text/html; charset=UTF-8'>      
                                            <style>
                                            thead{display: table-header-group;}
                                            tfoot {display: table-row-group;}
                                            tr {page-break-inside: avoid;}
                                            </style>
                                             </head>
                                             <body style='overflow:hidden;padding:10px 0;'>" + item.Header + "</body></html>";
                    }
                    if (!string.IsNullOrEmpty(item.Footer) && !string.IsNullOrEmpty(item.Footer.Trim()))
                    {
                        footer = @"<!DOCTYPE html><html lang='en' xmlns='http://www.w3.org/1999/xhtml'>
                                             <head>
                                            <meta http-equiv='Content-Type' content='text/html; charset=UTF-8'>                                           
                                            <script>
                                            function subst() {
                                            var vars={};
                                            var x=window.location.search.substring(1).split('&');
                                            for (var i in x) {var z=x[i].split('=',2);vars[z[0]] = unescape(z[1]);}
                                            var x=['frompage','topage','page','webpage','section','subsection','subsubsection'];
                                            for (var i in x) {
                                                var y = document.getElementsByClassName(x[i]);
                                                for (var j=0; j<y.length; ++j) y[j].textContent = vars[x[i]];
                                            }
                                            }
                                            </script>
                                             </head>
                                             <body onload='subst()'>" + item.Footer + "</body></html>";
                    }

                    var pathHeaderTemp = Path.Combine(Path.GetTempPath(), Guid.NewGuid().ToString().Replace("-", "") + ".html");
                    var headerHtml = WriteHtml(pathHeaderTemp, header)
                        ? " --header-spacing 3 --header-html " + pathHeaderTemp.Replace("\\", "/") + " "
                        : "";

                    var pathFooterTemp = Path.Combine(Path.GetTempPath(), Guid.NewGuid().ToString().Replace("-", "") + ".html");
                    var footerHtml = WriteHtml(pathFooterTemp, footer)
                        ? " --footer-html " + pathFooterTemp.Replace("\\", "/") + " "
                        : "";

                    var pathContentTemp = Path.Combine(Path.GetTempPath(), Guid.NewGuid().ToString().Replace("-", "") + ".html");
                    var contentHtml = WriteHtml(pathContentTemp, item.Content)
                        ? pathContentTemp.Replace("\\", "/") + " "
                        : "";
                    content += contentHtml + headerHtml + footerHtml;
                    listTemp.Add(pathHeaderTemp);
                    listTemp.Add(pathFooterTemp);
                    listTemp.Add(pathContentTemp);
                }
                argument += content;
                var p = new System.Diagnostics.Process()
                {
                    StartInfo =
                    {
                        FileName = _pathApplicationExport,
                        Arguments = argument + _destinationSaveFilePdf,
                        UseShellExecute = false, // needs to be false in order to redirect output
                        CreateNoWindow = true,
                        //RedirectStandardOutput = true,
                        //RedirectStandardError = true,
                        //RedirectStandardInput = true // redirect all 3, as it should be all 3 or none
                    }
                };

                try
                {
                    p.Start();
                    // ...then wait n milliseconds for exit (as after exit, it can't read the output)
                    p.WaitForExit(10000);
                }
                catch (Exception ex)
                {
                    throw;
                }
                finally
                {
                    if (listTemp.Any())
                    {
                        foreach (var temp in listTemp)
                        {

                            if (File.Exists(temp))
                            {
                                File.Delete(temp);
                            }
                        }
                    }
                    p.Close();
                    p.Dispose();
                }
            }
        }
        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }

    public class PdfObject
    {
        public string Header { get; set; }
        public string Content { get; set; }
        public string Footer { get; set; }
    }
}
