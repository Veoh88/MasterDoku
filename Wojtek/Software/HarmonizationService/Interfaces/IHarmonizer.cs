using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library.ConvertedObjects;
using Library.HarmonizedObjects;

namespace Interfaces
{
    public interface IHarmonizer
    {
        WasteWaterTreatmentPlant HarmonizeTableObject(TableFormattedObject tableObject);
        WasteWaterTreatmentPlant HarmonizeJsonObject(TreeFormattedObject treeObject);

    }
}
