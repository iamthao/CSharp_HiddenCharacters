using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using Newtonsoft.Json;
using PcstLib.Services;
using System.Configuration;

namespace PCSTToolForm.SelfHost.Controller
{
    public class CountyController : ApiController
    {
         public IHttpActionResult Get()
         {
             var stateId = 49;
             string stateIdConfig = ConfigurationManager.AppSettings["StateId"];
             int valInt;
             if (int.TryParse(stateIdConfig, out valInt))
             {
                 stateId = valInt;
             }           
             CountyService countyService = new CountyService();
             var data = countyService.GetListCounty(stateId);
             return Ok(data);
         }
    }
}
