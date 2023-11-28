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
    /// <seealso cref="eGuide.Infrastructure.Interface.IGenericRepository&lt;eGuide.Data.Entities.Station.ChargingUnit&gt;" />
    public interface IChargingUnitRepository : IGenericRepository<ChargingUnit> {
        Task<List<ChargingUnit>> GetChargingUnits();
    }
}
