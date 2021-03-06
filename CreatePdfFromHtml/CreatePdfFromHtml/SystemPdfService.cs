﻿using System;
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

        private static void _handleHeaderBodyFooter(string path, string htmlContent, string htmlFooter, string htmlHeader, string pagesShowHeader = null, string pagesShowFooter = null)
        {
            _pathTempSaveFile = path;
            var htmlDocumentHelper = new HtmlDocumentHelper(htmlContent);
            #region header
            if (!string.IsNullOrEmpty(htmlHeader) && !string.IsNullOrEmpty(htmlHeader.Trim()))
            {
                _headerContent = @"<!DOCTYPE html><html lang='en' xmlns='http://www.w3.org/1999/xhtml'>
                <head>
                    <meta http-equiv='Content-Type' content='text/html; charset=UTF-8'>      
                    <style>
                    thead{display: table-header-group;}
                    tfoot {display: table-row-group;}
                    tr {page-break-inside: avoid;}
                    </style>
                    <script>
                        function subst() {
                            var vars={};
                            var x=document.location.search.substring(1).split('&');
                            for (var i in x) {var z=x[i].split('=',2);vars[z[0]] = unescape(z[1]);}
                            var x=['frompage','topage','page','webpage','section','subsection','subsubsection'];
                            for (var i in x) {
                                var y = document.getElementsByClassName(x[i]);
                                for (var j=0; j<y.length; ++j) y[j].textContent = vars[x[i]];
                                ";
                if (!string.IsNullOrEmpty(pagesShowHeader))
                {
                    if (pagesShowHeader == "first")
                    {
                        _headerContent += @"if(vars['page'] != 1) { 
                                                    document.getElementById('header').style.display = 'none';
                                                }";
                    }
                    else
                    {
                        if (pagesShowHeader == "last")
                        {
                            _headerContent += @"if(vars['page'] != vars['topage']) { 
                                                    document.getElementById('header').style.display = 'none';
                                                }";
                        }
                        else
                        {
                            var arr = pagesShowHeader.Split(',');
                            if (arr.Length > 0)
                            {
                                for (var i = 0; i < arr.Length; i++)
                                {
                                    _headerContent += @"if(vars['page'] != " + arr[i] + @") { 
                                                    document.getElementById('header').style.display = 'none';
                                                }";
                                }
                            }
                        }
                    }
                }
                _headerContent += @"}
                        }
                        </script>
                    </head>
                    <body onload='subst()' style='overflow:hidden;padding:10px 0;'><div id='header'>" + htmlHeader + "</div></body></html>";
            }
            #endregion header
            #region footer
            if (!string.IsNullOrEmpty(htmlFooter) && !string.IsNullOrEmpty(htmlFooter.Trim()))
            {
                _footerContent = @"<!DOCTYPE html><html lang='en' xmlns='http://www.w3.org/1999/xhtml'>
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
                                                        ";
                if (!string.IsNullOrEmpty(pagesShowFooter))
                {
                    if (pagesShowFooter == "first")
                    {
                        _footerContent += @"if(vars['page'] != 1) { 
                                                                                            document.getElementById('footer').style.display = 'none';
                                                                                        }";
                    }
                    else
                    {
                        if (pagesShowFooter == "last")
                        {
                            _footerContent += @"if(vars['page'] != vars['topage']) { 
                                                                                            document.getElementById('footer').style.display = 'none';
                                                                                        }";
                        }
                        else
                        {
                            var arr = pagesShowFooter.Split(',');
                            if (arr.Length > 0)
                            {
                                for (var i = 0; i < arr.Length; i++)
                                {
                                    _footerContent += @"if(vars['page'] != " + arr[i] + @") { 
                                                                                            document.getElementById('footer').style.display = 'none';
                                                                                        }";
                                }
                            }
                        }
                    }
                }

                _footerContent += @"}
                                                }
                                            </script>
                                             </head>
                                            <body onload='subst()'><div >" + htmlFooter + "</div></body></html>";
                // _footerContent = _footerContentFormat;
            }
            #endregion footer
            #region content
            if (!string.IsNullOrEmpty(htmlContent) && !string.IsNullOrEmpty(htmlContent.Trim()))
            {
                _bodyContent = @"<!DOCTYPE html><html lang='en' xmlns='http://www.w3.org/1999/xhtml'>
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
                                             <body onload='subst()'><div id='content'>" + htmlContent + "</div></body></html>";
            }
            #endregion content
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
            var result = _exportToPath(desPath, content, !string.IsNullOrEmpty(footer) & !string.IsNullOrEmpty(footer.Trim()) ? footer : null,
                !string.IsNullOrEmpty(header) && !string.IsNullOrEmpty(header.Trim()) ? header : null, marginLeft: marginLeft, marginRigth: marginRigth,
                marginTop: marginTop, marginBottom: marginBottom);
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

        public static void ExportHtml(string path, string content)
        {
            SetUrl();

            HandleHeaderBodyFooter(path, content, "footer");

            Export();
        }

        private static void SetUrl()
        {
            var result = "file:///";
            var pathRoot = AppDomain.CurrentDomain.BaseDirectory;
            result += pathRoot.Replace("\\", "/");
            _url = result;
        }

        private static void HandleHeaderBodyFooter(string path, string htmlContent, string idFooter, string idHeader = null)
        {
            _pathTempSaveFile = path;
            var htmlDocumentHelper = new HtmlDocumentHelper(htmlContent);

            //TODO: do not handle for Header.
            _headerContent = "Thao Header";

            if (!string.IsNullOrEmpty(_url))
            {
                htmlDocumentHelper.MergeUrlOnImage(_url);
            }


            if (!string.IsNullOrEmpty(idFooter))
            {
                _footerContent = htmlDocumentHelper.GetContentById(idFooter);
            }

            _bodyContent = htmlDocumentHelper.RemoveContentById(idFooter);

        }

        private static void Export(bool isLandscape = false)
        {
            using (var pdf = new ExportPdfProvider(_pathTempSaveFile))
            {
                pdf.ConfigPdfFile("A4", 5, 5, 5, 18);
                //apply page number
                var footer = _footerContentFormat.Replace("istFooterPageSize", _footerContent);
                _pathTempSaveFile = pdf.Export(_bodyContent, _headerContent, footer, isLandscape);
            }
        }

        private static string _footerContentFormat = @"<!DOCTYPE html>
                                        <html lang='en' xmlns='http://www.w3.org/1999/xhtml'>
                                        <head>
                                            <meta charset='utf-8' />
                                            <title></title>                                            
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
                                        <body onload='subst()'>
                                            <div style='float:right;font-size: 11px;'>Page <span style='font-weight: 900;' class='page'></span> of <span  style='font-weight: 900;' class='topage'></span></div>
                                        </body>
                                        </html>";
    }
}
