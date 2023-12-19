using AutoMapper;
using eGuide.Business.Interface;
using eGuide.Data.Context.Context;
using eGuide.Data.Dto.InComing.CreationDto.Client;
using eGuide.Data.Dto.InComing.UpdateDto.Client;
using eGuide.Data.Entites.Client;
using eGuide.Data.Entities.Client;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace eGuide.Service.ClientAPI.Controllers
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
        /// Initializes a new instance of the <see cref="UserVehicleController"/> class.
        /// </summary>
        /// <param name="business">The business.</param>
        /// <param name="mapper">The mapper.</param>
        /// <param name="context">The context.</param>
        public UserVehicleController(IUserVehicleBusiness business, IMapper mapper)
        {
            _business = business;
            _mapper = mapper;
        }

        /// <summary>
        /// Saves the specified vehicledto.
        /// </summary>
        /// <param name="vehicledto">The vehicledto.</param>
        [HttpPost]
        public async Task Save(CreationDtoForUserVehicle vehicledto)
        {
            var existingVehicle = await _business.FirstOrDefault(v => v.UserId == vehicledto.UserId);

            if (existingVehicle == null)
            {
                vehicledto.ActiveStatus = 1;
            }
            else
            {
                vehicledto.ActiveStatus = 0;
            }

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
        public async Task<IActionResult> UpdateUserVehicle(Guid userid, Guid vehicleId, Guid idNew, Guid connectorId )
        {
            try
            {
                var updatedVehicle = await _business.UpdateUserVehicleAsync(userid, vehicleId, idNew, connectorId);

                if (updatedVehicle == null)
                {
                    return NotFound($"UserId {userid} ve VehicleId {vehicleId} olan araç kaydı bulunamadı.");
                }

                return Ok(updatedVehicle);
            }
            catch (Exception ex)
            {
                return BadRequest($"Hata: {ex.Message}");
            }
        }

        [HttpPut("update-active-vehicle/{userId}/{vehicleId}")]
        public async Task<IActionResult> UpdateActiveVehicle(Guid userId, Guid vehicleId)
        {
            
            try
            {
                var vehicle = await _business.GetUpdatedActiveVehicle( userId,vehicleId);

                if (vehicle == null)
                {
                    return NotFound(); 
                }

                return Ok(vehicle);
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
        public async Task<IActionResult> DeleteByVehicleId(Guid userid,Guid vehicleId)
        {
            try
            {
                var existingVehicle = await _business.FirstOrDefault(v => v.UserId == userid && v.VehicleId == vehicleId && v.Status == 1);

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
                    return NotFound();
                }

                return Ok(userVehicles);
            }
            catch (Exception ex)
            {
                return BadRequest($"Hata: {ex.Message}");
            }
        }

        [HttpGet("GetUserVehicleWithActiveStatus/{userId}")]
        public async Task<IActionResult> GetUserVehicleWithActiveStatus(Guid userId)
        {
            try
            {
                var activeUserVehicle = await _business.FirstOrDefault(v => v.UserId == userId && v.ActiveStatus == 1);

                if (activeUserVehicle != null)
                {
                    return Ok(activeUserVehicle);
                }

                return Ok(null);
            }
            catch (Exception ex)
            {
                return BadRequest($"Hata: {ex.Message}");
            }
        }

        [HttpGet("GetUserVehicleActiveStatusWithConnector/{userId}")]
        public async Task<IActionResult> GetUserVehicleActiveStatusWithConnector(Guid userId)
        {
             
            try
            {
                var userVehicle = await _business.GetActiveUserVehicleConnector(userId);

                if (userVehicle == null)
                {
                    return NotFound();
                }

                return Ok(userVehicle.ConnectorId);
            }
            catch (Exception ex)
            {
                return BadRequest($"Hata: {ex.Message}");
            }

        }


        [HttpGet("GetActiveVehicle/{userId}")]
        public async Task<IActionResult> GetActiveVehicle(Guid userId)
        {

            try
            {
                var vehicle = await _business.GetActiveVehicle(userId);

                if (vehicle == null)
                {
                    return NotFound();
                }

                return Ok(vehicle);
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
