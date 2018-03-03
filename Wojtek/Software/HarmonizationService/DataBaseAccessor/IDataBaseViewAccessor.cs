using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBaseAccessor
{
    public interface IDataBaseViewAccessor
    {
         IQueryable<vWaterPlant> GetWaterPlants();

         IQueryable<vBlackList> GetBlackList();

         IQueryable<vQualityIndicator> GetQualityIndicators();

         IQueryable<vQualityIndicatorTypeMapping> GetQualityIndicatorTypeMappings();

         IQueryable<vTreatmentStep> GetTreatmentSteps();
        

         IQueryable<vTreatmentStepType> GetTreatmentStepTypes();

         IQueryable<vUnit> GetUnit();

         IQueryable<vWaterPlantPropertyMapper> GetWaterPlantPropertyMapper();

         IQueryable<vSupplier> GetSuppliers();

         IQueryable<vLocation> GetLocatoins();

         IQueryable<vCountry> GetCountries();

         IQueryable<vQualityIndicatorType> GetQualityIndicatorTypes();
    }
}
