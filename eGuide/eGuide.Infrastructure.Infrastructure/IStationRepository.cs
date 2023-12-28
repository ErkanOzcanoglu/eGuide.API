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
    /// <seealso cref="eGuide.Infrastructure.Interface.IGenericRepository&lt;eGuide.Data.Entities.Station.StationProfile&gt;" />
    public interface IStationRepository: IGenericRepository<StationProfile> {
        /// <summary>
        /// Gets the station prof.
        /// </summary>
        /// <returns></returns>
        Task<List<StationProfile>> GetStationProf();

        /// <summary>
        /// Gets the station profile.
        /// </summary>
        /// <param name="Id">The identifier.</param>
        /// <returns></returns>
        Task<StationProfile> GetStationProfile(Guid Id);
    }
}
