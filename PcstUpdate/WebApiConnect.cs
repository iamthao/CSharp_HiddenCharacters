using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace PcstUpdate
{
    public class WebApiConnect
    {
        private readonly string _apiAddress;
        public WebApiConnect(string apiAddress)
        {
            _apiAddress = apiAddress;
        }

        private void SetClientHeader(HttpClient client)
        {
            client.BaseAddress = new Uri(_apiAddress);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public object SendMessageToWebApi(string method, object data)
        {
            return SendMessageToWebApiAndReturnValue<object>(method, data);
        }

        public TResult SendMessageToWebApiAndReturnValue<TResult>(
            string method, object data)
        {

            using (var client = new HttpClient())
            {
                SetClientHeader(client);
                var response = client.PostAsJsonAsync(method, data).Result;
                if (response.IsSuccessStatusCode)
                {
                    // Get the URI of the created resource.
                    TResult dataReturn = response.Content.ReadAsAsync<TResult>().Result;
                    return dataReturn;
                }
                throw new Exception(response.StatusCode.ToString());
            }
        }

        public bool DownloadPcstUpdate(string desPath, long fileSize, Action<int, object> reportProgress)
        {
            try
            {
                long offset = 0;
                int chunkSize = 64 * 1024;
                int numRetries = 0;
                var localDir = Path.GetDirectoryName(desPath);


                if (localDir != null && !Directory.Exists(localDir))
                    Directory.CreateDirectory(localDir);

                // open a file stream for the file we will write to in the start-up folder
                using (var fs = new FileStream(desPath, FileMode.Create, FileAccess.Write))
                {
                    fs.Seek(offset, SeekOrigin.Begin);
                    while (offset < fileSize)
                    {
                        try
                        {
                            var result = SendMessageToWebApi("GetPcstFile", new []{ offset, chunkSize });
                            var buffer = Convert.FromBase64String((String)result);
                            fs.Write(buffer, 0, buffer.Length);
                            offset += buffer.Length;	// save the offset position for resume
                            if (Convert.ToInt32(offset*100/fileSize) < 0)
                            {
                                
                            }
                            reportProgress(Convert.ToInt32((offset * 100 / fileSize)), null);
                        }
                        catch (Exception ex)
                        {
                            if (numRetries++ >= 5)	// too many retries, bail out
                            {
                                return false;
                            }
                        }
                    }
                }
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
