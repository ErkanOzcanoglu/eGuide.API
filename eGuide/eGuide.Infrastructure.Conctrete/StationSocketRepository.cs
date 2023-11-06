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
    /// <seealso cref="eGuide.Infrastructure.Concrete.GenericRepository&lt;eGuide.Data.Entites.Station.StationSockets&gt;" />
    /// <seealso cref="eGuide.Infrastructure.Interface.IStationSocketRepository" />
    public class StationSocketRepository : GenericRepository<StationSockets>, IStationSocketRepository {

        /// <summary>
        /// The context
        /// </summary>
        private readonly eGuideContext _context;

        /// <summary>
        /// Initializes a new instance of the <see cref="StationSocketRepository"/> class.
        /// </summary>
        /// <param name="context">The context.</param>
        public StationSocketRepository(eGuideContext context) : base(context) {
            _context = context;
        }

        /// <summary>
        /// Gets the sockets by station identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        public async Task<StationSockets> GetSocketsByStationId(Guid id) {
            var sockets = await _context.StationSockets.Where(x => x.SocketId == id).FirstOrDefaultAsync();
            if (sockets == null) {
                return null;
            }
            return sockets;
        }
    }
}
