using eGuide.Data.Dto.Logger;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eGuide.Infrastructure.Interface {
    public interface ILastVisitedStationsRepository {
        /// <summary>
        /// Creates the users log.
        /// </summary>
        /// <param name="lvs">The LVS.</param>
        /// <returns></returns>
        Task<LastVisitedStations> CreateUsersLog(LastVisitedStations lvs);

        /// <summary>
        /// Gets the last visited stations by user identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        Task<IEnumerable<LastVisitedStations>> GetLastVisitedStationsByUserId(Guid id);

        /// <summary>
        /// Removes the last visited station.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        Task<LastVisitedStations> RemoveLastVisitedStation(Guid id);
    }
}
