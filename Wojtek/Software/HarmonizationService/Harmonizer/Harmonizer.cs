using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataBaseAccessor;
using Interfaces;
using Library.ConvertedObjects;
using Library.HarmonizedObjects;

namespace Harmonizer
{
    public class Harmonizer : IHarmonizer
    {
        #region Private Members
        private readonly ITreeHarmonizer _treeHarmonizer;
        private readonly ITableHarmonizer _tableHarmonizer;

        private readonly IUtilityDbAccessor _dbUtilAccessor;

        private readonly Dictionary<string, string> _aliasToRealNameDict;
        #endregion

        #region Constructors

        public Harmonizer()
        {
            _tableHarmonizer = new TableHarmonizer();
            _treeHarmonizer = new TreeHarmonizer();

            _dbUtilAccessor = new UtilityDbAccessor();
        }

        #endregion

        #region Public Methods
        public WasteWaterTreatmentPlant HarmonizeTableObject(TableFormattedObject tableObject, string waterPlant, string treatmentStep)
        {
            var wwtp = _tableHarmonizer.HarmonizeTable(tableObject);

            //fill remaining objects
            if (int.TryParse(treatmentStep, out var treatmentTypeId))
            {
                treatmentStep = _dbUtilAccessor.GetTreatmentTypeForId(treatmentTypeId);
            }

            if (int.TryParse(waterPlant, out var wwtpId))
            {
                waterPlant = _dbUtilAccessor.GetWwtpNameForId(wwtpId);
            }

            wwtp.TreatmentSteps[0].Name = treatmentStep;
            wwtp.Name = waterPlant;

            return wwtp;

        }

        public WasteWaterTreatmentPlant HarmonizeJsonObject(TreeFormattedObject treeObject, string waterPlant, string treatmentStep)
        {
            int? retreivedWaterPlantId = null, retreivedTreatmentStepTypeId = null;

            //check if waterPlantId can be found
            if (!string.IsNullOrEmpty(waterPlant))
            {
                //check if its numeric
                if (int.TryParse(waterPlant, out var waterPlantId))
                {
                    retreivedWaterPlantId = waterPlantId;
                    waterPlant = _dbUtilAccessor.GetWwtpNameForId(waterPlantId);
                }
                else
                    retreivedWaterPlantId = _dbUtilAccessor.GetIdForWwtpName(waterPlant);
            }

            //check if treatmentStepTypeId can be found
            if (!string.IsNullOrEmpty(treatmentStep))
            {
                //check if its numeric
                if (int.TryParse(treatmentStep, out var treatmentStepTypeId))
                {
                    retreivedTreatmentStepTypeId = treatmentStepTypeId;
                    treatmentStep = _dbUtilAccessor.GetTreatmentTypeForId(treatmentStepTypeId);
                }
                    
                else
                    retreivedTreatmentStepTypeId = _dbUtilAccessor.GetIdForWwtpName(waterPlant);
            }

            var wwtp = _treeHarmonizer.HarmonizeTree(treeObject, retreivedWaterPlantId, retreivedTreatmentStepTypeId);
            if (string.IsNullOrEmpty(wwtp.Name)) wwtp.Name = waterPlant;
            if (wwtp.TreatmentSteps != null && !wwtp.TreatmentSteps.Any() &&
                string.IsNullOrEmpty(wwtp.TreatmentSteps.First().Name))
                wwtp.TreatmentSteps.First().Name = treatmentStep;

            return wwtp;
        }
        #endregion

        #region Helpers

        

        #endregion
    }
}
