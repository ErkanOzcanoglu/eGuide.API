using eGuide.Data.Dto.OutComing.Station;
using eGuide.Data.Entites.Station;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eGuide.Infrastructure.Interface {

    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="eGuide.Infrastructure.Interface.IGenericRepository&lt;eGuide.Data.Entites.Station.StationsChargingUnits&gt;" />
    public interface IStationChargingUnitRepository : IGenericRepository<StationsChargingUnits> {
        //get sockets by station id
        /// <summary>
        /// Gets the charging unit by station identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        Task<StationsChargingUnits> GetChargingUnitByStationId(Guid id);
    }
}
