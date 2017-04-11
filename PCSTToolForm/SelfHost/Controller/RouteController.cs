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
    public class RouteController :ApiController
    {

        public IHttpActionResult Get()
        {
            RouteService routeService = new RouteService();
            var data = routeService.GetListRoute();
            return Ok(data);
        }
    }
}
