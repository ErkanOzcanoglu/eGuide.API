using AutoMapper;
using eGuide.Business.Interface;
using eGuide.Data.Dto.InComing.CreationDto.Station;
using eGuide.Data.Entites.Station;
using eGuide.Data.Entities.Station;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace eGuide.Service.AdminAPI.Controllers {
    [Route("api/[controller]")]
    [ApiController]
    public class StationFacilityController : ControllerBase {

        /// <summary>
        /// The business
        /// </summary>
        private readonly IStationFacilityBusiness _business;

        /// <summary>
        /// The mapper
        /// </summary>
        private readonly IMapper _mapper;

        /// <summary>
        /// Initializes a new instance of the <see cref="StationFacilityController"/> class.
        /// </summary>
        /// <param name="business">The business.</param>
        /// <param name="mapper">The mapper.</param>
        public StationFacilityController(IStationFacilityBusiness business, IMapper mapper) {
            _business = business;
            _mapper = mapper;
        }

        /// <summary>
        /// Gets this instance.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult> Get() {
            var result = await _business.GetAllfac();
            return Ok(result);
        }

        /// <summary>
        /// Posts the specified entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult> Post(CreationDtoForStationFacility entity) {
            var entityMapped = _mapper.Map<StationFacility>(entity);
            var result = await _business.AddAsync(entityMapped);
            return Ok(result);
        }

        /// <summary>
        /// Hards the delete.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task<ActionResult<StationFacility>> HardDelete(Guid id) {
            await _business.HardRemoveAsync(id);
            return Ok();
        }

        [HttpGet("station-facility-by-station-id/{stationId}")]
        public async Task<ActionResult> GetFacByStationId(Guid stationId) {
            var result = await _business.GetFacByStationId(stationId);
            return Ok(result);
        }
    }
}
