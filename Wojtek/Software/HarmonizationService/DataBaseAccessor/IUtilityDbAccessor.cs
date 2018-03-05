using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBaseAccessor
{
    public interface IUtilityDbAccessor
    {
        string GetDefaultUnitForIndicator(string indicator);
        int GetUnitIdForName(string unitName);
        string GetIndicatorForAlias(string alias);
        int GetIndicatorTypeIdForName(string indicatorTypeName);
        string GetWwtpNameForId(int id);
        int GetIdForWwtpName(string wwtpName);
        string GetTreatmentTypeForId(int id);
        int GetIdForTreatmentType(string treatmentType);
        bool TreatmentStepTypeForWwtpExists(string treatmentType, string wwtpName);
        int GetTreatmentStepIdForTypeAndWwtp(string treatmentType, string wwtpName);
        bool QualityIndicatorEntryExists(DateTime dateTime, string indicatorType, int treatmentStepId);
        bool WwtpQualityIndicatorEntryExists(DateTime dateTime, string indicatorType, int waterPlantNameId);
        Dictionary<string, string> GetAliasToRealNameOnWwtpDict(int waterPlantId);

    }
}
