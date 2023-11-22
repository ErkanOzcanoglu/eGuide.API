using eGuide.Data.Context.Context;
using eGuide.Data.Entities.Client;
using eGuide.Data.Entities.Station;
using eGuide.Infrastructure.Concrete;
using eGuide.Infrastructure.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eGuide.Infrastructure.Conctrete
{
    public class UserStationRepository : GenericRepository<UserStation>, IUserStationRepository
    {

        protected readonly eGuideContext _context;
        private readonly DbSet<UserStation> _dbSet;
        public UserStationRepository(eGuideContext context) : base(context)
        {
            _context = context;
        }

        public async Task<List<StationProfile>> GetUserStationsProfilesAsync(Guid userId)
        {
            //var userStation = await _context.UserStation.Include(uv => uv.StationProfile) .Where(uv => uv.UserId == userId && uv.Status == 1).ToListAsync();

            //var stationProfiles = userStation.Select(uv => uv.StationProfile).ToList();

            //return  stationProfiles;
            ////eagerloading de yap

            var userStation = await _context.UserStation.Where(uv => uv.UserId == userId && uv.Status == 1)
                .Include(uv => uv.StationProfile)
                .ThenInclude(sm => sm.StationModel)
                .ThenInclude(ss => ss.StationsChargingUnits)
                .ThenInclude(s => s.ChargingUnit)
                .ThenInclude(c => c.Connector)
                .ToListAsync();

            var stationProfiles = userStation.Select(uv => uv.StationProfile).ToList();

            return stationProfiles;
        }
    }
}
