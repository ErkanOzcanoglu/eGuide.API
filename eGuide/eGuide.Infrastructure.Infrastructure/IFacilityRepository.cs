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

        Task<Facility> GetByFacilityId(Guid facilityId);
    }
}
