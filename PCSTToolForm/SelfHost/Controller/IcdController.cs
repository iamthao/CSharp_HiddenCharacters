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
    public class IcdController : ApiController
    {
        public IHttpActionResult Get(string query)
        {
            IcdService icdService = new IcdService();
            var data = icdService.GetListIcd(query);
            return Ok(data);
        }
    }
}
