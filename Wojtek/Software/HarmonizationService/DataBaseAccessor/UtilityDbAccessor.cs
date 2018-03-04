using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace DataBaseAccessor
{
    public class UtilityDbAccessor : IUtilityDbAccessor
    {
        #region Private Members

        private IDataBaseViewAccessor _dbViewAccessor;
        #endregion

        #region Constructors

        public UtilityDbAccessor()
        {
            _dbViewAccessor = new DbViewAccessor();
        }

        #endregion
        public string GetDefaultUnitForIndicator(string indicator)
        {
            return _dbViewAccessor.GetQualityIndicatorTypes().FirstOrDefault(x => x.indicatorName == indicator)
                .unitName;
        }

        public int GetUnitIdForName(string unitName)
        {
            return _dbViewAccessor.GetUnit().FirstOrDefault(x => x.unitName == unitName).unitId;
        }

        public string GetIndicatorForAlias(string alias)
        {
            return _dbViewAccessor.GetQualityIndicatorTypeMappings().FirstOrDefault(x => x.indicatorAlias == alias).indicatorName;
        }

        public int GetIndicatorTypeIdForName(string indicatorTypeName)
        {
            return _dbViewAccessor.GetQualityIndicatorTypes().FirstOrDefault(x => x.indicatorName == indicatorTypeName)
                .indicatorTypeId;
        }

        public string GetWwtpNameForId(int id)
        {
            return _dbViewAccessor.GetWaterPlants().FirstOrDefault(x => x.waterPlantId == id).waterPlantName;
        }

        public int GetIdForWwtpName(string wwtpName)
        {
            return _dbViewAccessor.GetWaterPlants().FirstOrDefault(x => x.waterPlantName == wwtpName).waterPlantId;
        }

        public string GetTreatmentTypeForId(int id)
        {
            return _dbViewAccessor.GetTreatmentStepTypes().FirstOrDefault(x => x.treatmentStepId == id)
                .treatmentStepTypeName;
        }

        public int GetIdForTreatmentType(string treatmentType)
        {
            return _dbViewAccessor.GetTreatmentStepTypes().FirstOrDefault(x => x.treatmentStepTypeName == treatmentType)
                .treatmentStepId;
        }

        public bool TreatmentStepTypeForWwtpExists(string treatmentType, string wwtpName)
        {
            var result = _dbViewAccessor.GetTreatmentSteps().FirstOrDefault(x =>
                x.treatmentStepTypeName == treatmentType && x.waterPlantName == wwtpName);
            return result != null;
        }

        public int GetTreatmentStepIdForTypeAndWwtp(string treatmentType, string wwtpName)
        {
            return _dbViewAccessor.GetTreatmentSteps().FirstOrDefault(x =>
                x.treatmentStepTypeName == treatmentType && x.waterPlantName == wwtpName).treatmentStepId;
        }

        public bool QualityIndicatorEntryExists(DateTime dateTime, string indicatorType, int treatmentStepId)
        {
            return _dbViewAccessor.GetQualityIndicators().Any(x =>
                x.timeStamp == dateTime && x.indicatorName == indicatorType && x.treatmentStepId == treatmentStepId);
        }

        public bool WwtpQualityIndicatorEntryExists(DateTime dateTime, string indicatorType, int waterPlantId)
        {
            return _dbViewAccessor.GetQualityIndicators().Any(x =>
                x.timeStamp == dateTime && x.indicatorName == indicatorType && x.waterPlantId == waterPlantId);

        }
    }
}
