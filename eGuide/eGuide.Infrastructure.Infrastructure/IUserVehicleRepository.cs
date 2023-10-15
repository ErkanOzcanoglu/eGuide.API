using eGuide.Data.Entites.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eGuide.Infrastructure.Interface
{
    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="eGuide.Infrastructure.Interface.IGenericRepository&lt;eGuide.Data.Entites.Client.UserVehicle&gt;" />
    public interface IUserVehicleRepository : IGenericRepository<UserVehicle>
    {
        /// <summary>
        /// Gets the by vehicle identifier asynchronous.
        /// </summary>
        /// <param name="vehicleId">The vehicle identifier.</param>
        /// <returns></returns>
        Task<UserVehicle> GetByVehicleIdAsync(Guid vehicleId);
    }
}
