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
    public class StationSocketRepository : GenericRepository<StationSockets>, IStationSocketRepository {
        private readonly eGuideContext _context;
        private readonly DbSet<StationSockets> _dbSet;

        public StationSocketRepository(eGuideContext context) : base(context) {
            _context = context;
            _dbSet = _context.Set<StationSockets>();
        }

        public async Task<StationSockets> GetSocketsByStationId(Guid id) {
            var sockets = await _dbSet.Where(x => x.SocketId == id).FirstOrDefaultAsync();
            if (sockets == null) {
                return null;
            }
            return sockets;
        }
    }
}
