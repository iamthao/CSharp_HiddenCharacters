using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Net.Mime;
using System.Text;

namespace LibraryFunction
{
    public interface IEmailHandler
    {
        void SendEmail(string[] toEmail, string emailSubject, string emailContent, bool isHtmlFormat, Dictionary<string, string> listAttachmentFilename = null, string[] ccEmail = null);
    }

    public class EmailHandler : IEmailHandler
    {
        private readonly SmtpClient _smtpClient;
        public EmailHandler()
        {
            var appSettingReader = new AppSettingsReader();
            _smtpClient = new SmtpClient
            {
                Host = (string)appSettingReader.GetValue("Host", typeof(String)),
                EnableSsl = bool.Parse((string)appSettingReader.GetValue("EmailPortSSL", typeof(String))),
                Port = int.Parse((string)appSettingReader.GetValue("Port", typeof(String))),
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials =  bool.Parse((string)appSettingReader.GetValue("EmailPortSSL", typeof(String))),
                Credentials = new NetworkCredential((string)appSettingReader.GetValue("EmailFrom", typeof(String)), (string)appSettingReader.GetValue("Password", typeof(String)))
            };
        }

        public void SendEmail(string[] toEmail, string emailSubject, string emailContent, bool isHtmlFormat
                               , Dictionary<string, string> listAttachmentFilename = null, string[] ccEmail = null)
        {
            var appSettingReader = new AppSettingsReader();
            string displayName = (string)appSettingReader.GetValue("EmailFromDisplayName", typeof(String));
            var fromEmail = (string) appSettingReader.GetValue("EmailFrom", typeof (String));
            var message = new MailMessage { From = new MailAddress(fromEmail, displayName) };
            if (toEmail.Length > 0)
            {
                foreach (var item in toEmail.Where(item => !string.IsNullOrEmpty(item)))
                {
                    message.To.Add(new MailAddress(item));
                }
            }
            if (ccEmail != null && ccEmail.Length > 0)
            {
                foreach (var item in toEmail.Where(item => !string.IsNullOrEmpty(item)))
                {
                    message.CC.Add(new MailAddress(item));
                }
            }
            message.Subject = emailSubject;
            message.Body = emailContent;
            message.IsBodyHtml = isHtmlFormat;
            message.BodyEncoding = Encoding.UTF8;
            message.SubjectEncoding = Encoding.UTF8;
            if (listAttachmentFilename != null && listAttachmentFilename.Count > 0)
            {
                foreach (var attachmentFilename in listAttachmentFilename)
                {
                    var attachment = new Attachment(attachmentFilename.Value, MediaTypeNames.Application.Octet);
                    var disposition = attachment.ContentDisposition;
                    disposition.CreationDate = File.GetCreationTime(attachmentFilename.Value);
                    disposition.ModificationDate = File.GetLastWriteTime(attachmentFilename.Value);
                    disposition.ReadDate = File.GetLastAccessTime(attachmentFilename.Value);
                    disposition.FileName = attachmentFilename.Key;
                    disposition.Size = new FileInfo(attachmentFilename.Value).Length;
                    disposition.DispositionType = DispositionTypeNames.Attachment;
                    message.Attachments.Add(attachment);
                }
            }
            _smtpClient.Send(message);
        }
    }
}