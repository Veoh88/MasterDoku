﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library.HarmonizedObjects;

namespace Interfaces
{
    public interface ISimplificator
    {
        WasteWaterTreatmentPlant Simplify(WasteWaterTreatmentPlant wwtp);
    }
}
