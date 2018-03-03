using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBaseAccessor
{
    public class DataBaseSetter
    {
        #region Private Members

        private readonly HarmonizationServiceEntities _entityFrameworkAccessor;

        #endregion
        #region Constructors

        public DataBaseSetter()
        {
            _entityFrameworkAccessor = new HarmonizationServiceEntities();   
        }
        #endregion

        #region Public Methods

        public int SetBlackList()
        {
            return 1;
        }

        #endregion
    }
}
