using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Text;
using System.Web;
using DotLiquid;

namespace PcstLib.Utility
{
    public sealed class TemplateHelpper
    {
        /// <summary>
        /// Load a template from file
        /// </summary>
        /// <param name="path">Path to template file (Absolute or related)</param>
        /// <param name="isVirtualPath">Is your specified path a virtual ?</param>
        /// <returns>Return loaded template</returns>
        public static Template LoadTemplate(string path, bool isVirtualPath = false)
        {
            var localPath = isVirtualPath ? HttpContext.Current.Request.MapPath(path) : path;
            if (!File.Exists(localPath))
            {
                throw new Exception(string.Format("Template file '{0}' does not exist.", localPath));
            }
            var file = new StreamReader(localPath, Encoding.UTF8);
            var template = Template.Parse(file.ReadToEnd());
            file.Close();
            return template;
        }

        public static void WriteTemplate(string path, string content, bool isVirtualPath = false)
        {
            var localPath = isVirtualPath ? HttpContext.Current.Request.MapPath(path) : path;
            if (File.Exists(localPath))
            {
                File.Delete(localPath);
            }
            File.WriteAllText(localPath, content, Encoding.UTF8);
        }

        /// <summary>
        /// Put your data to template and return string data.
        /// </summary>
        /// <remarks>See http://dotliquidmarkup.org to know how to make template and hoe data put into it.</remarks>
        /// <param name="path">Path to template (Absolute or related)</param>
        /// <param name="data">Data to put into template</param>
        /// <param name="isVirtualPath">Is path vitual ?</param>
        /// <returns>String contains template mixed with data</returns>
        public static string FormatTemplate(string path, object data, bool isVirtualPath = false)
        {
            var template = LoadTemplate(path, isVirtualPath);
            return template.Render(Hash.FromAnonymousObject(data));

        }

        public static string FormatTemplateWithContentTemplate(string contentTempalte, object data)
        {
            var template = Template.Parse(contentTempalte);
            if (data is System.Dynamic.ExpandoObject)
            {
                //phan nay xu ly du lieu tu PCST report
                return template.Render(Hash.FromDictionary(data as IDictionary<string, object>));
            }
            else
                return template.Render(Hash.FromAnonymousObject(data));

        }

        public static string ReadContentFromFile(string path, bool isVirtualPath = false)
        {
            var localPath = isVirtualPath ? HttpContext.Current.Request.MapPath(path) : path;
            if (!File.Exists(localPath))
            {
                throw new Exception(string.Format("Template file '{0}' does not exist.", localPath));
            }
            var file = new StreamReader(localPath, Encoding.UTF8);
            var data = file.ReadToEnd();
            file.Close();
            return data;
        }
        public static string ReadContentFromFileFromService(string path, bool isVirtualPath = false)
        {
            var appSettingReader = new AppSettingsReader();
            var localPath = isVirtualPath ? HttpContext.Current.Request.MapPath(path) : path;
            if (!File.Exists(localPath))
            {
                throw new Exception(string.Format("Template file '{0}' does not exist.", localPath));
            }
            var file = new StreamReader(localPath, Encoding.UTF8);
            var data = file.ReadToEnd();
            file.Close();
            return data;
        }
    }
}
