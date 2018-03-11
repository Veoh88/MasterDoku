using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using System.Web.Http.Results;
using DataBaseAccessor;
using Library.HarmonizationApi;
using Library.HarmonizedObjects;
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
        /// <returns>Error message what failed in case of failure</returns>
        [HttpPost]
        [Route("harmonize/fileFormat/{fileFormat}/waterPlant/{waterPlant}/treatmentStepType/{treatmentStepType}")]
        [SwaggerResponseRemoveDefaults]
        [SwaggerResponse(HttpStatusCode.OK)]
        public void HarmonizeData([FromUri] FileFormat fileFormat, [FromUri] string waterPlant, [FromUri] string treatmentStepType)
        {
            try
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
            }
            catch (Exception e)
            {
                throw new HttpException((int)HttpStatusCode.BadRequest, $"Data could not be harmonized. Reason: {e.Message}");

            }
        }

        /// <summary>
        /// Creates entries for a specific waterplant. The content of the request can either be a list of treatmentsteptypes each containing
        /// a list of qualityindicators or a list of qualityindicators which get assigned to the waterplant directly
        /// </summary>
        /// <param name="fileFormat">JSON</param>
        /// <param name="waterPlant">id or name of the waterPlant</param>
        /// <returns>Error message what failed in case of failure</returns>
        [HttpPost]
        [Route("harmonize/fileFormat/{fileFormat}/waterPlant/{waterPlant}")]
        [SwaggerResponseRemoveDefaults]
        [SwaggerResponse(HttpStatusCode.OK)]
        public void HarmonizeData([FromUri] FileFormat fileFormat, [FromUri] string waterPlant)
        {

            try
            {
                if (fileFormat == FileFormat.CSV || fileFormat == FileFormat.XLS)
                {
                    throw new Exception("This fileFormat is not supported on this endpoint. Please use: [endpoint]/harmonize/fileFormat/{fileFormat}/waterPlant/{waterPlant}/treatmentStepType/{treatmentStepType}");
                }
                else if (fileFormat == FileFormat.JSON)
                {
                    var json = Request.Content.ReadAsStringAsync().Result;
                    _businessLogic.HarmonizeData(json, waterPlant);
                }
            }
            catch (Exception e)
            {
                throw new HttpException((int)HttpStatusCode.BadRequest, $"Data could not be harmonized. Reason: {e.Message}");
            }
        }

        /// <summary>
        /// This endpoints accepts a list waterplant containing a list of treatmentsteptypes, which then contains a list of qualityindicators
        /// or a waterplant containing a list of qualityindicators
        /// </summary>
        /// <param name="fileFormat">JSON</param>
        /// <returns>Error message what failed in case of failure</returns>
        [HttpPost]
        [Route("harmonize/fileFormat/{fileFormat}")]
        [SwaggerResponseRemoveDefaults]
        [SwaggerResponse(HttpStatusCode.OK)]
        public void HarmonizeData([FromUri] FileFormat fileFormat)
        {

            try
            {
                if (fileFormat == FileFormat.CSV || fileFormat == FileFormat.XLS)
                {
                    throw new Exception("This fileFormat is not supported on this endpoint. Please use: [endpoint]/harmonize/fileFormat/{fileFormat}/waterPlant/{waterPlant}/treatmentStepType/{treatmentStepType}");
                }
                else if (fileFormat == FileFormat.JSON)
                {
                    var json = Request.Content.ReadAsStringAsync().Result;
                    _businessLogic.HarmonizeData(json);
                }
            }
            catch (Exception e)
            {
                throw new HttpException((int)HttpStatusCode.BadRequest, $"Data could not be harmonized. Reason: {e.Message}");

            }
        }
        #endregion
    }
}
