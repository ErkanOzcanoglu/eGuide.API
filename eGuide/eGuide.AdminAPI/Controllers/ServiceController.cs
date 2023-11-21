using AutoMapper;
using eGuide.Business.Interface;
using eGuide.Data.Dto.InComing.CreationDto.Admin;
using eGuide.Data.Dto.InComing.CreationDto.Station;
using eGuide.Data.Dto.InComing.UpdateDto.Admin;
using eGuide.Data.Dto.InComing.UpdateDto.Station;
using eGuide.Data.Entities.Admin;
using eGuide.Data.Entities.Station;
using Microsoft.AspNetCore.Mvc;

namespace eGuide.Service.AdminAPI.Controllers {
    [Route("api/[controller]")]
    [ApiController]
    public class ServiceController : ControllerBase {
        private readonly IServiceBusiness _business;
        private readonly IMapper _mapper;

        public ServiceController(IServiceBusiness business, IMapper mapper) {
            _business = business;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult> Get() {
            var result = await _business.GetAllAsync();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Services>> Get(Guid id) {
            var result = await _business.GetbyIdAsync(id);
            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult> Post(CreationDtoForService dto) {
            var entity = _mapper.Map<Services>(dto);
            var result = await _business.AddAsync(entity);
            return Ok(result);
        }

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
