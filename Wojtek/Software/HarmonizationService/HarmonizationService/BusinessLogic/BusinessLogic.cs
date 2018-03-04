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

        public string HarmonizeData(Stream dataBaseStream, FileFormat fileFormat, string waterPlant, string treatmentStep)
        {
            //
            DataSet tableDataSet;
            if (fileFormat == FileFormat.XLS)
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

            return "harmonization was successful";
        }

        public string HarmonizeData(string jsonObject, string waterPlant = null, string treatmentStep = null)
        {
            _converter.ConvertTreeObject(jsonObject, waterPlant, treatmentStep);
            return null; //TODO return something useful
        }

        #endregion

    }
}