using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web.Http;
using DataBaseAccessor;
using Swashbuckle.Swagger.Annotations;

namespace HarmonizationService.Controllers
{
    [RoutePrefix("provider")]
    public class ProviderController : ApiController
    {
        #region Private Members

        private IDataBaseViewAccessor _dbAccessor;

        #endregion
        #region Constructors

        public ProviderController()
        {
            _dbAccessor = new DbViewAccessor();
        }
        #endregion

        /// <summary>
        /// Returns all waterplants stored by the system
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("waterPlants")]
        [SwaggerResponseRemoveDefaults]
        [SwaggerResponse(HttpStatusCode.OK, Type = typeof(List<vWaterPlant>))]
        public List<vWaterPlant> GetWaterPlants()
        {
            var result = _dbAccessor.GetWaterPlants();
            return result.ToList();
        }

        /// <summary>
        /// Returns all treatment types which have stored indicators for a specific waterplant
        /// </summary>
        /// <param name="waterPlantId"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("waterPlants/{waterplantId}/treatmentStepTypes")]
        [SwaggerResponseRemoveDefaults]
        [SwaggerResponse(HttpStatusCode.OK, Type = typeof(List<vTreatmentStep>))]
        public List<vTreatmentStep> GetTreatmentSteps([FromUri] int waterPlantId)
        {
            var result = _dbAccessor.GetTreatmentSteps().Where(x => x.waterPlantId == waterPlantId);
            return result.ToList();
        }

        /// <summary>
        /// Returns all qualityindicators for a specific step in a specific water treatment plant
        /// </summary>
        /// <param name="waterPlantId">specific waterplant the indicator is returned for</param>
        /// <param name="treatmentStepTypeId">specific treatment step the indicator is returned for</param>
        /// <returns></returns>
        [HttpGet]
        [Route("waterPlants/{waterplantId}/treatmentStepTypes/{treatmentStepTypeId}/qualityIndicators")]
        [SwaggerResponseRemoveDefaults]
        [SwaggerResponse(HttpStatusCode.OK, Type = typeof(List<vQualityIndicator>))]
        public List<vQualityIndicator> GetQualityIndicators([FromUri] int waterPlantId, [FromUri] int treatmentStepTypeId)
        {
            var treatmentStepTypesForWwtp = _dbAccessor.GetTreatmentSteps().Where(x => x.waterPlantId == waterPlantId).Select(x=>x.treatmentStepId).ToList();
            var result = _dbAccessor.GetQualityIndicators().Where(x=>x.treatmentStepId != null && treatmentStepTypesForWwtp.Contains((int)x.treatmentStepId));
            return result.ToList();
        }

        /// <summary>
        /// Returns all qualityindicators assigned directly to a specific waterplant
        /// </summary>
        /// <param name="waterPlantId">specific waterplant the indicator is returned for</param>
        /// <returns></returns>
        [HttpGet]
        [Route("waterPlants/{waterplantId}/qualityIndicators")]
        [SwaggerResponseRemoveDefaults]
        [SwaggerResponse(HttpStatusCode.OK, Type = typeof(List<vQualityIndicator>))]
        public List<vQualityIndicator> GetQualityIndicatorsForWaterPlant([FromUri] int waterPlantId)
        {
            var result = _dbAccessor.GetQualityIndicators().Where(x => x.waterPlantId != null && x.waterPlantId == waterPlantId);
            return result.ToList();
        }
    }
}
