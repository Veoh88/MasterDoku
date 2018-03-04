using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Results;
using DataBaseAccessor;
using Library.HarmonizationApi;
using Swashbuckle.Swagger.Annotations;

namespace HarmonizationService.Controllers
{
    [RoutePrefix("harmonizer")]
    public class HarmController : ApiController
    {
        #region Private Members

        private BusinessLogic.BusinessLogic _businessLogic;

        #endregion
        #region Constructors

        public HarmController()
        {
            _businessLogic = new BusinessLogic.BusinessLogic();
        }
        #endregion

        #region HTTP Methods

        [HttpPost]
        [Route("harmonize/fileFormat/{fileFormat}/waterPlant/{waterPlant}/treatmentStep/{treatmentStep}")]
        [SwaggerResponseRemoveDefaults]
        [SwaggerResponse(HttpStatusCode.OK)]
        public string HarmonizeData([FromUri] FileFormat fileFormat, [FromUri] string waterPlant, [FromUri] string treatmentStep)
        {
            if (fileFormat == FileFormat.CSV || fileFormat == FileFormat.XLS)
            {
                var stream = Request.Content.ReadAsStreamAsync().Result;
                var result = _businessLogic.HarmonizeData(stream);
            }
            else if (fileFormat == FileFormat.JSON)
            {
                var json = Request.Content.ReadAsStringAsync().Result;
            }

            return null;
        }

        [HttpPost]
        [Route("harmonize/fileFormat/{fileFormat}/waterPlant/{waterPlant}")]
        [SwaggerResponseRemoveDefaults]
        [SwaggerResponse(HttpStatusCode.OK)]
        public string HarmonizeData([FromUri] FileFormat fileFormat, [FromUri] string waterPlant)
        {
            if (fileFormat == FileFormat.CSV || fileFormat == FileFormat.XLS)
            {
                return
                    "This fileFormat is not supported on this endpoint. Please use: [endpoint]/harmonize/fileFormat/{fileFormat}/waterPlant/{waterPlant}/treatmentStep/{treatmentStep}";
            }
            else if (fileFormat == FileFormat.JSON)
            {
                var json = Request.Content.ReadAsStringAsync().Result;
            }

            return null;
        }

        [HttpPost]
        [Route("harmonize/fileFormat/{fileFormat}")]
        [SwaggerResponseRemoveDefaults]
        [SwaggerResponse(HttpStatusCode.OK)]
        public string HarmonizeData([FromUri] FileFormat fileFormat)
        {
            if (fileFormat == FileFormat.CSV || fileFormat == FileFormat.XLS)
            {
                return
                    "This fileFormat is not supported on this endpoint. Please use: [endpoint]/harmonize/fileFormat/{fileFormat}/waterPlant/{waterPlant}/treatmentStep/{treatmentStep}";
            }
            else if (fileFormat == FileFormat.JSON)
            {
                var json = Request.Content.ReadAsStringAsync().Result;
                _businessLogic.HarmonizeData()
            }

            return null;
        }
        #endregion
    }
}
