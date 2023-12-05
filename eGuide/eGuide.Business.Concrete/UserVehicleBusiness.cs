using eGuide.Business.Interface;
using eGuide.Data.Entites.Client;
using eGuide.Data.Entities.Client;
using eGuide.Infrastructure.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eGuide.Business.Concrete
{
    public class UserVehicleBusiness : Business<UserVehicle>, IUserVehicleBusiness
    {
        /// <summary>
        /// The vehicle repository
        /// </summary>
        private readonly IUserVehicleRepository _vehicleRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="UserVehicleBusiness"/> class.
        /// </summary>
        /// <param name="repository">The repository.</param>
        /// <param name="unitOfWork">The unit of work.</param>
        /// <param name="vehicleRepository">The vehicle repository.</param>
        public UserVehicleBusiness(IGenericRepository<UserVehicle> repository, IUnitOfWork unitOfWork, IUserVehicleRepository vehicleRepository) : base(repository, unitOfWork)
        {
            _vehicleRepository = vehicleRepository;
        }

        public async Task<UserVehicle> GetActiveUserVehicleConnector(Guid userId)
        {
            return await _vehicleRepository.GetActiveUserVehicleConnector(userId);
        }

        public async Task<Vehicle> GetActiveVehicle(Guid userId)
        {
           return await _vehicleRepository.GetActiveVehicle(userId);
        }

        /// <summary>
        /// Gets the by vehicle identifier asynchronous.
        /// </summary>
        /// <param name="vehicleId">The vehicle identifier.</param>
        /// <returns></returns>
        public async Task<UserVehicle> GetByVehicleIdAsync(Guid vehicleId)
        {
            return await _vehicleRepository.GetByVehicleIdAsync(vehicleId);
        }

        /// <summary>
        /// Gets the user vehicles.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        public async Task<List<Vehicle>> GetUserVehicles(Guid id)
        {
            return await _vehicleRepository.GetUserVehicles(id);
        }
    }
}
