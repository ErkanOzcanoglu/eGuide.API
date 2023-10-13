using eGuide.Data.Entities.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eGuide.Infrastructure.Interface
{
    public interface IVehicleRepository : IGenericRepository<Vehicle>
    {
        /// <summary>
        /// Gets the models by brand asynchronous.
        /// </summary>
        /// <param name="brand">The brand.</param>
        /// <returns></returns>
        Task<List<string>> GetModelsByBrandAsync(string brand);

        /// <summary>
        /// Gets the primary key by brand and model asynchronous.
        /// </summary>
        /// <param name="brand">The brand.</param>
        /// <param name="model">The model.</param>
        /// <returns></returns>
        Task<Guid> GetPrimaryKeyByBrandAndModelAsync(string brand, string model);

        Task<IEnumerable<string>> GetAllBrandsAsync();
    }
}
