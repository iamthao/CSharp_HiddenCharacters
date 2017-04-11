using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using Newtonsoft.Json;
using PcstLib.Services;

namespace PCSTToolForm.SelfHost.Controller
{
    public class FrequencyController : ApiController
    {

        public IHttpActionResult Get()
        {
            FrequencyService frequencyService = new FrequencyService();
            var data = frequencyService.GetListFrequency();
            return Ok(data);
        }
    }
}
