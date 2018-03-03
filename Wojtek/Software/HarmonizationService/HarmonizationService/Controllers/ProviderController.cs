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

        [HttpGet]
        [Route("waterPlants")]
        [SwaggerResponseRemoveDefaults]
        [SwaggerResponse(HttpStatusCode.OK, Type = typeof(List<vWaterPlant>))]
        public List<vWaterPlant> GetWaterPlants()
        {
            var result = _dbAccessor.GetWaterPlants();
            return result.ToList();
        }

        [HttpGet]
        [Route("waterPlants/{waterplantId}/treatmentSteps")]
        [SwaggerResponseRemoveDefaults]
        [SwaggerResponse(HttpStatusCode.OK, Type = typeof(List<vTreatmentStep>))]
        public List<vTreatmentStep> GetTreatmentSteps([FromUri] int waterPlantId)
        {
            var result = _dbAccessor.GetTreatmentSteps().Where(x => x.waterPlantId == waterPlantId);
            return result.ToList();
        }

        [HttpGet]
        [Route("waterPlants/{waterplantId}/treatmentSteps/{treatmentStepId}/qualityIndicators")]
        [SwaggerResponseRemoveDefaults]
        [SwaggerResponse(HttpStatusCode.OK, Type = typeof(List<vQualityIndicator>))]
        public List<vQualityIndicator> GetQualityIndicators([FromUri] int waterPlantId, [FromUri] int treatmentStepId)
        {
            var result = _dbAccessor.GetQualityIndicators().Where(x => x.waterPlantId == waterPlantId && x.treatmentStepId == treatmentStepId);
            return result.ToList();
        }
    }
}
