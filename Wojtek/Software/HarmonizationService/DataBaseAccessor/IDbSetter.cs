using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBaseAccessor
{
    public interface IDbSetter
    {
        void SetBlackList(string propertyName);

        int SetCountry(int countryId, string countryName);

        int SetLocation(int countryId, string locationName);

        int SetQualityIndicator(int indicatorTypeId, double value, DateTime dateTime, int unitId,
            int? waterPlantId = null, int? treatmentStepId = null);

        void SetQualityIndicatorTypeMapping(int indicatorTypeId, string name);

        int SetSupplier(string name);

        int SetTreatmentStep(int treatmentStepTypeId, int waterPlantId);

        int SetTreatmentStepType(string name);

        int SetUnit(string name);

        int SetWaterPlant(string waterPlantName, int locationId, int supplierId);

        void SetWaterPlantMapping(int waterPlantId, string waterPlantAlias, string realName);

        void SetQualityIndicatorType(string typeName, int? defaultUnitId);
    }
}
