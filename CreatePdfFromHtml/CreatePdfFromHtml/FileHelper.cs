﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CreatePdfFromHtml
{
    class FileHelper
    {
        public static byte[] GetBytesFromFile(string fullFilePath)
        {
            FileStream fs = null;
            try
            {
                fs = File.OpenRead(fullFilePath);
                var bytes = new byte[fs.Length];
                fs.Read(bytes, 0, Convert.ToInt32(fs.Length));
                return bytes;
            }
            finally
            {
                if (fs != null)
                {
                    fs.Close();
                    fs.Dispose();
                }
            }
        }
        public static byte[] Combine(byte[] first, byte[] second)
        {
            var ret = new byte[first.Length + second.Length];
            Buffer.BlockCopy(first, 0, ret, 0, first.Length);
            Buffer.BlockCopy(second, 0, ret, first.Length, second.Length);
            return ret;
        }

        public static byte[] GetBytesFromUrl(string url)
        {
            string empty;
            return GetBytesFromUrl(url, out empty);
        }

        public static byte[] GetBytesFromUrl(string url, out string responseUrl)
        {
            byte[] downloadedData;
            try
            {
                //Get a data stream from the url  
                WebRequest req = WebRequest.Create(url);

                if (url.ToLower().StartsWith("https://"))
                {
                    ServicePointManager.ServerCertificateValidationCallback = ((sender, certificate, chain, errors) => true);
                }

                WebResponse response = req.GetResponse();
                Stream stream = response.GetResponseStream();
                if (stream == null)
                {
                    responseUrl = string.Empty;
                    return new byte[0];
                }
                responseUrl = response.ResponseUri.ToString();

                //Download in chuncks  
                var buffer = new byte[1024];

                //Get Total Size  
                int dataLength = (int)response.ContentLength;

                //Download to memory  
                //Note: adjust the streams here to download directly to the hard drive  
                var memStream = new MemoryStream();
                while (true)
                {
                    //Try to read the data  
                    int bytesRead = stream.Read(buffer, 0, buffer.Length);

                    if (bytesRead == 0)
                    {
                        break;
                    }
                    //Write the downloaded data  
                    memStream.Write(buffer, 0, bytesRead);

                }

                //Convert the downloaded stream to a byte array  
                downloadedData = memStream.ToArray();

                //Clean up  
                stream.Close();
                memStream.Close();

            }
            catch (Exception)
            {
                responseUrl = string.Empty;
                return new byte[0];
            }

            return downloadedData;
        }

        public static bool IsFileLocked(string file)
        {
            var fileInfo = new FileInfo(file);
            FileStream stream = null;

            try
            {
                stream = fileInfo.Open(FileMode.Open, FileAccess.Read, FileShare.None);
            }
            catch (IOException)
            {
                //the file is unavailable because it is:
                //still being written to
                //or being processed by another thread
                //or does not exist (has already been processed)
                return true;
            }
            finally
            {
                if (stream != null)
                    stream.Close();
            }

            //file is not locked
            return false;
        }

        public static double GetFileSizeRequestTemps(string fileName)
        {
            var path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Resources", "Requests", "Temps", fileName);
            if (File.Exists(path))
            {
                return File.ReadAllBytes(path).Length;
            }
            return 0;
        }
        public static double GetFileSizeMembersTemps(string fileName)
        {
            var path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Resources", "Members", "Temps", fileName);
            if (File.Exists(path))
            {
                return File.ReadAllBytes(path).Length;
            }
            return 0;
        }
        public static void CopyFileRequest(string fileName, string requestNo)
        {
            var pathDestination = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Resources", "Requests", requestNo);
            var pathSource = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Resources", "Requests", "Temps", fileName);
            if (!Directory.Exists(pathDestination))
            {
                Directory.CreateDirectory(pathDestination);
            }
            pathDestination = Path.Combine(pathDestination, fileName);
            if (File.Exists(pathSource))
            {
                File.Copy(pathSource, pathDestination, true);
                File.Delete(pathSource);
            }
        }
        public static void CopyFileMember(string fileName, string memberId)
        {
            var pathDestination = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Resources", "Members", memberId);
            var pathSource = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Resources", "Requests", "Temps", fileName);
            if (!Directory.Exists(pathDestination))
            {
                Directory.CreateDirectory(pathDestination);
            }
            pathDestination = Path.Combine(pathDestination, fileName);
            if (File.Exists(pathSource))
            {
                File.Copy(pathSource, pathDestination, true);
                File.Delete(pathSource);
            }
        }
        public static void CopyLetterFileRequest(FileInfo file, string pathDestination)
        {
            if (string.IsNullOrEmpty(pathDestination))
                return;
            var dir = Path.GetDirectoryName(pathDestination);
            if (dir != null && !Directory.Exists(dir))
            {
                Directory.CreateDirectory(dir);
            }
            if (file.Exists)
            {
                file.CopyTo(pathDestination, true);
            }
        }

        public static string UrlRequestFormat = "/Resources/Requests/{0}/{1}";
        public static string UrlMemberFormat = "/Resources/Members/{0}/{1}";

        public static bool CheckAvailableFile(string path)
        {
            if (IsFileLocked(path))
            {
                Thread.Sleep(2000);
                return CheckAvailableFile(path);
            }
            return true;
        }
    }
}