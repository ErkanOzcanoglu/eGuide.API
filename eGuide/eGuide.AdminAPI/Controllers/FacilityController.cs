using AutoMapper;
using eGuide.Business.Interface;
using eGuide.Data.Dto.InComing.CreationDto.Station;
using eGuide.Data.Dto.InComing.UpdateDto.Station;
using eGuide.Data.Entities.Station;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace eGuide.Service.AdminAPI.Controllers {
    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="Microsoft.AspNetCore.Mvc.ControllerBase" />
    [Route("api/[controller]")]
    [ApiController]
    public class FacilityController : ControllerBase {

        /// <summary>
        /// The business
        /// </summary>
        private readonly IFacilityBusiness _business;

        /// <summary>
        /// The mapper
        /// </summary>
        private readonly IMapper _mapper;

        /// <summary>
        /// Initializes a new instance of the <see cref="FacilityController"/> class.
        /// </summary>
        /// <param name="business">The business.</param>
        /// <param name="mapper">The mapper.</param>
        public FacilityController(IFacilityBusiness business, IMapper mapper) {
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
        /// Gets the by identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<Facility>> GetById(Guid id) {
            var result = await _business.GetbyIdAsync(id);
            return Ok(result);
        }

        /// <summary>
        /// Posts the specified facility.
        /// </summary>
        /// <param name="facility">The facility.</param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<Facility>> Post(CreationDtoForFacility facility) {
            var entity = _mapper.Map<Facility>(facility);
            var result = await _business.AddAsync(entity);
            return Ok(result);
        }

        /// <summary>
        /// Puts the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="facility">The facility.</param>
        /// <returns></returns>
        [HttpPut]
        public async Task<ActionResult<Facility>> Put(Guid id, UpdateDtoForFacility facility) {
            var entity = await _business.GetbyIdAsync(id);
            if (entity == null) {
                return NotFound();
            }

            entity.Name = facility.Name;
            entity.Type = facility.Type;
            entity.Icon = facility.Icon;
            entity.UpdatedDate = DateTime.Now;

            var mappedEntity = _mapper.Map<Facility>(entity);

            await _business.UpdateAsync(mappedEntity);
            return Ok();
        }

        /// <summary>
        /// Deletes the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        [HttpDelete]
        public async Task<ActionResult<Facility>> Delete(Guid id) {
            var entity = await _business.GetbyIdAsync(id);
            if (entity == null) {
                return NotFound();
            }

            await _business.RemoveAsync(id);
            return Ok();
        }
    }
}
