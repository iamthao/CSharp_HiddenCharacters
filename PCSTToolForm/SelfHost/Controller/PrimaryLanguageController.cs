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
    public class PrimaryLanguageController : ApiController
    {
        public IHttpActionResult Get()
        {
            PrimaryLanguageService primaryLanguageService = new PrimaryLanguageService();
            var data = primaryLanguageService.GetListPrimaryLanguage();
            return Ok(data);
        }
    }
}
