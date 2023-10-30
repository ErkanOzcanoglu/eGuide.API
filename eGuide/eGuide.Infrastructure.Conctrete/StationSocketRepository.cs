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
    public class StationSocketRepository : GenericRepository<StationSockets>, IStationSocketRepository {
        private readonly eGuideContext _context;
        private readonly DbSet<StationSockets> _dbSet;

        public StationSocketRepository(eGuideContext context) : base(context) {
            _context = context;
            _dbSet = _context.Set<StationSockets>();
        }
    }
}
