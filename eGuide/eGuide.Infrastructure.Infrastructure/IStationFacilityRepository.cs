using eGuide.Data.Entites.Station;
using eGuide.Data.Entities.Station;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eGuide.Infrastructure.Interface {

    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="eGuide.Infrastructure.Interface.IGenericRepository&lt;eGuide.Data.Entites.Station.StationFacility&gt;" />
    public interface IStationFacilityRepository : IGenericRepository<StationFacility> {
        Task<List<StationFacility>> GetAllFacility();
        Task<List<StationFacility>> GetFacilityByStationId(Guid stationId);
       

    }
}
