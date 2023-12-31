﻿using eGuide.Data.Entities.Station;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eGuide.Business.Interface {
    public interface IStationBusiness : IBusiness<StationProfile> {
        Task<List<StationProfile>> GetAllS();

        Task<StationProfile> GetStationProfile(Guid Id);
    }
}
