using eGuide.Data.Entities.Station;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eGuide.Business.Interface {
    public interface IStationBusiness : IBusiness<StationProfile> {
        
        /// <summary>
        /// Gets all s.
        /// </summary>
        /// <returns></returns>
        Task<List<StationProfile>> GetAllS();

        /// <summary>
        /// Gets the station profile.
        /// </summary>
        /// <param name="Id">The identifier.</param>
        /// <returns></returns>
        Task<StationProfile> GetStationProfile(Guid Id);
    }
}
