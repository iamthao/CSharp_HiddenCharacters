using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreatePdfFromHtml
{
    public class SystemPdfService
    {
        private static string _url = string.Empty;
        private readonly string _tempPath = Path.GetTempPath();
        private static string _pathTempSaveFile;
        private static string _headerContent;
        private static string _bodyContent;
        private static string _footerContent;
        private readonly string htmlFormat = @"<!DOCTYPE html><html lang='en' xmlns='http://www.w3.org/1999/xhtml'>
                                             <head>
                                             <link href='" + ConfigurationManager.AppSettings["Url"] + @"Content/bootstrap.css' rel='stylesheet'>
                                            <style>@font-face {
                                                font-family: 'Alice_5';
                                                src: url('" + ConfigurationManager.AppSettings["Url"] + @"Content/fonts/alice.ttf') format('truetype');
                                            }
                                            </style>
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
                                             <body onload='subst()'>{0}</body></html>";

        public static string _exportToPath(string path, string htmlContent, string htmlFooter = null, string htmlHeader = null, bool isLandscape = false, float? marginLeft = 5, float? marginRigth = 5,
            float? marginTop = 5, float? marginBottom = 18)
        {
            _setUrl();

            _handleHeaderBodyFooter(path, htmlContent, htmlFooter, htmlHeader);

            _export(marginLeft: marginLeft, marginRigth: marginRigth, marginTop: marginTop, marginBottom: marginBottom);

            if (File.Exists(_pathTempSaveFile))
            {
                return _pathTempSaveFile;
            }
            return null;
        }

        //set url for file
        private static void _setUrl()
        {
            var result = "file:///";
            var pathRoot = AppDomain.CurrentDomain.BaseDirectory;
            result += AppDomain.CurrentDomain.BaseDirectory.Replace("\\", "/");
            _url = result;
        }

        private static void _handleHeaderBodyFooter(string path, string htmlContent, string htmlFooter, string htmlHeader)
        {
            _pathTempSaveFile = path;
//            var htmlDocumentHelper = new HtmlDocumentHelper(htmlContent);

//            if (!string.IsNullOrEmpty(htmlHeader) && !string.IsNullOrEmpty(htmlHeader.Trim()))
//            {
//                _headerContent = @"<!DOCTYPE html><html lang='en' xmlns='http://www.w3.org/1999/xhtml'>
//                                             <head>
//                                            <meta http-equiv='Content-Type' content='text/html; charset=UTF-8'>      
//                                            <style>
//                                            thead{display: table-header-group;}
//                                            tfoot {display: table-row-group;}
//                                            tr {page-break-inside: avoid;}
//                                            </style>
//                                             </head>
//                                             <body style='overflow:hidden;padding:10px 0;'>" + htmlHeader + "</body></html>";
//            }
//            if (!string.IsNullOrEmpty(htmlFooter) && !string.IsNullOrEmpty(htmlFooter.Trim()))
//            {
//                _footerContent = @"<!DOCTYPE html><html lang='en' xmlns='http://www.w3.org/1999/xhtml'>
//                                             <head>
//                                            <meta http-equiv='Content-Type' content='text/html; charset=UTF-8'>                                           
//                                            <script>
//                                            function subst() {
//                                            var vars={};
//                                            var x=window.location.search.substring(1).split('&');
//                                            for (var i in x) {var z=x[i].split('=',2);vars[z[0]] = unescape(z[1]);}
//                                            var x=['frompage','topage','page','webpage','section','subsection','subsubsection'];
//                                            for (var i in x) {
//                                                var y = document.getElementsByClassName(x[i]);
//                                                for (var j=0; j<y.length; ++j) y[j].textContent = vars[x[i]];
//                                            }
//                                            }
//                                            </script>
//                                             </head>
//                                             <body onload='subst()'>" + htmlFooter + "</body></html>";
//            }

//            _bodyContent = htmlContent;
        }

        private static void _export(bool isLandscape = false, float? marginLeft = 5, float? marginRigth = 5,
            float? marginTop = 5, float? marginBottom = 18)
        {
            using (var pdf = new ExportPdfProvider(_pathTempSaveFile))
            {
                pdf.ConfigPdfFile("A4", marginLeft, marginRigth, marginTop, marginBottom);
                _pathTempSaveFile = pdf.Export(_bodyContent, _headerContent, _footerContent, isLandscape);
            }
        }

        public static string ExportPdf(string desPath, string content)
        {
            var result = _exportToPath(desPath, content);
            return result;
        }

        public static string ExportPdf(string desPath, string content, float? marginLeft = 5, float? marginRigth = 5,
                    float? marginTop = 5, float? marginBottom = 18)
        {
            var result = _exportToPath(desPath, content, marginLeft: marginLeft, marginRigth: marginRigth, marginTop: marginTop, marginBottom: marginBottom);
            return result;
        }
        public static string ExportPdfNonHeaderFooter(string desPath, string content, float? marginLeft = 23, float? marginRigth = 23,
            float? marginTop = 45, float? marginBottom = 25)
        {
            var result = _exportToPath(desPath, content, marginLeft: marginLeft, marginRigth: marginRigth, marginTop: marginTop, marginBottom: marginBottom);
            return result;
        }
        public static string ExportPdfWithHeaderFooter(string desPath, string content, string header, string footer, float? marginLeft = 23, float? marginRigth = 23,
            float? marginTop = 45, float? marginBottom = 25)
        {
            var result = _exportToPath(desPath, content, !string.IsNullOrEmpty(footer) && !string.IsNullOrEmpty(footer.Trim()) ? footer : null, !string.IsNullOrEmpty(header) && !string.IsNullOrEmpty(header.Trim()) ? header : null, marginLeft: marginLeft, marginRigth: marginRigth, marginTop: marginTop, marginBottom: marginBottom);
            return result;
        }
        public static string ExportPdfWithMultiContentWithMultiHeaderFooter(string desPath, List<PdfObject> list, float? marginLeft = 24, float? marginRigth = 24,
           float? marginTop = 45, float? marginBottom = 45)
        {
            _setUrl();
            _pathTempSaveFile = desPath;
            using (var pdf = new ExportPdfProvider(_pathTempSaveFile))
            {
                pdf.ConfigPdfFile("A4", marginLeft, marginRigth, marginTop, marginBottom);
                pdf.WritePdfWithMultiContentHeaderFooter(list);
            }

            if (File.Exists(desPath))
            {
                return desPath;
            }
            return null;
        }
    }
}
