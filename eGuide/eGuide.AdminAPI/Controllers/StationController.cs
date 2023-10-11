using AutoMapper;
using eGuide.Business.Interface;
using eGuide.Data.Dto.InComing.CreationDto.Station;
using eGuide.Data.Entities.Station;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace eGuide.Service.AdminAPI.Controllers {
    [Route("api/[controller]")]
    [ApiController]
    public class StationController : ControllerBase {
        private readonly IStationBusiness _business;
        private readonly IMapper _mapper;

        public StationController(IStationBusiness business, IMapper mapper) {
            _business = business;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult> Get() {
            var result = await _business.GetAllAsync();
            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult> Post(CreationDtoForStationProfile station) {
            var entity = _mapper.Map<StationProfile>(station);
            var result = await _business.AddAsync(entity);
            return Ok(result);
        }
    }
}
