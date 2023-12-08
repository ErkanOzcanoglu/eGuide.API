using eGuide.Data.Entites.Client;
using eGuide.Data.Entities.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eGuide.Business.Interface
{
    public interface IUserVehicleBusiness : IBusiness<UserVehicle>
    {
        /// <summary>
        /// Gets the by vehicle identifier asynchronous.
        /// </summary>
        /// <param name="vehicleId">The vehicle identifier.</param>
        /// <returns></returns>
        public Task<UserVehicle> GetByVehicleIdAsync(Guid vehicleId);

        /// <summary>
        /// Gets the user vehicles.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        public Task<List<Vehicle>> GetUserVehicles(Guid id);

        Task<UserVehicle> GetActiveUserVehicleConnector(Guid userId);

        Task<Vehicle> GetActiveVehicle(Guid userId);

        Task<Vehicle> GetUpdatedActiveVehicle(Guid userId, Guid vehicleId);

    }
}
