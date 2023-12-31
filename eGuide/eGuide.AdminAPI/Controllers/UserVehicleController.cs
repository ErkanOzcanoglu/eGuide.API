﻿using AutoMapper;
using eGuide.Business.Interface;
using eGuide.Data.Context.Context;
using eGuide.Data.Dto.InComing.CreationDto.Client;
using eGuide.Data.Entites.Client;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace eGuide.Service.AdminAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserVehicleController : ControllerBase
    {
        /// <summary>
        /// The business
        /// </summary>
        private readonly IUserVehicleBusiness _business;

        /// <summary>
        /// The mapper
        /// </summary>
        private readonly IMapper _mapper;

        /// <summary>
        /// The context
        /// </summary>
        protected readonly eGuideContext _context;

        /// <summary>
        /// The database set
        /// </summary>
        private readonly DbSet<UserVehicle> _dbSet;

        /// <summary>
        /// Initializes a new instance of the <see cref="UserVehicleController"/> class.
        /// </summary>
        /// <param name="business">The business.</param>
        /// <param name="mapper">The mapper.</param>
        /// <param name="context">The context.</param>
        public UserVehicleController(IUserVehicleBusiness business, IMapper mapper, eGuideContext context)
        {
            _business = business;
            _mapper = mapper;

            _context = context;
            _dbSet = _context.Set<UserVehicle>();
        }

        /// <summary>
        /// Saves the specified vehicledto.
        /// </summary>
        /// <param name="vehicledto">The vehicledto.</param>
        [HttpPost]
        public async Task Save(CreationDtoForUserVehicle vehicledto)
        {
            await _business.AddAsync(_mapper.Map<UserVehicle>(vehicledto));
        }

        /// <summary>
        /// Updates the user vehicle.
        /// </summary>
        /// <param name="userid">The userid.</param>
        /// <param name="vehicleId">The vehicle identifier.</param>
        /// <param name="idNew">The identifier new.</param>
        /// <returns></returns>
        [HttpPut("update-vehicle")]
        public async Task<IActionResult> UpdateUserVehicle(Guid userid, Guid vehicleId, Guid idNew, Guid connectorId)
        {
            try
            {
                var existingVehicle = await _dbSet.FirstOrDefaultAsync(v => v.UserId == userid && v.VehicleId == vehicleId && v.Status == 1);//kontrol et

                if (existingVehicle == null)
                {
                    return NotFound($"UserId {userid} ve VehicleId {vehicleId} olan araç kaydı bulunamadı.");
                }

                existingVehicle.VehicleId = idNew;
                existingVehicle.UpdatedDate = DateTime.Now;
                existingVehicle.ConnectorId = connectorId;

                _dbSet.Update(existingVehicle);
                await _context.SaveChangesAsync();

                return Ok(existingVehicle);
            }
            catch (Exception ex)
            {
                return BadRequest($"Hata: {ex.Message}");
            }
        }

        /// <summary>
        /// Deletes the by vehicle identifier.
        /// </summary>
        /// <param name="userid">The userid.</param>
        /// <param name="vehicleId">The vehicle identifier.</param>
        /// <returns></returns>
        [HttpDelete("DeleteByVehicleId/{vehicleId}")]
        public async Task<IActionResult> DeleteByVehicleId(Guid userid, Guid vehicleId)
        {
            try
            {
                var existingVehicle = await _dbSet.FirstOrDefaultAsync(v => v.UserId == userid && v.VehicleId == vehicleId && v.Status == 1);

                if (existingVehicle == null)
                {
                    return NotFound($"UserId {userid} ve VehicleId {vehicleId} olan araç kaydı bulunamadı.");
                }

                await _business.RemoveAsync(existingVehicle.Id);
                return Ok();
            }
            catch (DbUpdateException ex)
            {
                return BadRequest("Veritabanına erişim sırasında bir hata oluştu. Lütfen daha sonra tekrar deneyin.");
            }
            catch (Exception ex)
            {
                return BadRequest($"Hata: {ex.Message}");
            }
        }

        /// <summary>
        /// Gets the user vehicles.
        /// </summary>
        /// <param name="userId">The user identifier.</param>
        /// <returns></returns>
        [HttpGet("GetVehicleByUserId/{userId}")]
        public async Task<IActionResult> GetUserVehicles(Guid userId)
        {
            try
            {
                var userVehicles = await _business.GetUserVehicles(userId);

                if (userVehicles == null)
                {
                    return NotFound(); // Kullanıcıya ait araçlar bulunamadıysa 404 dönebilirsiniz.
                }

                return Ok(userVehicles);
            }
            catch (Exception ex)
            {
                return BadRequest($"Hata: {ex.Message}");
            }
        }

        //[HttpGet]
        //public IActionResult Get(Guid userId) 
        //{
        //    try
        //    {
        //        var userIdParameter = new SqlParameter("@UserId", SqlDbType.NVarChar, 60)
        //        {
        //            Value = userId.ToString() 
        //        };

        //        var result = _context.Vehicle //from vehicle table
        //            .FromSqlRaw("EXEC GetVehiclesByUserID @UserId", userIdParameter)
        //            .ToList();

        //        return Ok(result);
        //    }
        //    catch (Exception ex)
        //    {
        //        return BadRequest($"Hata: {ex.Message}"); 
        //    }
        //}

    }

}
