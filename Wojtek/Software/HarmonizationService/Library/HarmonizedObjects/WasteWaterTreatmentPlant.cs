using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Library.HarmonizedObjects
{
    [JsonObject(Title = "waterTreatmentPlant")]
    public class WasteWaterTreatmentPlant
    {
        [JsonProperty(PropertyName = "name", Required = Required.Default, DefaultValueHandling = DefaultValueHandling.Ignore)]
        public string Name { get; set; }

        [JsonProperty(PropertyName = "location", Required = Required.Default, DefaultValueHandling = DefaultValueHandling.Ignore)]
        public string Location { get; set; }

        [JsonProperty(PropertyName = "treatmentSteps", Required = Required.Default, DefaultValueHandling = DefaultValueHandling.Ignore)]
        public List<WaterTreatmentStep> TreatmentSteps { get; set; }

        [JsonProperty(PropertyName = "generalIndicators", Required = Required.Default, DefaultValueHandling = DefaultValueHandling.Ignore)]
        public List<WaterQualityIndicator> GeneralIndicators { get; set; }
    }
}
