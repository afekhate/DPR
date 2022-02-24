﻿using DPR.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DPR.Services.Contract
{
    public interface IFillingStationOwner
    {
        string GetFillingStationDetails(FillingStationOwnerViewModel fillingStationOwnerViewModel);
    }
}
