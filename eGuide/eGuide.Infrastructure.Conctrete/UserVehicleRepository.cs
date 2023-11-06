using eGuide.Data.Context.Context;
using eGuide.Data.Entites.Client;
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
    public class UserVehicleRepository : GenericRepository<UserVehicle>, IUserVehicleRepository
    {
        /// <summary>
        /// The context
        /// </summary>
        protected readonly eGuideContext _context;
        
        /// <summary>
        /// Initializes a new instance of the <see cref="UserVehicleRepository"/> class.
        /// </summary>
        /// <param name="context">The context.</param>
        public UserVehicleRepository(eGuideContext context) : base(context)
        {
            _context = context;
        }

        /// <summary>
        /// Gets the by vehicle identifier asynchronous.
        /// </summary>
        /// <param name="vehicleId">The vehicle identifier.</param>
        /// <returns></returns>
        public async Task<UserVehicle> GetByVehicleIdAsync(Guid vehicleId)
        {
            return await _context.Set<UserVehicle>().FirstOrDefaultAsync(uv => uv.VehicleId == vehicleId);
        }
    }
}
