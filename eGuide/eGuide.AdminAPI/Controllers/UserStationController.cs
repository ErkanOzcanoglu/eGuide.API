using AutoMapper;
using eGuide.Business.Interface;
using eGuide.Data.Context.Context;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace eGuide.Service.AdminAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserStationController : ControllerBase
    {
        /// <summary>
        /// The business
        /// </summary>
        private readonly IUserStationBusiness _business;

        /// <summary>
        /// The mapper
        /// </summary>
        private readonly IMapper _mapper;

        protected readonly eGuideContext _context;


        public UserStationController(IUserStationBusiness business, IMapper mapper)
        {
            _business = business;
            _mapper = mapper;
        }

        [HttpGet("GetTotalUserCountForStation/{stationId}")]
        public async Task<IActionResult> GetTotalUserCountForStation(Guid stationId)
        {
            try
            {
                var totalUserCount = await _business.Where(us => us.StationProfileId == stationId).CountAsync();
                 
                return Ok(totalUserCount);
            }
            catch (Exception ex)
            {
                return BadRequest($"Hata: {ex.Message}");
            }
        }

        [HttpGet("GetDistinctStationIds")]
        public async Task<IActionResult> GetDistinctStationIds()
        {
            try
            {
                var userStations = await _business.GetAllAsync();
                var distinctStationIds = userStations.Select(us => us.StationProfileId).Distinct().ToList();

                return Ok(distinctStationIds);
            }
            catch (Exception ex)
            {
                return BadRequest($"Hata: {ex.Message}");
            }
        }
    }
}
