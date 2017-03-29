//using System;
//using System.Collections.Generic;
//using System.Configuration;
//using System.IO;
//using System.Text;
//using System.Web;
//using DotLiquid;

//namespace LibraryFunction
//{
//    public sealed class TemplateHelpper
//    {
//        /// <summary>
//        /// Load a template from file
//        /// </summary>
//        /// <param name="path">Path to template file (Absolute or related)</param>
//        /// <param name="isVirtualPath">Is your specified path a virtual ?</param>
//        /// <returns>Return loaded template</returns>
//        public static Template LoadTemplate(string path, bool isVirtualPath = false)
//        {
//            var localPath = isVirtualPath ? HttpContext.Current.Request.MapPath(path) : path;
//            if (!File.Exists(localPath))
//            {
//                throw new Exception(string.Format("Template file '{0}' does not exist.", localPath));
//            }
//            var file = new StreamReader(localPath, Encoding.UTF8);
//            var template = Template.Parse(file.ReadToEnd());
//            file.Close();
//            return template;
//        }

//        public static void WriteTemplate(string path, string content, bool isVirtualPath = false)
//        {
//            var localPath = isVirtualPath ? HttpContext.Current.Request.MapPath(path) : path;
//            if (File.Exists(localPath))
//            {
//                File.Delete(localPath);
//            }
//            File.WriteAllText(localPath, content, Encoding.UTF8);
//        }

//        /// <summary>
//        /// Put your data to template and return string data.
//        /// </summary>
//        /// <remarks>See http://dotliquidmarkup.org to know how to make template and hoe data put into it.</remarks>
//        /// <param name="path">Path to template (Absolute or related)</param>
//        /// <param name="data">Data to put into template</param>
//        /// <param name="isVirtualPath">Is path vitual ?</param>
//        /// <returns>String contains template mixed with data</returns>
//        public static string FormatTemplate(string path, object data, bool isVirtualPath = false)
//        {
//            var template = LoadTemplate(path, isVirtualPath);
//            return template.Render(Hash.FromAnonymousObject(data));

//        }

//        public static string FormatTemplateWithContentTemplate(string contentTempalte, object data)
//        {
//            var template = Template.Parse(contentTempalte);
//            if (data is System.Dynamic.ExpandoObject)
//            {
//                //phan nay xu ly du lieu tu PCST report
//                return template.Render(Hash.FromDictionary(data as IDictionary<string, object>));
//            }
//            else 
//                return template.Render(Hash.FromAnonymousObject(data));

//        }

//        public static string ReadContentFromFile(string path, bool isVirtualPath = false)
//        {
//            var localPath = isVirtualPath ? HttpContext.Current.Request.MapPath(path) : path;
//            if (!File.Exists(localPath))
//            {
//                throw new Exception(string.Format("Template file '{0}' does not exist.", localPath));
//            }
//            var file = new StreamReader(localPath, Encoding.UTF8);
//            var data = file.ReadToEnd();
//            file.Close();
//            return data;
//        }
//        public static string ReadContentFromFileFromService(string path, bool isVirtualPath = false)
//        {
//            var appSettingReader = new AppSettingsReader();
//            var localPath = isVirtualPath ? HttpContext.Current.Request.MapPath(path) : path;
//            if (!File.Exists(localPath))
//            {
//                throw new Exception(string.Format("Template file '{0}' does not exist.", localPath));
//            }
//            var file = new StreamReader(localPath, Encoding.UTF8);
//            var data = file.ReadToEnd();
//            file.Close();
//            return data;
//        }
//    }

//    public class TemplateConfigFile
//    {
//        public static string CreateUserEmailTemplate
//        {
//            get
//            {
//                return "~/FileUpload/ConfigData/CreateUserEmailTemplate.html";
//            }
//        }
//        public static string RestorePasswordTemplate
//        {
//            get
//            {
//                return "~/FileUpload/ConfigTemplate/RestorePasswordTemplate.html";
//            }
//        }
//        public static string ResetPasswordTemplate
//        {
//            get
//            {
//                return "~/FileUpload/ConfigTemplate/ResetPasswordTemplate.html";
//            }
//        }
//        public static string CreateCourierEmailTemplate
//        {
//            get
//            {
//                return "~/FileUpload/ConfigTemplate/CreateCourierEmailTemplate.html";
//            }
//        }
//        public static string RestorePasswordCourierTemplate
//        {
//            get
//            {
//                return "~/FileUpload/ConfigTemplate/RestorePasswordCourierTemplate.html";
//            }
//        }

//        public static string RestorePassword
//        {
//            get
//            {
//                return "~/FileUpload/ConfigTemplate/RestorePassword.html";
//            }
//        }
//        public static string DeliveryAgreementReportTemplate
//        {
//            get
//            {
//                return "~/FileUpload/ReportTemplate/DeliveryAgreement.html";
//            }
//        }

//        public static string EmailChangePackageTemplate
//        {
//            get
//            {
//                return "~/FileUpload/ConfigTemplate/EmailChangePackageTemplate.html";
//            }
//        }
//        public static string ContactToLhc
//        {
//            get
//            {
//                return "~/FileUpload/ConfigTemplate/ContactUs.html";
//            }
//        }
//        public static string NotificationNewPCIRegistrationToAdminTemplate
//        {
//            get
//            {
//                return "~/FileUpload/ConfigTemplate/NotificationNewPCIRegistrationToAdminTemplate.html";
//            }
//        }
//        public static string NotifyProvider
//        {
//            get
//            {
//                return "~/FileUpload/ConfigTemplate/NotifyProvider.html";
//            }
//        }
//        public static string ActiveProviderAgency
//        {
//            get
//            {
//                return "~/FileUpload/ConfigTemplate/ActiveProviderAgencyEmailTemplate.html";
//            }
//        }
//        public static string DeactiveProviderAgency
//        {
//            get
//            {
//                return "~/FileUpload/ConfigTemplate/DeactiveProviderAgencyEmailTemplate.html";
//            }
//        }
//        public static string ApprovalProviderAgency
//        {
//            get
//            {
//                return "~/FileUpload/ConfigTemplate/ApprovalProviderAgencyEmailTemplate.html";
//            }
//        }
//        public static string RejectProviderAgency
//        {
//            get
//            {
//                return "~/FileUpload/ConfigTemplate/RejectProviderAgencyEmailTemplate.html";
//            }
//        }

//        public static string AgencyRegisSuccessful
//        {
//            get
//            {
//                return "~/FileUpload/ConfigTemplate/AgencyRegisSuccessful.html";
//            }
//        }
//    }
//}
