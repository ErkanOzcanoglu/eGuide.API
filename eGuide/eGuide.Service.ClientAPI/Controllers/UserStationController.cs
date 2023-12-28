using AutoMapper;
using eGuide.Business.Interface;
using eGuide.Cache.Interface;
using eGuide.Data.Context.Context;
using eGuide.Data.Dto.InComing.CreationDto.Client;
using eGuide.Data.Dto.OutComing.Client;
using eGuide.Data.Dto.OutComing.Station;
using eGuide.Data.Entities.Client;
using eGuide.Data.Entities.Station;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace eGuide.Service.ClientAPI.Controllers
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
        private readonly ICache _cache;

        

        public UserStationController(IUserStationBusiness business, IMapper mapper, ICache cache)
        {
            _cache = cache;
            _business = business;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task Save(CreationDtoForUserStation userstation)
        {
            var userStation = await _business.Where(us => us.StationProfileId == userstation.StationProfileId).FirstOrDefaultAsync();// after where mention the number of return values

            if (userStation == null)
            {
                
               await _business.AddAsync(_mapper.Map<UserStation>(userstation));
                     
            }   
            
        }

        [HttpDelete("DeleteStationProfile/{id}")]
        public async Task<ActionResult> Delete(Guid id)
        {
            var userStation = await _business.Where(us => us.StationProfileId == id).FirstOrDefaultAsync();

            if (userStation != null)
            {
                try
                {
                    await _business.HardRemoveAsync(userStation.Id);// dont forget async
                    return Ok();
                }
                catch (Exception ex)
                {
                    return BadRequest($"Hata: {ex.Message}");
                }
            }
            else
            {
                return NotFound($"ID {id} ile eşleşen istasyon profili bulunamadı.");
            }
        }

        [HttpGet]
        public async Task<ActionResult<UserStationDto>> All()
        {
            try {
                var stations = await _business.GetAllAsync();

                if (stations == null || !stations.Any()) {
                    return NotFound("There are no vehicles in the database or the database is empty.");
                }

                var vehicledto = _mapper.Map<List<UserStationDto>>(stations.ToList());

                return Ok(vehicledto);
            } catch (DbUpdateException ex) {
                return BadRequest("An error occurred while accessing the database. Please try again later.");
            } catch (Exception ex) {
                return BadRequest($"Hata: {ex.Message}");
            }
        }

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
