using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using Newtonsoft.Json;
using PcstLib.Services;
using PcstLib.Sqlite.ValueObject;
using PcstLib.Utility;

namespace PCSTToolForm.SelfHost.Controller
{
    [RoutePrefix("api/Provider")]
    public class ProviderController : ApiController
    {
        // GET api/values 
        public IHttpActionResult Get(string queryInfo)
        {
            if (string.IsNullOrEmpty(queryInfo))
            {
                return Ok(false);
                
            }
            var queryJson = EncryptHelper.Base64Decode(queryInfo);
            var query = JsonConvert.DeserializeObject<QueryGridProvider>(queryJson);

            ProviderService providerService = new ProviderService();
            var data = providerService.GetListProvider(query);
            return Ok(data);
        }

        [HttpPost]
        [Route("GetProviderFromName")]
        public IHttpActionResult GetProviderFromName([FromBody] string nameJson)
        {
            var dataJson = EncryptHelper.Base64Decode(nameJson);
            ProviderService providerService = new ProviderService();
            var data = providerService.GetProviderFromName(dataJson);
            return Ok(data);
        }
    }
}
