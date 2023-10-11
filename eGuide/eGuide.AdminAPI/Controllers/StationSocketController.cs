using AutoMapper;
using eGuide.Business.Interface;
using eGuide.Data.Dto.InComing.CreationDto.Station;
using eGuide.Data.Entites.Station;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace eGuide.Service.AdminAPI.Controllers {
    [Route("api/[controller]")]
    [ApiController]
    public class StationSocketController : ControllerBase {
        private readonly IStationSocketBusiness _stationSocketBusiness;
        private readonly IMapper _mapper;

        public StationSocketController(IStationSocketBusiness stationSocketBusiness, IMapper mapper) {
            _stationSocketBusiness = stationSocketBusiness;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll() {
            var stationSockets = await _stationSocketBusiness.GetAllAsync();
            return Ok(stationSockets);
        }

        [HttpPost]
        public async Task<IActionResult> AddStationSocket(CreationDtoForStationSockets stationSocket) {
            var stationSocketEntity = _mapper.Map<StationSockets>(stationSocket);
            await _stationSocketBusiness.AddAsync(stationSocketEntity);
            return Ok();
        }
    }
}
