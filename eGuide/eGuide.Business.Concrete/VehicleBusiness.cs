using eGuide.Business.Interface;
using eGuide.Data.Entities.Client;
using eGuide.Infrastructure.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eGuide.Business.Concrete
{
    public class VehicleBusiness : Business<Vehicle>, IVehicleBusiness
    {
        /// <summary>
        /// The vehicle repository
        /// </summary>
        private readonly IVehicleRepository _vehicleRepository;
        /// <summary>
        /// Initializes a new instance of the <see cref="VehicleBusiness"/> class.
        /// </summary>
        /// <param name="repository">The repository.</param>
        /// <param name="unitOfWork">The unit of work.</param>
        /// <param name="vehicleRepository">The vehicle repository.</param>
        public VehicleBusiness(IGenericRepository<Vehicle> repository, IUnitOfWork unitOfWork, IVehicleRepository vehicleRepository) : base(repository, unitOfWork)
        {
            _vehicleRepository = vehicleRepository;
        }

        /// <summary>
        /// Gets the models by brand asynchronous.
        /// </summary>
        /// <param name="brand">The brand.</param>
        /// <returns></returns>
        public async Task<List<string>> GetModelsByBrandAsync(string brand)
        {
            return await _vehicleRepository.GetModelsByBrandAsync(brand);
        }

        /// <summary>
        /// Gets the primary key by brand and model asynchronous.
        /// </summary>
        /// <param name="brand">The brand.</param>
        /// <param name="model">The model.</param>
        /// <returns></returns>
        public async Task<Guid> GetPrimaryKeyByBrandAndModelAsync(string brand, string model)
        {
            return await _vehicleRepository.GetPrimaryKeyByBrandAndModelAsync(brand, model);
        }

        public async Task<IEnumerable<string>> GetAllBrandsAsync()
        {
            return await _vehicleRepository.GetAllBrandsAsync();
        }
    }
}
