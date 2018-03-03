using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Library.HarmonizationApi
{
    [DataContract(Name = "harmonizationRequest")]
    public class HarmonizationRequest
    {
        [DataMember(Name = "fileFormat")]
        public FileFormat FileFormat { get; set; }

        [DataMember(Name = "waterPlantName")]
        public string WaterPlantName { get; set; }

        [DataMember(Name = "waterPlantId")]
        public int? WaterPlantId { get; set; }

        [DataMember(Name = "waterPlantLocation")]
        public string WaterPlantLocation { get; set; }

        [DataMember(Name = "treatmentStepId")]
        public int? TreatmentStepId { get; set; }

        [DataMember(Name = "treatmentStepName")]
        public string TreatmentStepName { get; set; }

        [DataMember(Name = "payload")]
        public string Payload { get; set; }
    }

    [JsonConverter(typeof(StringEnumConverter))]
    public enum FileFormat
    {
        XLS,
        CSV,
        JSON
    }

}
