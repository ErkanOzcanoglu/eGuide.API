﻿using AutoMapper;
using eGuide.Business.Concrete;
using eGuide.Business.Interface;
using eGuide.Data.Context.Context;
using eGuide.Data.Dto.InComing.CreationDto.Station;
using eGuide.Data.Dto.InComing.UpdateDto.Station;
using eGuide.Data.Entities.Station;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace eGuide.Service.AdminAPI.Controllers {
    [Route("api/[controller]")]
    [ApiController]
    public class StationController : ControllerBase {

        /// <summary>
        /// The business
        /// </summary>
        private readonly IStationBusiness _business;

        /// <summary>
        /// The database set
        /// </summary>
        private readonly DbSet<StationInformationModel> _dbSet;

        /// <summary>
        /// The context
        /// </summary>
        private readonly eGuideContext _context;


        /// <summary>
        /// The mapper
        /// </summary>
        private readonly IMapper _mapper;

        /// <summary>
        /// Initializes a new instance of the <see cref="StationController"/> class.
        /// </summary>
        /// <param name="business">The business.</param>
        /// <param name="mapper">The mapper.</param>
        public StationController(IStationBusiness business, IMapper mapper ,eGuideContext context) {
           
            _business = business;
            _mapper = mapper;
            _context = context;
            _dbSet=_context.Set<StationInformationModel>();
        }

        /// <summary>
        /// Gets this instance.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult> Get() {
            var result = await _business.GetAllAsync();
            return Ok(result);
        }

        /// <summary>
        /// Posts the specified station.
        /// </summary>
        /// <param name="station">The station.</param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<StationProfile>> Post(CreationDtoForStationProfile station) {
            var entity = _mapper.Map<StationProfile>(station);
            var result = await _business.AddAsync(entity);
            return Ok(result);
        }

        /// <summary>
        /// Puts the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="station">The station.</param>
        /// <returns></returns>
        [HttpPut]
        public async Task<ActionResult<StationProfile>> Put(Guid id, UpdateDtoForStationProfile station) {
            var entity = await _business.GetbyIdAsync(id);
            if (entity == null) {
                return NotFound();
            }

            entity.Address = station.Address;
            entity.Latitude = station.Latitude;
            entity.Longitude = station.Longtitude;
            entity.Name = station.Name;

            var mappedEntity = _mapper.Map<StationProfile>(entity);

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

        /// <summary>
        /// Gets all station profile information.
        /// </summary>
        /// <returns></returns>
        [HttpGet("GetAllStationProfile")]
        public async Task<IActionResult> GetAllStationProfileInformation()
        {
            try
            {
                var stationInformation = _dbSet.FromSqlRaw("EXEC [GetStationInformation]").ToList();
                return new JsonResult(stationInformation);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex}");
            }

        }
 
    }
}