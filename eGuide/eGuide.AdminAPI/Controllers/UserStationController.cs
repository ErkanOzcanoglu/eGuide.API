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

        /// <summary>
        /// Initializes a new instance of the <see cref="UserStationController"/> class.
        /// </summary>
        /// <param name="business">The business.</param>
        /// <param name="mapper">The mapper.</param>
        public UserStationController(IUserStationBusiness business, IMapper mapper)
        {
            _business = business;
            _mapper = mapper;
        }

        /// <summary>
        /// Gets the total user count for station.
        /// </summary>
        /// <param name="stationId">The station identifier.</param>
        /// <returns></returns>
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

        /// <summary>
        /// Gets the distinct station ids.
        /// </summary>
        /// <returns></returns>
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

        /// <summary>
        /// Gets the station profiles.
        /// </summary>
        /// <param name="userId">The user identifier.</param>
        /// <returns></returns>
        [HttpGet("GetStationProfile/{userId}")]
        public async Task<IActionResult> GetStationProfiles(Guid userId)
        {
            try
            {
                var stationProfiles = await _business.GetUserStationsProfilesAsync(userId);

                if (stationProfiles == null)
                {
                    return NotFound(); // Kullanıcıya ait araçlar bulunamadıysa 404 dönebilirsiniz.
                }

                return Ok(stationProfiles);

            }
            catch (Exception ex)
            {
                return BadRequest($"Hata: {ex.Message}");
            }
        }
    }
}
