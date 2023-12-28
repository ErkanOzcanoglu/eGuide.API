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
    /// <seealso cref="eGuide.Infrastructure.Interface.IGenericRepository&lt;eGuide.Data.Entities.Station.Facility&gt;" />
    public interface IFacilityRepository : IGenericRepository<Facility> {

        /// <summary>
        /// Gets the by facility identifier.
        /// </summary>
        /// <param name="facilityId">The facility identifier.</param>
        /// <returns></returns>
        Task<Facility> GetByFacilityId(Guid facilityId);
    }
}
