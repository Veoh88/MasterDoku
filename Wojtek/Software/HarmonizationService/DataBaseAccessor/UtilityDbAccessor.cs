using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBaseAccessor
{
    public class UtilityDbAccessor : IUtilityDbAccessor
    {
        #region Private Members

        private IDataBaseViewAccessor _dbViewAccessor;
        #endregion

        #region Constructors

        public UtilityDbAccessor()
        {
            _dbViewAccessor = new DbViewAccessor();
        }

        #endregion
        public string GetDefaultUnitForIndicator(string indicator)
        {
            return _dbViewAccessor.GetQualityIndicatorTypes().FirstOrDefault(x => x.indicatorName == indicator)
                .unitName;
        }

        public string GetIndicatorForAlias(string alias)
        {
            return _dbViewAccessor.GetQualityIndicatorTypeMappings().FirstOrDefault(x => x.indicatorAlias == alias).realIndicatorName;
        }
    }
}
