using eGuide.Data.Context.Context;
using eGuide.Data.Dto.OutComing.Station;
using eGuide.Data.Entites.Station;
using eGuide.Infrastructure.Concrete;
using eGuide.Infrastructure.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eGuide.Infrastructure.Conctrete {

    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="eGuide.Infrastructure.Concrete.GenericRepository&lt;eGuide.Data.Entites.Station.StationsChargingUnits&gt;" />
    /// <seealso cref="eGuide.Infrastructure.Interface.IStationChargingUnitRepository" />
    public class StationChargingUnitRepository : GenericRepository<StationsChargingUnits>, IStationChargingUnitRepository {

        /// <summary>
        /// The context
        /// </summary>
        private readonly eGuideContext _context;

        /// <summary>
        /// Initializes a new instance of the <see cref="StationChargingUnitRepository"/> class.
        /// </summary>
        /// <param name="context">The context.</param>
        public StationChargingUnitRepository(eGuideContext context) : base(context) {
            _context = context;
        }

        /// <summary>
        /// Gets the sockets by station identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        public async Task<StationsChargingUnits> GetChargingUnitByStationId(Guid id) {
            var sockets = await _context.StationsChargingUnits.Where(x => x.ChargingUnitId == id).FirstOrDefaultAsync();
            if (sockets == null) {
                return null;
            }
            return sockets;
        }
    }
}
