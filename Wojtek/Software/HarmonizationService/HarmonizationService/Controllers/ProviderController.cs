using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Cryptography.X509Certificates;
using System.Web;
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
            try
            {
                var result = _dbAccessor.GetWaterPlants();
                return result.ToList();
            }
            catch (Exception e)
            {
                throw new HttpException((int)HttpStatusCode.BadRequest, $"Data could not be retreived. Reason: {e.Message}");
            }
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
            try
            {
                var result = _dbAccessor.GetTreatmentSteps().Where(x => x.waterPlantId == waterPlantId);
                return result.ToList();
            }
            catch (Exception e)
            {
                throw new HttpException((int)HttpStatusCode.BadRequest, $"Data could not be retreived. Reason: {e.Message}");
            }
        }

        /// <summary>
        /// Returns all qualityindicator types for a specific step in a specific water treatment plant
        /// </summary>
        /// <param name="waterPlantId">specific waterplant the indicator is returned for</param>
        /// <param name="treatmentStepTypeId">specific treatment step the indicator is returned for</param>
        /// <returns></returns>
        [HttpGet]
        [Route("waterPlants/{waterplantId}/treatmentStepTypes/{treatmentStepTypeId}/qualityIndicatorTypes")]
        [SwaggerResponseRemoveDefaults]
        [SwaggerResponse(HttpStatusCode.OK, Type = typeof(List<vQualityIndicator>))]
        public List<vQualityIndicatorType> GetQualityIndicatorTypes([FromUri] int waterPlantId, [FromUri] int treatmentStepTypeId)
        {
            try
            {
                var treatmentStepOnWwtp = _dbAccessor.GetTreatmentSteps().Where(x => x.waterPlantId == waterPlantId && x.treatmentStepTypeId == treatmentStepTypeId).Select(x=>x.treatmentStepId).FirstOrDefault();
                var qualityIndicators = _dbAccessor.GetQualityIndicators().Where(x=>x.treatmentStepId != null && x.treatmentStepId == treatmentStepOnWwtp).GroupBy(x=>x.indicatorTypeId);
                var qualityIndicatorGrouping = qualityIndicators.ToList();
                var qualityIndicatorTypeIds = new List<int>();
                foreach (var qualityIndicator in qualityIndicatorGrouping)
                {
                    qualityIndicatorTypeIds.Add(qualityIndicator.Key);
                }

                var qualityIndicatorTypes = _dbAccessor.GetQualityIndicatorTypes()
                    .Where(x => qualityIndicatorTypeIds.Contains(x.indicatorTypeId));
                return qualityIndicatorTypes.ToList();
            }
            catch (Exception e)
            {
                throw new HttpException((int)HttpStatusCode.BadRequest, $"Data could not be retreived. Reason: {e.Message}");
            }
        }

        /// <summary>
        /// Returns all qualityindicator types assigned directly to a specific waterplant
        /// </summary>
        /// <param name="waterPlantId">specific waterplant the indicator is returned for</param>
        /// <returns></returns>
        [HttpGet]
        [Route("waterPlants/{waterplantId}/qualityIndicatorTypes")]
        [SwaggerResponseRemoveDefaults]
        [SwaggerResponse(HttpStatusCode.OK, Type = typeof(List<vQualityIndicator>))]
        public List<vQualityIndicatorType> GetQualityIndicatorsForWaterPlant([FromUri] int waterPlantId)
        {
            try
            {
                var qualityIndicators = _dbAccessor.GetQualityIndicators().Where(x => x.waterPlantId != null && x.waterPlantId == waterPlantId).GroupBy(x => x.indicatorTypeId);
                var qualityIndicatorGrouping = qualityIndicators.ToList();
                var qualityIndicatorTypeIds = new List<int>();
                foreach (var qualityIndicator in qualityIndicatorGrouping)
                {
                    qualityIndicatorTypeIds.Add(qualityIndicator.Key);
                }

                var qualityIndicatorTypes = _dbAccessor.GetQualityIndicatorTypes()
                    .Where(x => qualityIndicatorTypeIds.Contains(x.indicatorTypeId));
                return qualityIndicatorTypes.ToList();
            }
            catch (Exception e)
            {
                throw new HttpException((int)HttpStatusCode.BadRequest, $"Data could not be retreived. Reason: {e.Message}");
            }
        }

        /// <summary>
        /// Returns all qualityindicators for a specific step in a specific water treatment plant
        /// </summary>
        /// <param name="waterPlantId">specific waterplant the indicator is returned for</param>
        /// <param name="treatmentStepTypeId">specific treatment step the indicator is returned for</param>
        /// <param name="qualityIndicatorTypeId"></param>
        /// <param name="startDateTime"></param>
        /// <param name="endDateTime"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("waterPlants/{waterplantId}/treatmentStepTypes/{treatmentStepTypeId}/qualityIndicatorTypes/{qualityIndicatorTypeId}/data")]
        [SwaggerResponseRemoveDefaults]
        [SwaggerResponse(HttpStatusCode.OK, Type = typeof(List<vQualityIndicator>))]
        public List<vQualityIndicator> GetTreatmentStepData([FromUri] int waterPlantId, [FromUri] int treatmentStepTypeId, [FromUri] int qualityIndicatorTypeId, [FromUri]DateTime? startDateTime = null, [FromUri]DateTime? endDateTime = null)
        {
            try
            {
                var treatmentStepOnWwtp = _dbAccessor.GetTreatmentSteps().Where(x => x.waterPlantId == waterPlantId && x.treatmentStepTypeId == treatmentStepTypeId).Select(x => x.treatmentStepId).FirstOrDefault();

                var qualityIndicatorData = _dbAccessor.GetQualityIndicators().Where(
                    x => x.treatmentStepId != null &&
                         x.treatmentStepId == treatmentStepOnWwtp &&
                         x.indicatorTypeId == qualityIndicatorTypeId);

                if (startDateTime != null) qualityIndicatorData = qualityIndicatorData.Where(x => x.timeStamp > startDateTime);
                if (endDateTime != null) qualityIndicatorData = qualityIndicatorData.Where(x => x.timeStamp < endDateTime);

                return qualityIndicatorData.ToList();
            }
            catch (Exception e)
            {
                throw new HttpException((int)HttpStatusCode.BadRequest, $"Data could not be retreived. Reason: {e.Message}");
            }
        }

        /// <summary>
        /// Returns all qualityindicators assigned directly to a specific waterplant
        /// </summary>
        /// <param name="waterPlantId">specific waterplant the indicator is returned for</param>
        /// <param name="qualityIndicatorTypeId"></param>
        /// <param name="startDateTime"></param>
        /// <param name="endDateTime"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("waterPlants/{waterplantId}/qualityIndicatorTypes/{qualityIndicatorTypeId}/data")]
        [SwaggerResponseRemoveDefaults]
        [SwaggerResponse(HttpStatusCode.OK, Type = typeof(List<vQualityIndicator>))]
        public List<vQualityIndicator> GetWaterPlantData([FromUri] int waterPlantId, [FromUri] int qualityIndicatorTypeId, [FromUri]DateTime? startDateTime = null, [FromUri]DateTime? endDateTime = null)
        {


            try
            {
                var qualityIndicatorData = _dbAccessor.GetQualityIndicators().Where(
                    x => x.treatmentStepId != null &&
                         x.waterPlantId == waterPlantId &&
                         x.indicatorTypeId == qualityIndicatorTypeId);

                if (startDateTime != null) qualityIndicatorData = qualityIndicatorData.Where(x => x.timeStamp > startDateTime);
                if (endDateTime != null) qualityIndicatorData = qualityIndicatorData.Where(x => x.timeStamp < endDateTime);

                return qualityIndicatorData.ToList();
            }
            catch (Exception e)
            {
                throw new HttpException((int)HttpStatusCode.BadRequest, $"Data could not be retreived. Reason: {e.Message}");
            }

        }
    }
}
