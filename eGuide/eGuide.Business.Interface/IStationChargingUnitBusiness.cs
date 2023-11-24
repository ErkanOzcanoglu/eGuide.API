using eGuide.Data.Entites.Station;
using eGuide.Data.Dto.OutComing.Station;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eGuide.Business.Interface {
    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="eGuide.Business.Interface.IBusiness&lt;eGuide.Data.Entites.Station.StationsChargingUnits&gt;" />
    public interface IStationChargingUnitBusiness: IBusiness<StationsChargingUnits> {
        //get sockets by station id
        /// <summary>
        /// Gets the charging unit by station identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        Task<StationsChargingUnits> GetChargingUnitByStationId(Guid id);
    }
}
