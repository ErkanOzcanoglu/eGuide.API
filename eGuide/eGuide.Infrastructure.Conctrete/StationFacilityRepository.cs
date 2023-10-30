using eGuide.Data.Context.Context;
using eGuide.Data.Entites.Station;
using eGuide.Infrastructure.Concrete;
using eGuide.Infrastructure.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eGuide.Infrastructure.Conctrete {
    public class StationFacilityRepository : GenericRepository<StationFacility>, IStationFacilityRepository {
        private readonly eGuideContext _context;
        private readonly DbSet<StationFacility> _dbSet;

        public StationFacilityRepository(eGuideContext context) : base(context) {
            _context = context;
            _dbSet = _context.Set<StationFacility>();
        }
    }
}
