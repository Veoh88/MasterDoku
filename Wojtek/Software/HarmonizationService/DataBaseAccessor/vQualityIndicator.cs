//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DataBaseAccessor
{
    using System;
    using System.Collections.Generic;
    
    public partial class vQualityIndicator
    {
        public int qualityIndicatorId { get; set; }
        public Nullable<int> waterPlantId { get; set; }
        public Nullable<int> treatmentStepId { get; set; }
        public int indicatorTypeId { get; set; }
        public double value { get; set; }
        public System.DateTime timeStamp { get; set; }
        public Nullable<int> unitId { get; set; }
        public string unitName { get; set; }
        public string indicatorName { get; set; }
    }
}
