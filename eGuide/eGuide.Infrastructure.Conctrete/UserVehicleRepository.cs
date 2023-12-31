﻿using eGuide.Data.Context.Context;
using eGuide.Data.Entites.Client;
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
    public class UserVehicleRepository : GenericRepository<UserVehicle>, IUserVehicleRepository
    {
        /// <summary>
        /// The context
        /// </summary>
        protected readonly eGuideContext _context;
        
        /// <summary>
        /// The database set
        /// </summary>
        private readonly DbSet<UserVehicle> _dbSet;
        /// <summary>
        /// Initializes a new instance of the <see cref="UserVehicleRepository"/> class.
        /// </summary>
        /// <param name="context">The context.</param>
        public UserVehicleRepository(eGuideContext context) : base(context)
        {
            _context = context;
            _dbSet = _context.Set<UserVehicle>();
        }

        public async Task<UserVehicle> GetActiveUserVehicleConnector(Guid userId)
        {
            var userVehicle = await _dbSet.FirstOrDefaultAsync(v => v.UserId == userId && v.ActiveStatus == 1);
            return userVehicle;

        }

        public async Task<Vehicle> GetActiveVehicle(Guid userId)
        {
            var activeVehicle = await _dbSet.Include(uv => uv.Vehicle)
                                .Where(uv => uv.UserId == userId && uv.ActiveStatus == 1)
                                .Select(uv => uv.Vehicle).SingleOrDefaultAsync();

            return activeVehicle;
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

        public async Task<Vehicle> GetUpdatedActiveVehicle(Guid userId, Guid vehicleId)
        {
            var existingVehicle = await _dbSet.FirstOrDefaultAsync(v => v.UserId == userId && v.VehicleId == vehicleId && v.Status == 1);

            var otherActiveVehicle = await _dbSet.FirstOrDefaultAsync(v => v.UserId == userId && v.ActiveStatus == 1 && v.VehicleId != vehicleId);

            if (otherActiveVehicle != null)
            {
                otherActiveVehicle.ActiveStatus = 0;
                _dbSet.Update(otherActiveVehicle);
            }


            existingVehicle.UpdatedDate = DateTime.Now;
            existingVehicle.ActiveStatus = 1;


            _dbSet.Update(existingVehicle);
            await _context.SaveChangesAsync();

            var vehicle = _context.Vehicle.Where(v => v.Id == vehicleId).FirstOrDefault(); //FIND VEHICLEL ON USERVEHICLE MAKE ACTIVE THEN GO VEHICLE TABLE GET VEHICLE INFORMATIONS

            return vehicle;
        }

        /// <summary>
        /// Gets the user vehicles.
        /// </summary>
        /// <param name="userId">The user identifier.</param>
        /// <returns></returns>
        public async Task<List<Vehicle>> GetUserVehicles(Guid userId)
        {
            return await _dbSet.Where(uv => uv.UserId == userId && uv.Status == 1).Select(uv => uv.Vehicle).AsNoTracking().ToListAsync();
        }

        public async Task<UserVehicle> UpdateUserVehicleAsync(Guid userid, Guid vehicleId, Guid idNew, Guid connectorId)
        {
            var existingVehicle = await FirstOrDefault(v => v.UserId == userid && v.VehicleId == vehicleId && v.Status == 1);

            if (existingVehicle == null)
            {
                return null; // Veya isteğe bağlı olarak bir hata durumu gönderebilirsiniz.
            }

            existingVehicle.VehicleId = idNew;
            existingVehicle.UpdatedDate = DateTime.Now;
            existingVehicle.ConnectorId = connectorId;

            _dbSet.Update(existingVehicle);
            await _context.SaveChangesAsync();

            return existingVehicle;
        }

        //return await _dbSet.Include(uv => uv.Vehicle).Where(uv => uv.UserId == userId).Select(uv => new Vehicle
        //{
        //    Brand = uv.Vehicle.Brand,
        //    Model = uv.Vehicle.Model,
        //    UserVehicles = uv.Vehicle.UserVehicles

        //}).AsNoTracking().ToListAsync();
    }
}
