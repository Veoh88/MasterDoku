using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBaseAccessor
{
    public class DbViewAccessor : IDataBaseViewAccessor
    {
        #region Private Members

        private readonly HarmonizationServiceEntities _entityFrameworkAccessor;

        #endregion
        
        #region Constructors
        public DbViewAccessor()
        {
            _entityFrameworkAccessor = new HarmonizationServiceEntities();
        }
        #endregion

        public IQueryable<vWaterPlant> GetWaterPlants()
        {
            var result = _entityFrameworkAccessor.vWaterPlant;
            return result;
        }

        public IQueryable<vBlackList> GetBlackList()
        {
            var result = _entityFrameworkAccessor.vBlackList;
            return result;
        }

        public IQueryable<vQualityIndicator> GetQualityIndicators()
        {
            var result = _entityFrameworkAccessor.vQualityIndicator;
            return result;
        }

        public IQueryable<vQualityIndicatorTypeMapping> GetQualityIndicatorTypeMappings()
        {
            var result = _entityFrameworkAccessor.vQualityIndicatorTypeMapping;
            return result;
        }

        public IQueryable<vTreatmentStep> GetTreatmentSteps()
        {
            var result = _entityFrameworkAccessor.vTreatmentStep;
            return result;
        }

        public IQueryable<vTreatmentStepType> GetTreatmentStepTypes()
        {
            var result = _entityFrameworkAccessor.vTreatmentStepType;
            return result;
        }

        public IQueryable<vUnit> GetUnit()
        {
            var result = _entityFrameworkAccessor.vUnit;
            return result;
        }

        public IQueryable<vWaterPlantPropertyMapper> GetWaterPlantPropertyMapper()
        {
            var result = _entityFrameworkAccessor.vWaterPlantPropertyMapper;
            return result;
        }

        public IQueryable<vSupplier> GetSuppliers()
        {
            var result = _entityFrameworkAccessor.vSupplier;
            return result;
        }

        public IQueryable<vLocation> GetLocatoins()
        {
            var result = _entityFrameworkAccessor.vLocation;
            return result;
        }

        public IQueryable<vCountry> GetCountries()
        {
            var result = _entityFrameworkAccessor.vCountry;
            return result;
        }

        public IQueryable<vQualityIndicatorType> GetQualityIndicatorTypes()
        {
            var result = _entityFrameworkAccessor.vQualityIndicatorType;
            return result;
        }
    }
}
