using AutoMapper;
using eGuide.Business.Concrete;
using eGuide.Business.Interface;
using eGuide.Data.Context.Context;
using eGuide.Data.Dto.InComing.CreationDto.Station;
using eGuide.Data.Dto.InComing.UpdateDto.Station;
using eGuide.Data.Dto.OutComing.Station;
using eGuide.Data.Entites.Station;
using eGuide.Data.Entities.Station;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace eGuide.Service.AdminAPI.Controllers {
    [Route("api/[controller]")]
    [ApiController]
    public class StationsChargingUnitController : ControllerBase {

        /// <summary>
        /// The station socket business
        /// </summary>
        private readonly IStationChargingUnitBusiness _business;

        /// <summary>
        /// The mapper
        /// </summary>
        private readonly IMapper _mapper;

        /// <summary>
        /// Initializes a new instance of the <see cref="StationsChargingUnitController" /> class.
        /// </summary>
        /// <param name="business">The business.</param>
        /// <param name="mapper">The mapper.</param>
        public StationsChargingUnitController(IStationChargingUnitBusiness business, IMapper mapper) {
            _business = business;
            _mapper = mapper;
        }

        /// <summary>
        /// Gets all.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetAll() {
            var stationChargingUnit = await _business.GetAllAsync();
            return Ok(stationChargingUnit);
        }

        /// <summary>
        /// Adds the station socket.
        /// </summary>
        /// <param name="stationChargingUnit">The station charging unit.</param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> AddStationChargingUnit(CreationDtoForStationChargingUnit stationChargingUnit) {
            var stationChargingUnitEntity = _mapper.Map<StationsChargingUnits>(stationChargingUnit);
            await _business.AddAsync(stationChargingUnitEntity);
            return Ok();
        }

        /// <summary>
        /// Puts the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="stationChargingUnit">The station charging unit.</param>
        /// <returns></returns>
        [HttpPut]
        public async Task<ActionResult> Put(Guid id, UpdateDtoForStationChargingUnit stationChargingUnit) {
            var entity = await _business.GetbyIdAsync(id);
            if (entity == null) {
                return NotFound();
            }
            entity.StationModelId = stationChargingUnit.StationModelId;
            entity.ChargingUnitId = stationChargingUnit.ChargingUnitId;

            var mappedEntity = _mapper.Map<StationsChargingUnits>(entity);

            await _business.UpdateAsync(mappedEntity);
            return Ok();
        }

        /// <summary>
        /// Deletes the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        [HttpDelete]
        public async Task<ActionResult> Delete(Guid id) {
            await _business.RemoveAsync(id);
            return Ok();
        }
    }
}
