using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FormatConverter;
using Interfaces;
using Library.HarmonizationApi;

namespace HarmonizationService.BusinessLogic
{
    public class BusinessLogic : IBusinessLogic
    {
        #region Private Members

        private IConverter _converter;
        private IPreSimplificator _preSimplificator;
        private IHarmonizer _harmonizer;
        private ISimplificator _simplificator;
        private IStandardizer _standardizer;
        #endregion

        #region Constructors

        public BusinessLogic()
        {
            _converter = new Converter();
            _preSimplificator = new PreSimplificator.PreSimplificator();
            _harmonizer = new Harmonizer.Harmonizer();
            _simplificator = new Simplificator.Simplificator();
            _standardizer = new Standardizer.Standardizer();
        }

        #endregion

        #region Public Methods
        public string HarmonizeData(HarmonizationRequest harmRequest)
        {
            throw new NotImplementedException();
        }

        #endregion

    }
}