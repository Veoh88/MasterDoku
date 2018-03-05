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

        private readonly BusinessLogic.BusinessLogic _businessLogic;

        #endregion

        #region Constructors

        public HarmController()
        {
            _businessLogic = new BusinessLogic.BusinessLogic();
        }
        #endregion

        #region HTTP Methods

        /// <summary>
        /// Harmonizes the provided file. 
        /// If provided as JSON, must contain the qualityindicators
        /// </summary>
        /// <param name="fileFormat">CSV / XLS / JSON</param>
        /// <param name="waterPlant">id or name of the waterPlant</param>
        /// <param name="treatmentStepType">can be either the name or the id of a treatment type step</param>
        /// <returns></returns>
        [HttpPost]
        [Route("harmonize/fileFormat/{fileFormat}/waterPlant/{waterPlant}/treatmentStepType/{treatmentStepType}")]
        [SwaggerResponseRemoveDefaults]
        [SwaggerResponse(HttpStatusCode.OK)]
        public string HarmonizeData([FromUri] FileFormat fileFormat, [FromUri] string waterPlant, [FromUri] string treatmentStepType)
        {
            if (fileFormat == FileFormat.CSV || fileFormat == FileFormat.XLS)
            {
                var stream = Request.Content.ReadAsStreamAsync().Result;
                var result = _businessLogic.HarmonizeData(stream, fileFormat, waterPlant, treatmentStepType);
            }
            else if (fileFormat == FileFormat.JSON)
            {
                var json = Request.Content.ReadAsStringAsync().Result;
                _businessLogic.HarmonizeData(json, waterPlant, treatmentStepType);
            }

            return null;
        }

        /// <summary>
        /// Creates entries for a specific waterplant. The content of the request can either be a list of treatmentsteptypes each containing
        /// a list of qualityindicators or a list of qualityindicators which get assigned to the waterplant directly
        /// </summary>
        /// <param name="fileFormat">JSON</param>
        /// <param name="waterPlant">id or name of the waterPlant</param>
        /// <returns></returns>
        [HttpPost]
        [Route("harmonize/fileFormat/{fileFormat}/waterPlant/{waterPlant}")]
        [SwaggerResponseRemoveDefaults]
        [SwaggerResponse(HttpStatusCode.OK)]
        public string HarmonizeData([FromUri] FileFormat fileFormat, [FromUri] string waterPlant)
        {
            if (fileFormat == FileFormat.CSV || fileFormat == FileFormat.XLS)
            {
                return
                    "This fileFormat is not supported on this endpoint. Please use: [endpoint]/harmonize/fileFormat/{fileFormat}/waterPlant/{waterPlant}/treatmentStepType/{treatmentStepType}";
            }
            else if (fileFormat == FileFormat.JSON)
            {
                var json = Request.Content.ReadAsStringAsync().Result;
                _businessLogic.HarmonizeData(json, waterPlant);
            }

            return null;
        }

        /// <summary>
        /// This endpoints accepts a list waterplant containing a list of treatmentsteptypes, which then contains a list of qualityindicators
        /// or a waterplant containing a list of qualityindicators
        /// </summary>
        /// <param name="fileFormat"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("harmonize/fileFormat/{fileFormat}")]
        [SwaggerResponseRemoveDefaults]
        [SwaggerResponse(HttpStatusCode.OK)]
        public string HarmonizeData([FromUri] FileFormat fileFormat)
        {
            if (fileFormat == FileFormat.CSV || fileFormat == FileFormat.XLS)
            {
                return
                    "This fileFormat is not supported on this endpoint. Please use: [endpoint]/harmonize/fileFormat/{fileFormat}/waterPlant/{waterPlant}/treatmentStepType/{treatmentStepType}";
            }
            else if (fileFormat == FileFormat.JSON)
            {
                var json = Request.Content.ReadAsStringAsync().Result;
                _businessLogic.HarmonizeData(json);
            }

            return null;
        }
        #endregion
    }
}
