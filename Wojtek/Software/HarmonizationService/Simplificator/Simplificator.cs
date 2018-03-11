using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataBaseAccessor;
using Interfaces;
using Library.HarmonizedObjects;

namespace Simplificator
{
    public class Simplificator : ISimplificator
    {
        #region Private Members

        private readonly IDataBaseViewAccessor _dbAccessor;
        #endregion

        #region Constructors

        public Simplificator()
        {
            _dbAccessor = new DbViewAccessor();
        }
        #endregion

        #region Interface Methods

        /// <summary>
        /// Removes blacklisted treatment steps and quality indicators
        /// </summary>
        /// <param name="wwtp">water treatment plant to clean</param>
        /// <returns>cleaned water plant</returns>
        public WasteWaterTreatmentPlant Simplify(WasteWaterTreatmentPlant wwtp)
        {
            var blackList = _dbAccessor.GetBlackList().Select(x => x.propertyName).ToList();
            if(wwtp.TreatmentSteps != null) wwtp.TreatmentSteps = CleanTreatmentSteps(wwtp.TreatmentSteps, blackList);
            if(wwtp.GeneralIndicators != null) wwtp.GeneralIndicators = CleanQualityIndicators(wwtp.GeneralIndicators, blackList);

            return wwtp;
        }

        #endregion

        #region Private Methods

        private List<WaterTreatmentStep> CleanTreatmentSteps(List<WaterTreatmentStep> treatmentSteps, List<string> blackList)
        {
            var cleanedTreatmentSteps = new List<WaterTreatmentStep>();
            foreach (var treatmentStep in treatmentSteps)
            {
                if(blackList.Contains(treatmentStep.Name)) continue;
                if(treatmentStep.QualityIndicators != null) treatmentStep.QualityIndicators = CleanQualityIndicators(treatmentStep.QualityIndicators, blackList);
                cleanedTreatmentSteps.Add(treatmentStep);
            }

            return cleanedTreatmentSteps;
        }

        private List<WaterQualityIndicator> CleanQualityIndicators(List<WaterQualityIndicator> qualityIndicators, List<string> blackList)
        {
            var cleanedQualityIndicators = new List<WaterQualityIndicator>();
            foreach (var qualityIndicator in qualityIndicators)
            {
                if(blackList.Contains(qualityIndicator.Name)) continue;
                cleanedQualityIndicators.Add(qualityIndicator);
            }

            return cleanedQualityIndicators;
        }

        #endregion
    }
}
