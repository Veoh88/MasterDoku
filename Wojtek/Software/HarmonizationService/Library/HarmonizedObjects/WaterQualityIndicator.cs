using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Library.HarmonizedObjects
{
    public class WaterQualityIndicator
    {
        [JsonProperty(PropertyName = "name", Required = Required.Default, DefaultValueHandling = DefaultValueHandling.Ignore)]
        public string Name { get; set; }

        [JsonProperty(PropertyName = "timestamp", Required = Required.Default, DefaultValueHandling = DefaultValueHandling.Ignore)]
        public DateTime TimeStamp { get; set; }

        [JsonProperty(PropertyName = "unit", Required = Required.Default, DefaultValueHandling = DefaultValueHandling.Ignore)]
        public string Unit { get; set; }

        [JsonProperty(PropertyName = "value", Required = Required.Default, DefaultValueHandling = DefaultValueHandling.Ignore)]
        public double Value { get; set; }
    }
}
