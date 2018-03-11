using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library.HarmonizationApi;
using Library.HarmonizedObjects;

namespace HarmonizationService.BusinessLogic
{
    public interface IBusinessLogic
    {
        WasteWaterTreatmentPlant HarmonizeData(Stream dataBaseStream, FileFormat fileFormat, string waterPlant, string treatmentStep);
        WasteWaterTreatmentPlant HarmonizeData(string jsonObject, string waterPlant = null, string treatmentStep = null);
    }
}
