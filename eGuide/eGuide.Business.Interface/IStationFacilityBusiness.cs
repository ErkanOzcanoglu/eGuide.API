using eGuide.Data.Entites.Station;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eGuide.Business.Interface {
    public interface IStationFacilityBusiness : IBusiness<StationFacility> {
        Task<List<StationFacility>> GetAllfac();
        Task<List<StationFacility>> GetFacByStationId(Guid stationId);
    }
}
