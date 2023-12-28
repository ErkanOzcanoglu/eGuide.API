using eGuide.Data.Entities.Station;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eGuide.Business.Interface {
    public interface IChargingUnitBusiness : IBusiness<ChargingUnit> {
        /// <summary>
        /// Gets the charging units.
        /// </summary>
        /// <returns></returns>
        Task<List<ChargingUnit>> GetChargingUnits();
    }
}
