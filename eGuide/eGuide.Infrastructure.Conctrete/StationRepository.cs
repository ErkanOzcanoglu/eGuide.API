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
    public class StationRepository : GenericRepository<StationProfile>, IStationRepository {
        private readonly eGuideContext _context;
        private readonly DbSet<StationProfile> _dbSet;

        public StationRepository(eGuideContext context) : base(context) {
            _context = context;
            _dbSet = _context.Set<StationProfile>();
        }
    }
}
