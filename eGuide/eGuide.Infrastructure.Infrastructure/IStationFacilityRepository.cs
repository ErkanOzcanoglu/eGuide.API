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
        /// <summary>
        /// Gets all facility.
        /// </summary>
        /// <returns></returns>
        Task<List<StationFacility>> GetAllFacility();

        /// <summary>
        /// Gets the facility by station identifier.
        /// </summary>
        /// <param name="stationId">The station identifier.</param>
        /// <returns></returns>
        Task<List<StationFacility>> GetFacilityByStationId(Guid stationId);
       

    }
}
