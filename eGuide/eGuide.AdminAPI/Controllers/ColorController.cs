using AutoMapper;
using eGuide.Business.Interface;
using eGuide.Data.Dto.InComing.CreationDto.Admin;
using eGuide.Data.Dto.InComing.UpdateDto.Admin;
using eGuide.Data.Entities.Admin;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace eGuide.Service.AdminAPI.Controllers {
    [Route("api/[controller]")]
    [ApiController]
    public class ColorController : ControllerBase {

        /// <summary>
        /// The business
        /// </summary>
        private readonly IColorBusiness _business;

        /// <summary>
        /// The mapper
        /// </summary>
        private readonly IMapper _mapper;

        /// <summary>
        /// Initializes a new instance of the <see cref="ColorController"/> class.
        /// </summary>
        /// <param name="business">The business.</param>
        /// <param name="mapper">The mapper.</param>
        public ColorController(IColorBusiness business, IMapper mapper) {
            _business = business;
            _mapper = mapper;
        }

        /// <summary>
        /// Gets this instance.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> Get() {
            var result = await _business.GetAllAsync();
            return Ok(result);
        }

        /// <summary>
        /// Posts the specified dto.
        /// </summary>
        /// <param name="dto">The dto.</param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Post(CreationDtoForColor dto) {
            var entity = _mapper.Map<Color>(dto);
            var result = await _business.AddAsync(entity);
            return Ok(result);
        }

        /// <summary>
        /// Puts the specified dto.
        /// </summary>
        /// <param name="dto">The dto.</param>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(UpdateDtoForColor dto, Guid id) {
            var result = await _business.GetbyIdAsync(id);

            if (result == null) {
                return NotFound();
            }

            result.DarkColor1 = dto.DarkColor1;
            result.DarkColor2 = dto.DarkColor2;
            result.DarkColor3 = dto.DarkColor3;
            result.DarkColor4 = dto.DarkColor4;
            result.LightColor1 = dto.LightColor1;
            result.LightColor2 = dto.LightColor2;
            result.LightColor3 = dto.LightColor3;
            result.LightColor4 = dto.LightColor4;

            await _business.UpdateAsync(result);
            return Ok();
        }
    }
}
