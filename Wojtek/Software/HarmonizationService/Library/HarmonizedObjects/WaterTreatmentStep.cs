using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Library.HarmonizedObjects
{
    public class WaterTreatmentStep
    {
        [JsonProperty(PropertyName = "name", Required = Required.Always)]
        public string Name { get; set; }

        [JsonProperty(PropertyName = "qualityIndicators", Required = Required.Always)]
        public List<WaterQualityIndicator> QualityIndicators;
    }
}
