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
        [JsonProperty(PropertyName = "name", Required = Required.Always)]
        public string Name { get; set; }

        [JsonProperty(PropertyName = "timestamp", Required = Required.Always)]
        public DateTime TimeStamp { get; set; }

        [JsonProperty(PropertyName = "unit", Required = Required.Default, DefaultValueHandling = DefaultValueHandling.Ignore)]
        public string Unit { get; set; }

        [JsonProperty(PropertyName = "value", Required = Required.Always)]
        public double Value { get; set; }
    }
}
