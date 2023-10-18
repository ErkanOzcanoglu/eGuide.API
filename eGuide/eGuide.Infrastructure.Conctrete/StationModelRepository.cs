using eGuide.Common.Mappers;
using eGuide.Data.Context.Context;
using eGuide.Data.Entities.Station;
using eGuide.Infrastructure.Concrete;
using eGuide.Infrastructure.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eGuide.Infrastructure.Conctrete {
    public class StationModelRepository: GenericRepository<StationModel>, IStationModelRepository {
        private readonly eGuideContext _context;
        private readonly DbSet<StationModel> _dbSet;

        public StationModelRepository(eGuideContext context) : base(context) {
            _context = context;
            _dbSet = _context.Set<StationModel>();
        }
    }
}
