using eGuide.Data.Context.Context;
using eGuide.Data.Entities.Station;
using eGuide.Infrastructure.Concrete;
using eGuide.Infrastructure.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace eGuide.Infrastructure.Conctrete {

    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="eGuide.Infrastructure.Concrete.GenericRepository&lt;eGuide.Data.Entities.Station.StationProfile&gt;" />
    /// <seealso cref="eGuide.Infrastructure.Interface.IStationRepository" />
    public class StationRepository : GenericRepository<StationProfile>, IStationRepository {

        /// <summary>
        /// The context
        /// </summary>
        private readonly eGuideContext _context;

        /// <summary>
        /// Initializes a new instance of the <see cref="StationRepository"/> class.
        /// </summary>
        /// <param name="context">The context.</param>
        public StationRepository(eGuideContext context) : base(context) {
            _context = context;
        }

        /// <summary>
        /// Gets all station information.
        /// </summary>
        /// <returns></returns>
        public async Task<List<StationProfile>> GetAllStationInformation() {
            var stationInformation = await _context.Station.Where(res => res.Status == 1)
                .Include(us => us.UserStations)
                .Include(sf => sf.StationFacilities)
                .ThenInclude(f => f.Facility)
                .Include(sm => sm.StationModel)
                .ThenInclude(ss => ss.StationsChargingUnits)
                .ThenInclude(s => s.ChargingUnit)
                .ThenInclude(c => c.Connector)
                .ToListAsync();

            if( stationInformation == null) {
                return null;
            }

            return stationInformation;
        }

        public async Task<List<StationProfile>> GetStationProf() {
            var res = await _context.Station.Where(x => x.Status == 1)

                 .Include(us => us.UserStations)
                 .Include(sf => sf.StationFacilities)
                 .ThenInclude(f => f.Facility)
                 .Include(x => x.StationModel)
                 .ThenInclude(y => y.StationsChargingUnits)
                 .ThenInclude(z => z.ChargingUnit)
                 .ThenInclude(k => k.Connector)
                 .AsNoTracking()
                 .ToListAsync();


            if (res != null)
                return res;
            else
                return null;
        }

        public async Task<StationProfile> GetStationProfile(Guid Id)
        {
            var res = await _context.Station
            .Where(x => x.Id == Id && x.Status == 1)
            .Include(us => us.UserStations)
            .Include(sf => sf.StationFacilities)
            .ThenInclude(f => f.Facility)
            .Include(x => x.StationModel)
            .ThenInclude(y => y.StationsChargingUnits)
            .ThenInclude(z => z.ChargingUnit)
             .ThenInclude(k => k.Connector)
            .AsNoTracking()
            .SingleOrDefaultAsync(); // SingleOrDefaultAsync kullanarak bir eleman veya null dönecek

            return res; // Bu noktada ya bir S
        }
    }
}
