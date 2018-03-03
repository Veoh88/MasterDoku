﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Core.Objects;
    using System.Linq;
    
    public partial class HarmonizationServiceEntities : DbContext
    {
        public HarmonizationServiceEntities()
            : base("name=HarmonizationServiceEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<vBlackList> vBlackList { get; set; }
        public virtual DbSet<vQualityIndicator> vQualityIndicator { get; set; }
        public virtual DbSet<vQualityIndicatorTypeMapping> vQualityIndicatorTypeMapping { get; set; }
        public virtual DbSet<vTreatmentStep> vTreatmentStep { get; set; }
        public virtual DbSet<vTreatmentStepType> vTreatmentStepType { get; set; }
        public virtual DbSet<vUnit> vUnit { get; set; }
        public virtual DbSet<vWaterPlant> vWaterPlant { get; set; }
        public virtual DbSet<vWaterPlantPropertyMapper> vWaterPlantPropertyMapper { get; set; }
        public virtual DbSet<vCountry> vCountry { get; set; }
        public virtual DbSet<vLocation> vLocation { get; set; }
        public virtual DbSet<vSupplier> vSupplier { get; set; }
    
        public virtual int SetBlackList(string propertyName)
        {
            var propertyNameParameter = propertyName != null ?
                new ObjectParameter("propertyName", propertyName) :
                new ObjectParameter("propertyName", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("SetBlackList", propertyNameParameter);
        }
    
        public virtual int SetCountry(string countryName, Nullable<int> countryId)
        {
            var countryNameParameter = countryName != null ?
                new ObjectParameter("countryName", countryName) :
                new ObjectParameter("countryName", typeof(string));
    
            var countryIdParameter = countryId.HasValue ?
                new ObjectParameter("countryId", countryId) :
                new ObjectParameter("countryId", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("SetCountry", countryNameParameter, countryIdParameter);
        }
    
        public virtual int SetLocation(Nullable<int> countryId, Nullable<int> locationId, string locationName)
        {
            var countryIdParameter = countryId.HasValue ?
                new ObjectParameter("countryId", countryId) :
                new ObjectParameter("countryId", typeof(int));
    
            var locationIdParameter = locationId.HasValue ?
                new ObjectParameter("locationId", locationId) :
                new ObjectParameter("locationId", typeof(int));
    
            var locationNameParameter = locationName != null ?
                new ObjectParameter("locationName", locationName) :
                new ObjectParameter("locationName", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("SetLocation", countryIdParameter, locationIdParameter, locationNameParameter);
        }
    
        public virtual int SetQualityIndicator(Nullable<int> waterPlantId, Nullable<int> treatmentStepId, Nullable<int> indicatorTypeId, Nullable<double> value, Nullable<System.DateTime> timeStamp, Nullable<int> unitId)
        {
            var waterPlantIdParameter = waterPlantId.HasValue ?
                new ObjectParameter("waterPlantId", waterPlantId) :
                new ObjectParameter("waterPlantId", typeof(int));
    
            var treatmentStepIdParameter = treatmentStepId.HasValue ?
                new ObjectParameter("treatmentStepId", treatmentStepId) :
                new ObjectParameter("treatmentStepId", typeof(int));
    
            var indicatorTypeIdParameter = indicatorTypeId.HasValue ?
                new ObjectParameter("indicatorTypeId", indicatorTypeId) :
                new ObjectParameter("indicatorTypeId", typeof(int));
    
            var valueParameter = value.HasValue ?
                new ObjectParameter("value", value) :
                new ObjectParameter("value", typeof(double));
    
            var timeStampParameter = timeStamp.HasValue ?
                new ObjectParameter("timeStamp", timeStamp) :
                new ObjectParameter("timeStamp", typeof(System.DateTime));
    
            var unitIdParameter = unitId.HasValue ?
                new ObjectParameter("unitId", unitId) :
                new ObjectParameter("unitId", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("SetQualityIndicator", waterPlantIdParameter, treatmentStepIdParameter, indicatorTypeIdParameter, valueParameter, timeStampParameter, unitIdParameter);
        }
    
        public virtual int SetQualityIndicatorTypeMapping(Nullable<int> indicatorTypeId, string name)
        {
            var indicatorTypeIdParameter = indicatorTypeId.HasValue ?
                new ObjectParameter("indicatorTypeId", indicatorTypeId) :
                new ObjectParameter("indicatorTypeId", typeof(int));
    
            var nameParameter = name != null ?
                new ObjectParameter("name", name) :
                new ObjectParameter("name", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("SetQualityIndicatorTypeMapping", indicatorTypeIdParameter, nameParameter);
        }
    
        public virtual int SetSupplier(Nullable<int> supplierId, string name)
        {
            var supplierIdParameter = supplierId.HasValue ?
                new ObjectParameter("supplierId", supplierId) :
                new ObjectParameter("supplierId", typeof(int));
    
            var nameParameter = name != null ?
                new ObjectParameter("name", name) :
                new ObjectParameter("name", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("SetSupplier", supplierIdParameter, nameParameter);
        }
    
        public virtual int SetTreatmentStep(Nullable<int> treatmentStepTypeId, Nullable<int> waterPlantId)
        {
            var treatmentStepTypeIdParameter = treatmentStepTypeId.HasValue ?
                new ObjectParameter("treatmentStepTypeId", treatmentStepTypeId) :
                new ObjectParameter("treatmentStepTypeId", typeof(int));
    
            var waterPlantIdParameter = waterPlantId.HasValue ?
                new ObjectParameter("waterPlantId", waterPlantId) :
                new ObjectParameter("waterPlantId", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("SetTreatmentStep", treatmentStepTypeIdParameter, waterPlantIdParameter);
        }
    
        public virtual int SetTreatmentStepType(string name)
        {
            var nameParameter = name != null ?
                new ObjectParameter("name", name) :
                new ObjectParameter("name", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("SetTreatmentStepType", nameParameter);
        }
    
        public virtual int SetUnit(string name)
        {
            var nameParameter = name != null ?
                new ObjectParameter("name", name) :
                new ObjectParameter("name", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("SetUnit", nameParameter);
        }
    
        public virtual int SetWaterPlant(string waterPlantName, Nullable<int> locationId, Nullable<int> supplierId)
        {
            var waterPlantNameParameter = waterPlantName != null ?
                new ObjectParameter("waterPlantName", waterPlantName) :
                new ObjectParameter("waterPlantName", typeof(string));
    
            var locationIdParameter = locationId.HasValue ?
                new ObjectParameter("locationId", locationId) :
                new ObjectParameter("locationId", typeof(int));
    
            var supplierIdParameter = supplierId.HasValue ?
                new ObjectParameter("supplierId", supplierId) :
                new ObjectParameter("supplierId", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("SetWaterPlant", waterPlantNameParameter, locationIdParameter, supplierIdParameter);
        }
    
        public virtual int SetWaterPlantMapping(Nullable<int> waterPlantId, string waterPlantName, string mappedName)
        {
            var waterPlantIdParameter = waterPlantId.HasValue ?
                new ObjectParameter("waterPlantId", waterPlantId) :
                new ObjectParameter("waterPlantId", typeof(int));
    
            var waterPlantNameParameter = waterPlantName != null ?
                new ObjectParameter("waterPlantName", waterPlantName) :
                new ObjectParameter("waterPlantName", typeof(string));
    
            var mappedNameParameter = mappedName != null ?
                new ObjectParameter("mappedName", mappedName) :
                new ObjectParameter("mappedName", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("SetWaterPlantMapping", waterPlantIdParameter, waterPlantNameParameter, mappedNameParameter);
        }
    }
}
