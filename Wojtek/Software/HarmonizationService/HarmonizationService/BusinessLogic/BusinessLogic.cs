using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Web;
using Amazon;
using Amazon.S3;
using Amazon.S3.Model;
using ExcelDataReader;
using FormatConverter;
using Interfaces;
using Library.HarmonizationApi;
using Library.HarmonizedObjects;


namespace HarmonizationService.BusinessLogic
{
    public class BusinessLogic : IBusinessLogic
    {
        #region Private Members

        private readonly IConverter _converter;
        private readonly IPreSimplificator _preSimplificator;
        private readonly IHarmonizer _harmonizer;
        private readonly ISimplificator _simplificator;
        private readonly IStandardizer _standardizer;

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

        public WasteWaterTreatmentPlant HarmonizeData(Stream dataBaseStream, FileFormat fileFormat, string waterPlant, string treatmentStep)
        {
            // 1. Read DataSet from Stream
            DataSet tableDataSet = null;
            if (fileFormat == FileFormat.XLS || fileFormat == FileFormat.XLSX)
            {
                using (var reader = ExcelReaderFactory.CreateReader(dataBaseStream))
                {
                    tableDataSet = reader.AsDataSet();
                }
            }
            else if (fileFormat == FileFormat.CSV)
            {
                using (var reader = ExcelReaderFactory.CreateCsvReader(dataBaseStream))
                {
                    tableDataSet = reader.AsDataSet();
                }
            }

            // 2. Convert DataSet
            var conversionResult = _converter.ConvertTableObject(tableDataSet);

            // 3. Presimplify Table
            var presimplifiedResult = _preSimplificator.PreSimplyfyTableObject(conversionResult);

            // 4. Harmonize Table
            var harmonizedResult = _harmonizer.HarmonizeTableObject(presimplifiedResult, waterPlant, treatmentStep);

            // 5. Simplify 
            var simplifiedResult = _simplificator.Simplify(harmonizedResult);
            
            // 6. Standardize and store
            var standardizedResult = _standardizer.StandardizeAndStore(simplifiedResult);
           
            return standardizedResult;
        }

        public WasteWaterTreatmentPlant HarmonizeData(string jsonObject, string waterPlant = null, string treatmentStep = null)
        {
            // 1. not required
            // 2. Convert Tree
            var conversionResult = _converter.ConvertTreeObject(jsonObject);

            // 3. Presimplify Tree
            var presimplifiedResult = _preSimplificator.PreSimplyfyJsonObject(conversionResult);

            // 4. Harmonize Tree
            var harmonizedResult = _harmonizer.HarmonizeJsonObject(presimplifiedResult, waterPlant, treatmentStep);

            // 5.Simplify
            var simplifiedResult = _simplificator.Simplify(harmonizedResult);

            // 6. Standardize and store
            var standardizedResult = _standardizer.StandardizeAndStore(simplifiedResult);

            return standardizedResult;
        }

        #endregion

    }
}