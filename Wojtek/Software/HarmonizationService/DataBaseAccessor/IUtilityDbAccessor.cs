using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBaseAccessor
{
    public interface IUtilityDbAccessor
    {
        string GetDefaultUnitForIndicator(string indicator);
        string GetIndicatorForAlias(string alias);
    }
}
