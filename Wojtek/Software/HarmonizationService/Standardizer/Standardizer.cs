using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataBaseAccessor;
using Interfaces;
using Library.HarmonizedObjects;

namespace Standardizer
{
    public class Standardizer : IStandardizer
    {
        #region

        private IDbSetter _dbSetter;
        private IUtilityDbAccessor _dbUtilityAccessor;
        private IDataBaseViewAccessor _dbViewAccessor;

        #endregion

        #region Constructors

        public Standardizer()
        {
            _dbSetter = new DataBaseSetter();
            _dbViewAccessor = new DbViewAccessor();
            _dbUtilityAccessor = new UtilityDbAccessor();
        }

        #endregion

        #region Public Methods

        public void StandardizeAndStore(WasteWaterTreatmentPlant wwtp)
        {
            var waterPlantId = _dbUtilityAccessor.GetIdForWwtpName(wwtp.Name);

            if (wwtp.TreatmentSteps != null)
            {
                foreach (var treatmentStep in wwtp.TreatmentSteps)
                {
                    //check if treatmentstep exists for the waterplant - if not - insert it
                    int treatmentStepId;
                    if (_dbUtilityAccessor.TreatmentStepTypeForWwtpExists(treatmentStep.Name, wwtp.Name))
                    {
                        treatmentStepId = _dbUtilityAccessor.GetTreatmentStepIdForTypeAndWwtp(treatmentStep.Name, wwtp.Name);
                    }
                    else
                    {
                        var treatmentStepTypeId = _dbUtilityAccessor.GetIdForTreatmentType(treatmentStep.Name);
                        treatmentStepId = _dbSetter.SetTreatmentStep(treatmentStepTypeId, waterPlantId);
                    }

                    InsertQualityIndicators(null, treatmentStepId, treatmentStep.QualityIndicators);
                }
            }

            if (wwtp.GeneralIndicators != null)
            {
                InsertQualityIndicators(waterPlantId, null, wwtp.GeneralIndicators);
            }

        }
        #endregion

        #region Private Methods

        private void InsertQualityIndicators(int? waterPlantId, int? treatmentStepId, List<WaterQualityIndicator> qualityIndicators)
        {
            if (qualityIndicators == null) return;

            foreach (var qualityIndicator in qualityIndicators)
            {
                if (waterPlantId != null)
                {
                    if (_dbUtilityAccessor.WwtpQualityIndicatorEntryExists(
                        qualityIndicator.TimeStamp,
                        qualityIndicator.Name,
                        (int) waterPlantId)) continue;
                }

                if (treatmentStepId != null)
                {
                    if (_dbUtilityAccessor.QualityIndicatorEntryExists(
                        qualityIndicator.TimeStamp,
                        qualityIndicator.Name,
                        (int)treatmentStepId)) continue;
                }

                var unitId = _dbUtilityAccessor.GetUnitIdForName(qualityIndicator.Unit);
                var qualityIndicatorTypeId = _dbUtilityAccessor.GetIndicatorTypeIdForName(qualityIndicator.Name);
                _dbSetter.SetQualityIndicator(qualityIndicatorTypeId, qualityIndicator.Value, qualityIndicator.TimeStamp,
                    unitId, waterPlantId, treatmentStepId);
            }
        }

        #endregion
    }
}
