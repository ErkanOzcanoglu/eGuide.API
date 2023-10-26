using AutoMapper;
using eGuide.Business.Concrete;
using eGuide.Business.Interface;
using eGuide.Data.Dto.InComing.CreationDto.Station;
using eGuide.Data.Dto.InComing.UpdateDto.Station;
using eGuide.Data.Entities.Station;
using eGuide.Data.Entities.Station;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace eGuide.Service.AdminAPI.Controllers {
    [Route("api/[controller]")]
    [ApiController]
    public class StationSocketController : ControllerBase {

        /// <summary>
        /// The station socket business
        /// </summary>
        private readonly IStationSocketBusiness _stationSocketBusiness;

        /// <summary>
        /// The mapper
        /// </summary>
        private readonly IMapper _mapper;

        /// <summary>
        /// Initializes a new instance of the <see cref="StationSocketController"/> class.
        /// </summary>
        /// <param name="stationSocketBusiness">The station socket business.</param>
        /// <param name="mapper">The mapper.</param>
        public StationSocketController(IStationSocketBusiness stationSocketBusiness, IMapper mapper) {
            _stationSocketBusiness = stationSocketBusiness;
            _mapper = mapper;
        }

        /// <summary>
        /// Gets all.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetAll() {
            var stationSockets = await _stationSocketBusiness.GetAllAsync();
            return Ok(stationSockets);
        }

        /// <summary>
        /// Adds the station socket.
        /// </summary>
        /// <param name="stationSocket">The station socket.</param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> AddStationSocket(CreationDtoForStationSockets stationSocket) {
            var stationSocketEntity = _mapper.Map<StationSockets>(stationSocket);
            await _stationSocketBusiness.AddAsync(stationSocketEntity);
            return Ok();
        }

        /// <summary>
        /// Puts the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="stationSocket">The station socket.</param>
        /// <returns></returns>
        [HttpPut]
        public async Task<ActionResult> Put(Guid id, UpdateDtoForStationSocket stationSocket) {
            var entity = await _stationSocketBusiness.GetbyIdAsync(id);
            if (entity == null) {
                return NotFound();
            }
            entity.StationModelId = stationSocket.StationModelId;
            entity.SocketId = stationSocket.SocketId;

            var mappedEntity = _mapper.Map<StationSockets>(entity);

            await _stationSocketBusiness.UpdateAsync(mappedEntity);
            return Ok();
        }

        /// <summary>
        /// Deletes the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        [HttpDelete]
        public async Task<ActionResult> Delete(Guid id) {
            await _stationSocketBusiness.RemoveAsync(id);
            return Ok();
        }
    }
}
