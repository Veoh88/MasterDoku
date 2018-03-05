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
            var wwtp = _treeHarmonizer.HarmonizeTree(treeObject);

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
        #endregion

        #region Helpers

        

        #endregion
    }
}
