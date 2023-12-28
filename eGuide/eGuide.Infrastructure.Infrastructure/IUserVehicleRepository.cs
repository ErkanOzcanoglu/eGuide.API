using eGuide.Data.Entites.Client;
using eGuide.Data.Entities.Client;
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

        /// <summary>
        /// Gets the user vehicles.
        /// </summary>
        /// <param name="userId">The user identifier.</param>
        /// <returns></returns>
        Task<List<Vehicle>> GetUserVehicles(Guid userId);

        /// <summary>
        /// Gets the active vehicle.
        /// </summary>
        /// <param name="userId">The user identifier.</param>
        /// <returns></returns>
        Task<Vehicle> GetActiveVehicle(Guid userId);

        /// <summary>
        /// Gets the updated active vehicle.
        /// </summary>
        /// <param name="userId">The user identifier.</param>
        /// <param name="vehicleId">The vehicle identifier.</param>
        /// <returns></returns>
        Task<Vehicle> GetUpdatedActiveVehicle(Guid userId, Guid vehicleId);

        /// <summary>
        /// Gets the active user vehicle connector.
        /// </summary>
        /// <param name="userId">The user identifier.</param>
        /// <returns></returns>
        Task<UserVehicle> GetActiveUserVehicleConnector(Guid userId);

        /// <summary>
        /// Updates the user vehicle asynchronous.
        /// </summary>
        /// <param name="userid">The userid.</param>
        /// <param name="vehicleId">The vehicle identifier.</param>
        /// <param name="idNew">The identifier new.</param>
        /// <param name="connectorId">The connector identifier.</param>
        /// <returns></returns>
        Task<UserVehicle> UpdateUserVehicleAsync(Guid userid, Guid vehicleId, Guid idNew, Guid connectorId);
    }

}
