using AutoMapper;
using eGuide.Business.Interface;
using eGuide.Data.Dto.InComing.CreationDto.Admin;
using eGuide.Data.Dto.InComing.CreationDto.Station;
using eGuide.Data.Dto.InComing.UpdateDto.Admin;
using eGuide.Data.Dto.InComing.UpdateDto.Station;
using eGuide.Data.Entities.Admin;
using eGuide.Data.Entities.Station;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace eGuide.Service.AdminAPI.Controllers {
    [Route("api/[controller]")]
    [ApiController]
    public class ServiceController : ControllerBase {

        /// <summary>
        /// The business
        /// </summary>
        private readonly IServiceBusiness _business;

        /// <summary>
        /// The mapper
        /// </summary>
        private readonly IMapper _mapper;

        /// <summary>
        /// Initializes a new instance of the <see cref="ServiceController"/> class.
        /// </summary>
        /// <param name="business">The business.</param>
        /// <param name="mapper">The mapper.</param>
        public ServiceController(IServiceBusiness business, IMapper mapper) {
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
        /// Gets the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="lang">The language.</param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<Services>> Get(Guid id, string lang) {

            var result = await _business.GetbyIdAsync(id);
            return Ok(result);
        }

        /// <summary>
        /// Posts the specified dto.
        /// </summary>
        /// <param name="dto">The dto.</param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult> Post(CreationDtoForService dto) {
            var entity = _mapper.Map<Services>(dto);
            var result = await _business.AddAsync(entity);
            return Ok(result);
        }

        /// <summary>
        /// Puts the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="service">The service.</param>
        /// <returns></returns>
        [HttpPut]
        public async Task<ActionResult<Services>> Put(Guid id, UpdateDtoForService service) {
            var entity = await _business.GetbyIdAsync(id);
            if (entity == null) {
                return NotFound();
            }

            entity.Name = service.Name;
            entity.Description = service.Description;
            entity.Image = service.Image;
            entity.Layout = service.Layout;
            entity.UpdatedDate = DateTime.Now;

            var mappedEntity = _mapper.Map<Services>(entity);

            await _business.UpdateAsync(mappedEntity);
            return Ok();
        }

        /// <summary>
        /// Deletes the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(Guid id) {
            var entity = await _business.GetbyIdAsync(id);
            if (entity == null) {
                return NotFound();
            }

            await _business.RemoveAsync(id);
            return Ok();
        }
    }
}
