﻿using AutoMapper;
using eGuide.Business.Concrete;
using eGuide.Business.Interface;
using eGuide.Data.Dto.InComing.CreationDto.Station;
using eGuide.Data.Dto.InComing.UpdateDto.Station;
using eGuide.Data.Dto.OutComing.Station;
using eGuide.Data.Entities.Station;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace eGuide.Service.AdminAPI.Controllers {
    [Route("api/[controller]")]
    [ApiController]
    public class ConnectorController : ControllerBase {

        /// <summary>
        /// The business
        /// </summary>
        private readonly IConnectorBusiness _business;

        /// <summary>
        /// The mapper
        /// </summary>
        private readonly IMapper _mapper;

        /// <summary>
        /// Initializes a new instance of the <see cref="ConnectorController"/> class.
        /// </summary>
        /// <param name="business">The business.</param>
        /// <param name="mapper">The mapper.</param>
        public ConnectorController(IConnectorBusiness business, IMapper mapper) {
            _business = business;
            _mapper = mapper;
        }

        /// <summary>
        /// Gets this instance.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult> Get() {
            var result = await _business.GetCon();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Connector>> GetById(Guid id) {
            var result = await _business.GetbyIdAsync(id);
            return Ok(result);
        }

        /// <summary>
        /// Posts the specified connector.
        /// </summary>
        /// <param name="connector">The connector.</param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<Connector>> Post(CreationDtoForConnector connector) {
            var entity = _mapper.Map<Connector>(connector);
            var result = await _business.AddAsync(entity);
            return Ok(result);
        }

        /// <summary>
        /// Puts the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="connector">The connector.</param>
        /// <returns></returns>
        [HttpPut]
        public async Task<ActionResult> Put(Guid id, UpdateDtoForConnector connector) {
            var entity = await _business.GetbyIdAsync(id);
            if (entity == null) {
                return NotFound();
            }

            entity.Type = connector.Type;
            entity.ImageData = connector.ImageData;
            entity.ImageName = connector.ImageName;

            var mappedEntity = _mapper.Map<Connector>(entity);

            await _business.UpdateAsync(mappedEntity);
            return Ok();
        }

        /// <summary>
        /// Deletes the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        [HttpDelete]
        public async Task<ActionResult<Connector>> Delete(Guid id) {
            var result = _business.RemoveAsync(id);
            return Ok(result);
        }

        /// <summary>
        /// Hards the delete.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task<ActionResult<Connector>> HardDelete(Guid id) {
            await _business.HardRemoveAsync(id);
            return Ok();
        }
    }
}
