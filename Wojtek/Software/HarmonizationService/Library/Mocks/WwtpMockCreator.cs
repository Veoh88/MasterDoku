using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library.HarmonizedObjects;

namespace Library.Mocks
{
    public static class WwtpMockCreator
    {
        public static WasteWaterTreatmentPlant CreateWwtpMock()
        {
            //WWTP WaterPlant
            var wwtpMock = new WasteWaterTreatmentPlant();
            wwtpMock.Location = "Germany";
            wwtpMock.Name = "MockPlant";
            wwtpMock.TreatmentSteps = new List<WaterTreatmentStep>();

            //WWTP TreatmentSteps
            var waterTreatmentStep1 = new WaterTreatmentStep
            {
                Name = "TreatmentStep1",
                QualityIndicators = new List<WaterQualityIndicator>()
            };

            var waterTreatmentStep2 = new WaterTreatmentStep
            {
                Name = "TreatmentStep2",
                QualityIndicators = new List<WaterQualityIndicator>()
            };

            //WWTP QualityIndicators
            var qualityIndicator1 = new WaterQualityIndicator
            {
                Name = "QualityIndicator1",
                TimeStamp = DateTime.Now,
                Unit = "mg/L",
                Value = 1.01
            };

            var qualityIndicator2 = new WaterQualityIndicator
            {
                Name = "QualityIndicator2",
                TimeStamp = DateTime.Now,
                Unit = "mg/L",
                Value = 1.02
            };

            var qualityIndicator3 = new WaterQualityIndicator
            {
                Name = "QualityIndicator3",
                TimeStamp = DateTime.Now,
                Unit = "mg/L",
                Value = 1.03
            };

            var qualityIndicator4 = new WaterQualityIndicator
            {
                Name = "QualityIndicator4",
                TimeStamp = DateTime.Now,
                Unit = "mg/L",
                Value = 1.04
            };

            //Assignments
            waterTreatmentStep1.QualityIndicators.Add(qualityIndicator1);
            waterTreatmentStep1.QualityIndicators.Add(qualityIndicator2);

            waterTreatmentStep2.QualityIndicators.Add(qualityIndicator3);
            waterTreatmentStep2.QualityIndicators.Add(qualityIndicator4);

            wwtpMock.TreatmentSteps.Add(waterTreatmentStep1);
            wwtpMock.TreatmentSteps.Add(waterTreatmentStep2);

            return wwtpMock;
        }
    }
}
