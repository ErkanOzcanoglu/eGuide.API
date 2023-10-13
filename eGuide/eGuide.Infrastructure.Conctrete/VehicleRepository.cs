using eGuide.Data.Context.Context;
using eGuide.Data.Entities.Client;
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
    public class VehicleRepository : GenericRepository<Vehicle>, IVehicleRepository
    {
        /// <summary>
        /// The context
        /// </summary>
        protected readonly eGuideContext _context;

        /// <summary>
        /// The database set
        /// </summary>
        private readonly DbSet<Vehicle> _dbSet;

        /// <summary>
        /// Initializes a new instance of the <see cref="UserRepository"/> class.
        /// </summary>
        /// <param name="context">The context.</param>
        public VehicleRepository(eGuideContext context) : base(context)
        {
            _context = context;
            _dbSet = _context.Set<Vehicle>();
        }

        /// <summary>
        /// Gets the models by brand asynchronous.
        /// </summary>
        /// <param name="brand">The brand.</param>
        /// <returns></returns>
        public async Task<List<string>> GetModelsByBrandAsync(string brand)
        {
            var models = await _context.Vehicle.Where(v => v.Brand == brand).Select(v => v.Model).ToListAsync();
            return models;
        }

        /// <summary>
        /// Gets the primary key by brand and model asynchronous.
        /// </summary>
        /// <param name="brand">The brand.</param>
        /// <param name="model">The model.</param>
        /// <returns></returns>
        public async Task<Guid> GetPrimaryKeyByBrandAndModelAsync(string brand, string model)
        {
            var vehicle = await _dbSet.FirstOrDefaultAsync(v => v.Brand == brand && v.Model == model);

            return vehicle.Id;
        }
    }
}
