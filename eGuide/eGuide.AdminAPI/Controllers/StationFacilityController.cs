using AutoMapper;
using eGuide.Business.Interface;
using eGuide.Data.Dto.InComing.CreationDto.Station;
using eGuide.Data.Entites.Station;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace eGuide.Service.AdminAPI.Controllers {
    [Route("api/[controller]")]
    [ApiController]
    public class StationFacilityController : ControllerBase {
        private readonly IStationFacilityBusiness _business;
        private readonly IMapper _mapper;

        public StationFacilityController(IStationFacilityBusiness business, IMapper mapper) {
            _business = business;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult> Get() {
            var result = await _business.GetAllAsync();
            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult> Post(CreationDtoForStationFacility entity) {
            var entityMapped = _mapper.Map<StationFacility>(entity);
            var result = await _business.AddAsync(entityMapped);
            return Ok(result);
        }
    }
}
