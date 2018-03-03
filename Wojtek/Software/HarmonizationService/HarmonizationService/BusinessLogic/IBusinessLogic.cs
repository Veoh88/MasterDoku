using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library.HarmonizationApi;

namespace HarmonizationService.BusinessLogic
{
    public interface IBusinessLogic
    {
        string HarmonizeData(HarmonizationRequest harmRequest);
    }
}
