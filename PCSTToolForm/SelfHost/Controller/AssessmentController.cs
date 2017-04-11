using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using Newtonsoft.Json;
using PcstLib.Services;
using PcstLib.Utility;

namespace PCSTToolForm.SelfHost.Controller
{
    [RoutePrefix("api/Assessment")]
    public class AssessmentController : ApiController
    {

        public IHttpActionResult Get(int id)
        {
            AssessmentService assessmentService = new AssessmentService();
            var data = assessmentService.GetDataNewPcst(id);
            return Ok(data);
        }

        [HttpPost]
        [Route("Save")]
        public IHttpActionResult Save([FromBody] string parameters)
        {
            AssessmentService assessmentService = new AssessmentService();
            var data = assessmentService.Save(parameters);
            return Ok(data);
        }

        [HttpPost]
        [Route("Verify")]
        public IHttpActionResult Verify([FromBody] string parameters)
        {
            AssessmentService assessmentService = new AssessmentService();
            var data = assessmentService.Verify(parameters);
            return Ok(data);
        }
    }
}
