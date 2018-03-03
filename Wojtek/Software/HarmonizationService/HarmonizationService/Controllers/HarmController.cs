using System.Collections.Generic;
using System.Net;
using System.Web.Http;
using DataBaseAccessor;
using Swashbuckle.Swagger.Annotations;

namespace HarmonizationService.Controllers
{
    [RoutePrefix("harmonizer")]
    public class HarmController : ApiController
    {
        [HttpGet]
        [SwaggerResponseRemoveDefaults]
        [SwaggerResponse(HttpStatusCode.OK, Type = typeof(List<vWaterPlant>))]
        public string Get()
        {

            return "Everything is okay";
        }

        [HttpGet]
        [Route("api/value/{id}")]
        public string Get(int id)
        {
            return "value";
        }

        [HttpPost]
        [Route("{value}")]
        public void Post([FromBody]string value)
        {
        }
    }
}
