using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Net.Mime;
using System.Text;
using System.Text.RegularExpressions;


namespace LibraryFunction
{
    public interface IFaxHandler
    {

        bool SendFax(string subject, string senderName, string recipientName, string faxNumber, string contentOrFilePath,
            ref string errorMess, bool isFilePath = false);

    }
    public class FaxHandler : IFaxHandler
    {
        public bool SendFax(string subject, string senderName, string recipientName, string faxNumber, string contentOrFilePath, ref string errorMess, bool isFilePath = false)
        {
            try
            {
                //var diagnosticService = DependencyResolver.Current.GetService<IDiagnosticService>();
                faxNumber = Regex.Replace(faxNumber, "[^0-9]+", "");
                var settingsReader = new AppSettingsReader();
                var api = new wfApi();
                var url = (string)settingsReader.GetValue("FaxServer", typeof(String));
                api.Url = url;
                Int64 uid = 0;
                var user = (string)settingsReader.GetValue("FaxUserName", typeof(String));
                var password = (string)settingsReader.GetValue("FaxPassword", typeof(String));
                if (string.IsNullOrEmpty(senderName))
                {
                    senderName = (string)settingsReader.GetValue("EmailFromDisplayName", typeof(String));
                }

                uid = api.AuthenticateUser(user, password);
                if (uid != 0 && uid != 1 && uid != 2)
                {
                    // create file temp to store content
                    string fullPath = string.Empty;
                    if (!isFilePath)
                    {
                        string filePath = Path.GetTempPath();
                        string fileName = Guid.NewGuid().ToString().Replace("-", "") + ".pdf";

                        var pathApplication = "file:///" + AppDomain.CurrentDomain.BaseDirectory.Replace("\\", "/");
                        var doc = new HtmlDocumentHelper(contentOrFilePath);
                        contentOrFilePath = doc.MergeUrlOnImage(pathApplication);
                        var exportFileExportToPdf = new HtmToPdfProvider();
                        fullPath = exportFileExportToPdf.Export(filePath, fileName, contentOrFilePath, null);
                    }
                    else
                    {
                        fullPath = contentOrFilePath;
                    }
                    if (string.IsNullOrEmpty(fullPath) || !File.Exists(fullPath))
                    {
                        //if (diagnosticService != null)
                        //{
                        //    diagnosticService.Info("Cannot create pdf file to fax.");
                        //}
                        return false;
                    }

                    var result = SendFax(api, uid, senderName, subject, recipientName, faxNumber, fullPath);

                    Int64 msgNo = 0;
                    if (Int64.TryParse(result, out msgNo))
                    {
                        //message successfully send to server for processing, return value Message ID
                        result = msgNo.ToString();
                        //if (diagnosticService != null)
                        //{
                        //    diagnosticService.Info("Message sent: " + result);
                        //}
                        return true;
                    }
                    //message fail to send to server for processing, return value = 0
                    //if (diagnosticService != null)
                    //{
                    //    errorMess = result;
                    //    diagnosticService.Info("Send failed.");
                    //}
                    return false;
                }
                //if (diagnosticService != null)
                //{
                //    diagnosticService.Info("Authentication Failed.");
                //}
                return false;
            }
            catch (Exception exception)
            {
                errorMess = exception.Message;
                return false;
            }

        }

        private string SendFax(wfApi api, Int64 uid, string senderName, string subject, string recipientNameValue, string recipientFaxNumber, string filename)
        {
            var trackingKey = new string[2];
            var trackingValue = new string[2];
            trackingKey[0] = "Tracking Key 1";
            trackingValue[0] = "";
            trackingKey[1] = "Tracking Key 2";
            trackingValue[1] = "";
            //recipient information. sample below shows how to insert one recipient to the message.
            //to send to multiple fax recipients, just extend the list for information below.
            //recipient notify address, notification on send success and notification on send fail are optional.
            var recipientName = new string[1];
            var recipientCompany = new string[1];
            var recipientFax = new string[1];              //recipient fax number
            var isRawFax = new bool[1];                      //specify fax number as raw format
            var recipientNotifyAddress = new string[1];    //recipient email notification address
            var notifyRecipientOnSendSuccess = new bool[1];  //notify recipient on message send success
            var notifyRecipientOnSendFail = new bool[1];     //notify recipient on message send fail
            recipientName[0] = recipientNameValue;
            recipientCompany[0] = "";
            recipientFax[0] = recipientFaxNumber;
            isRawFax[0] = true;
            //recipientNotifyAddress[0] = "nghiep.vo@caminois.com";
            recipientNotifyAddress[0] = "";
            notifyRecipientOnSendSuccess[0] = true;
            notifyRecipientOnSendFail[0] = true;

            //attachment information

            FileStream fs = null;
            byte[] doc1;
            try
            {
                fs = File.OpenRead(filename);
                doc1 = new byte[fs.Length];
                fs.Read(doc1, 0, Convert.ToInt32(fs.Length));
            }
            finally
            {
                if (fs != null)
                {
                    fs.Close();
                    fs.Dispose();
                }
            }


            //attach document from Bytes/Upload (multiple documents)
            var documentName = new string[1];
            var documentPath = new string[1];
            var documentBytes = new object[1];
            var isMergeDocument = new bool[1];

            documentName[0] = Path.GetFileName(filename);
            documentPath[0] = string.Empty;
            documentBytes[0] = doc1;
            isMergeDocument[0] = false;

            var result = api.SendMessage(uid
                , senderName
                , ""
                , subject
                , ""
                , ""
                , ""
                , 50
                , false
                , false
                , false
                , trackingKey
                , trackingValue
                , recipientName
                , recipientCompany
                , recipientFax
                , isRawFax
                , recipientNotifyAddress
                , notifyRecipientOnSendFail
                , notifyRecipientOnSendSuccess
                , documentName
                , documentPath
                , documentBytes
                , isMergeDocument);

            return result;

        }

    }

}