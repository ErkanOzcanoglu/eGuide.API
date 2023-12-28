using eGuide.Data.Entites.Station;
using eGuide.Data.Entities.Station;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eGuide.Business.Interface {
    public interface IStationFacilityBusiness : IBusiness<StationFacility> {
        
        /// <summary>
        /// Gets the allfac.
        /// </summary>
        /// <returns></returns>
        Task<List<StationFacility>> GetAllfac();

        /// <summary>
        /// Gets the fac by station identifier.
        /// </summary>
        /// <param name="stationId">The station identifier.</param>
        /// <returns></returns>
        Task<List<StationFacility>> GetFacByStationId(Guid stationId);
        
    }
}
