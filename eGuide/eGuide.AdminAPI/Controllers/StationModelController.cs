using AutoMapper;
using eGuide.Business.Interface;
using eGuide.Data.Dto.InComing.CreationDto.Station;
using eGuide.Data.Dto.InComing.UpdateDto.Station;
using eGuide.Data.Entites.Station;
using eGuide.Data.Entities.Station;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace eGuide.Service.AdminAPI.Controllers {
    [Route("api/[controller]")]
    [ApiController]
    public class StationModelController : ControllerBase {

        /// <summary>
        /// The business
        /// </summary>
        private readonly IStationModelBusiness _business;

        /// <summary>
        /// The mapper
        /// </summary>
        private readonly IMapper _mapper;

        /// <summary>
        /// Initializes a new instance of the <see cref="StationModelController"/> class.
        /// </summary>
        /// <param name="business">The business.</param>
        /// <param name="mapper">The mapper.</param>
        public StationModelController(IStationModelBusiness business, IMapper mapper) {
            _business = business;
            _mapper = mapper;
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
        /// Posts the specified entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult> Post(CreationDtoForStationModel entity) {
            var entityMapped = _mapper.Map<StationModel>(entity);
            var result = await _business.AddAsync(entityMapped);
            return Ok(result);
        }

        /// <summary>
        /// Puts the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="stationModel">The station model.</param>
        /// <returns></returns>
        [HttpPut]
        public async Task<ActionResult> Put(Guid id, UpdateDtoForStationModel stationModel) {
            var entity = await _business.GetbyIdAsync(id);
            if (entity == null) {
                return NotFound();
            }

            entity.Name = stationModel.Name;

            var mappedEntity = _mapper.Map<StationModel>(entity);

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
        /// Hards the delete.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task<ActionResult<StationModel>> HardDelete(Guid id) {
            await _business.HardRemoveAsync(id);
            return Ok();
        }
    }
}
