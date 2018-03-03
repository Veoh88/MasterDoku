using System.Collections.Generic;
using System.Net;
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
        [Route("harmonize")]
        [SwaggerResponseRemoveDefaults]
        [SwaggerResponse(HttpStatusCode.OK)]
        public string HarmonizeData(HarmonizationRequest harmRequest)
        {
            var result = _businessLogic.HarmonizeData(harmRequest);
            return result;
        }
        #endregion
    }
}
