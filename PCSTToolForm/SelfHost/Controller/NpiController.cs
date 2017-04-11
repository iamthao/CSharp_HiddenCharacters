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
    [RoutePrefix("api/Npi")]
    public class NpiController :ApiController
    {
        private readonly  string pathFileDefaultData = ConfigurationManager.AppSettings["PathFileDefaultData"];
        // GET api/values 
        public IHttpActionResult Get(string queryInfo)
        {
            if (string.IsNullOrEmpty(queryInfo))
            {
                return Ok(false);
                
            }
            var queryJson = EncryptHelper.Base64Decode(queryInfo);
            var query = JsonConvert.DeserializeObject<QueryGridPhysicianVo>(queryJson);
          
            NpiService npiService = new NpiService();
            var data = npiService.GetListNpi(query);
            return Ok(data);
        }

        //[Route("GetTotalForGrid")]
        //public IHttpActionResult GetTotalForGrid(string query)
        //{
        //    if (string.IsNullOrEmpty(query))
        //    {
        //        return Ok(false);

        //    }
        //    var queryJson = EncryptHelper.Base64Decode(query);
        //    var queryMap = new QueryInfo
        //    {
        //        AdditionalSearchString = queryJson,
        //        PathFileDefaultData = pathFileDefaultData
        //    };
           
        //    NpiService npiService = new NpiService();
        //    var data = npiService.GetTotalForGridGridAdvanceSearch(queryMap);
        //    return Ok(data);
        //}
    }
}
