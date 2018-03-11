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
            try
            {
                return _dbViewAccessor.GetQualityIndicatorTypes().FirstOrDefault(x => x.indicatorName == indicator)
                    .unitName;
            }
            catch (Exception e)
            {
                throw new Exception($"Could not retreive the default unit for indicator [{indicator}]");
            }
        }

        public int GetUnitIdForName(string unitName)
        {
            try
            {
                return _dbViewAccessor.GetUnit().FirstOrDefault(x => x.unitName == unitName).unitId;

            }
            catch (Exception e)
            {
                throw new Exception($"Could not retreive the unitId for the unit [{unitName}]");
            }
        }

        public string GetIndicatorForAlias(string alias)
        {
            try
            {
                return _dbViewAccessor.GetQualityIndicatorTypeMappings().FirstOrDefault(x => x.indicatorAlias == alias).indicatorName;

            }
            catch (Exception e)
            {
                throw new Exception($"Could not retreive the real name for the alias [{alias}]");

            }
        }

        public int GetIndicatorTypeIdForName(string indicatorTypeName)
        {
            try
            {
                return _dbViewAccessor.GetQualityIndicatorTypes().FirstOrDefault(x => x.indicatorName == indicatorTypeName)
                    .indicatorTypeId;
            }
            catch (Exception e)
            {
                throw new Exception($"Could not retreive the indicatorTypeId for the indicatorTypeName [{indicatorTypeName}]");
            }
        }

        public string GetWwtpNameForId(int id)
        {
            try
            {
                return _dbViewAccessor.GetWaterPlants().FirstOrDefault(x => x.waterPlantId == id).waterPlantName;

            }
            catch (Exception e)
            {
                throw new Exception($"Could not retreive the wastewater treatment plant name for the id [{id}]");
            }
        }

        public int GetIdForWwtpName(string wwtpName)
        {
            try
            {
                return _dbViewAccessor.GetWaterPlants().FirstOrDefault(x => x.waterPlantName == wwtpName).waterPlantId;
            }
            catch (Exception e)
            {
                throw new Exception($"Could not retreive the wastewater treatment plant id for the name [{wwtpName}]");

            }
        }

        public string GetTreatmentTypeForId(int id)
        {
            try
            {
                return _dbViewAccessor.GetTreatmentStepTypes().FirstOrDefault(x => x.treatmentStepId == id)
                    .treatmentStepTypeName;
            }
            catch (Exception e)
            {
                throw new Exception($"Could not retreive the treatment step type name for the id [{id}]");
            }
        }

        public int GetIdForTreatmentType(string treatmentType)
        {
            try
            {
                return _dbViewAccessor.GetTreatmentStepTypes().FirstOrDefault(x => x.treatmentStepTypeName == treatmentType)
                    .treatmentStepId;
            }
            catch (Exception e)
            {
                throw new Exception($"Could not retreive the treatment type id for the name [{treatmentType}]");

            }
        }

        public bool TreatmentStepTypeForWwtpExists(string treatmentType, string wwtpName)
        {
            try
            {
                var result = _dbViewAccessor.GetTreatmentSteps().FirstOrDefault(x =>
                    x.treatmentStepTypeName == treatmentType && x.waterPlantName == wwtpName);
                return result != null;
            }
            catch (Exception e)
            {
                throw new Exception($"Could not check if treatment step type [{treatmentType}] exists for the waterplant with name [{wwtpName}]");

            }
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

        public Dictionary<string, string> GetAliasToRealNameOnWwtpDict(int waterPlantId)
        {
            var queryResult = _dbViewAccessor.GetWaterPlantPropertyMapper().Where(x => x.waterPlantId == waterPlantId);
            var resultDict = queryResult.ToDictionary(x => x.nameOnWaterplant, x => x.realName);

            return resultDict;
        }
    }
}
