using AutoMapper;
using eGuide.Business.Interface;
using eGuide.Data.Context.Context;
using eGuide.Data.Dto.InComing.CreationDto.Client;
using eGuide.Data.Entites.Client;
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
        private readonly IBusiness<UserVehicle> _business;

        private readonly IMapper _mapper;

        protected readonly eGuideContext _context;
        private readonly DbSet<UserVehicle> _dbSet;

        public UserVehicleController(IBusiness<UserVehicle> business, IMapper mapper, eGuideContext context)
        {
            _business = business;
            _mapper = mapper;

            _context = context;
            _dbSet = _context.Set<UserVehicle>();
        }

        [HttpPost]
        public async Task Save(CreationDtoForUserVehicle vehicledto)
        {
            await _business.AddAsync(_mapper.Map<UserVehicle>(vehicledto));
        }

        [HttpGet]
        public IActionResult Get(Guid userId) 
        {
            try
            {
                var userIdParameter = new SqlParameter("@UserId", SqlDbType.NVarChar, 60)
                {
                    Value = userId.ToString() 
                };

                var result = _context.Vehicle
                    .FromSqlRaw("EXEC GetVehiclesByUserID_V2 @UserId", userIdParameter)
                    .ToList();

                return Ok(result); // Sonuçları döndürün
            }
            catch (Exception ex)
            {
                return BadRequest($"Hata: {ex.Message}"); 
            }
        }
    }
}
