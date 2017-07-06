using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace PCSTToolForm.Update
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
    }
}
