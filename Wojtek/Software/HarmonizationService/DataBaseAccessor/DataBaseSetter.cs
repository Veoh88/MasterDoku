using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBaseAccessor
{
    public class DataBaseSetter
    {
        #region Private Members

        private readonly HarmonizationServiceEntities _entityFrameworkAccessor;

        #endregion
        #region Constructors

        public DataBaseSetter()
        {
            _entityFrameworkAccessor = new HarmonizationServiceEntities();   
        }
        #endregion

        #region Public Methods

        public void SetBlackList(string propertyName)
        {
            _entityFrameworkAccessor.SetBlackList(propertyName);
        }

        public int SetCountry(int countryId, string countryName)
        {
            _entityFrameworkAccessor.SetCountry(countryName: countryName, countryId: countryId);
            return _entityFrameworkAccessor.vCountry.FirstOrDefault(x => x.name == countryName).countryId;
        }

        public int SetLocation(int countryId, string locationName)
        {
            _entityFrameworkAccessor.SetLocation(countryId: countryId, locationName: locationName, locationId: null);
            return _entityFrameworkAccessor.vLocation.FirstOrDefault(x => x.town ==locationName && x.countryId == countryId).locationId;
        }

        public int SetQualityIndicator(int indicatorTypeId, double value, DateTime dateTime, int unitId, int? waterPlantId = null, int? treatmentStepId = null)
        {
            _entityFrameworkAccessor.SetQualityIndicator(waterPlantId, treatmentStepId, indicatorTypeId, value,
                dateTime, unitId);
            return _entityFrameworkAccessor.vQualityIndicator.FirstOrDefault
                (x => dateTime == DateTime.FromBinary(BitConverter.ToInt64(x.timeStamp, 0)) && 
                      x.indicatorTypeId == indicatorTypeId)
                .qualityIndicatorId;
        }

        public void SetQualityIndicatorTypeMapping(int indicatorTypeId, string name)
        {
            _entityFrameworkAccessor.SetQualityIndicatorTypeMapping(indicatorTypeId, name);
        }

        public int SetSupplier(string name)
        {
            _entityFrameworkAccessor.SetSupplier(name: name, supplierId: null);
            return _entityFrameworkAccessor.vSupplier.FirstOrDefault(x => x.name == name).supplierId;
        }

        public int SetTreatmentStep(int treatmentStepTypeId, int waterPlantId)
        {
            _entityFrameworkAccessor.SetTreatmentStep(treatmentStepTypeId, waterPlantId);
            return _entityFrameworkAccessor.vTreatmentStep
                .FirstOrDefault(x => x.treatmentStepId == treatmentStepTypeId && x.waterPlantId == waterPlantId)
                .treatmentStepId;
        }

        public int SetTreatmentStepType(string name)
        {
            _entityFrameworkAccessor.SetTreatmentStepType(name);
            return _entityFrameworkAccessor.vTreatmentStepType.FirstOrDefault(x => x.treatmentStepTypeName == name)
                .treatmentStepId;
        }

        public int SetUnit(string name)
        {
            _entityFrameworkAccessor.SetUnit(name);
            return _entityFrameworkAccessor.vUnit.FirstOrDefault(x => x.unitName == name).unitId;
        }

        public int SetWaterPlant(string waterPlantName, int locationId, int supplierId)
        {
            _entityFrameworkAccessor.SetWaterPlant(waterPlantName, locationId, supplierId);
            return _entityFrameworkAccessor.vWaterPlant.FirstOrDefault(x => x.waterPlantName == waterPlantName)
                .waterPlantId;
        }

        public void SetWaterPlantMapping(int waterPlantId, string waterPlantAlias, string realName)
        {
            _entityFrameworkAccessor.SetWaterPlantMapping(waterPlantId, waterPlantAlias, realName);
        }
        #endregion
    }
}
