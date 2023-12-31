﻿using AutoMapper;
using eGuide.Business.Concrete;
using eGuide.Business.Interface;
using eGuide.Data.Dto.InComing.CreationDto.Station;
using eGuide.Data.Dto.InComing.UpdateDto.Station;
using eGuide.Data.Entities.Station;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace eGuide.Service.AdminAPI.Controllers {
    [Route("api/[controller]")]
    [ApiController]
    public class ChargingUnitController : ControllerBase {

        /// <summary>
        /// The socket business
        /// </summary>
        private readonly IChargingUnitBusiness _socketBusiness;

        /// <summary>
        /// The mapper
        /// </summary>
        private readonly IMapper _mapper;

        /// <summary>
        /// Initializes a new instance of the <see cref="ChargingUnitController"/> class.
        /// </summary>
        /// <param name="socketBusiness">The socket business.</param>
        /// <param name="mapper">The mapper.</param>
        public ChargingUnitController(IChargingUnitBusiness socketBusiness, IMapper mapper) {
            _socketBusiness = socketBusiness;
            _mapper = mapper;
        }

        /// <summary>
        /// Gets all.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetAll() {
            var sockets = await _socketBusiness.GetAllAsync();
            return Ok(sockets);
        }

        /// <summary>
        /// Gets the by identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id) {
            var socket = await _socketBusiness.GetbyIdAsync(id);
            return Ok(socket);
        }

        /// <summary>
        /// Adds the socket.
        /// </summary>
        /// <param name="socket">The socket.</param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<ChargingUnit>> AddSocket(CreationDtoForChargingUnit socket) {
            var socketEntity = _mapper.Map<ChargingUnit>(socket);
            var result = await _socketBusiness.AddAsync(socketEntity);
            return Ok(result);
        }

        /// <summary>
        /// Puts the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="connector">The connector.</param>
        /// <returns></returns>
        [HttpPut]
        public async Task<ActionResult> Put(Guid id, UpdateDtoForChargingUnit connector) {
            var entity = await _socketBusiness.GetbyIdAsync(id);
            if (entity == null) {
                return NotFound();
            }

            entity.Voltage = connector.Voltage;
            entity.Current = connector.Current;
            entity.Name = connector.Name;
            entity.Power = connector.Power;
            entity.Type = connector.Type;

            var mappedEntity = _mapper.Map<ChargingUnit>(entity);

            await _socketBusiness.UpdateAsync(mappedEntity);
            return Ok();
        }

        /// <summary>
        /// Deletes the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        [HttpDelete]
        public async Task<ActionResult<ChargingUnit>> Delete(Guid id) {
            var result = _socketBusiness.RemoveAsync(id);
            return Ok(result);
        }

        /// <summary>
        /// Hards the delete.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task<ActionResult<ChargingUnit>> HardDelete(Guid id) {
            await _socketBusiness.HardRemoveAsync(id);
            return Ok();
        }

        [HttpGet("AllChargingUnits")]
        public async Task<IActionResult> GetCon() {
            var sockets = await _socketBusiness.GetChargingUnits();
            return Ok(sockets);
        }
    }
}
