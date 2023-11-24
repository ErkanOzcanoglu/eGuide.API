using AutoMapper;
using eGuide.Business.Interface;
using eGuide.Data.Dto.InComing.CreationDto.Admin;
using eGuide.Data.Dto.InComing.UpdateDto.Admin;
using eGuide.Data.Entities.Admin;
using eGuide.Data.Entities.Station;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using static System.Collections.Specialized.BitVector32;

namespace eGuide.Service.AdminAPI.Controllers {
    [Route("api/[controller]")]
    [ApiController]
    public class SocialMediaController : ControllerBase {

        /// <summary>
        /// The business
        /// </summary>
        private readonly ISocialMediaBusiness _business;

        /// <summary>
        /// The mapper
        /// </summary>
        private readonly IMapper _mapper;

        /// <summary>
        /// Initializes a new instance of the <see cref="SocialMediaController"/> class.
        /// </summary>
        /// <param name="business">The business.</param>
        /// <param name="mapper">The mapper.</param>
        public SocialMediaController(ISocialMediaBusiness business, IMapper mapper) {
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
        /// Posts the specified social media.
        /// </summary>
        /// <param name="socialMedia">The social media.</param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Post(CreationDtoForSocialMedia socialMedia) {
            var entity = _mapper.Map<SocialMedia>(socialMedia);
            var result = await _business.AddAsync(entity);
            return Ok(result);
        }

        /// <summary>
        /// Puts the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="socialMedia">The social media.</param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(Guid id, UpdateDtoForSocialMedia socialMedia) {
            var entity = await _business.GetbyIdAsync(id);
            if (entity == null) {
                return NotFound();
            }

            entity.Icon = socialMedia.Icon;
            entity.IconAlt = socialMedia.IconAlt;
            entity.Link = socialMedia.Link;
            entity.Name = socialMedia.Name;

            var mappedEntity = _mapper.Map<SocialMedia>(entity);

            await _business.UpdateAsync(mappedEntity);
            return Ok();
        }

        /// <summary>
        /// Deletes the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id) {
            var entity = await _business.GetbyIdAsync(id);
            if (entity == null) {
                return NotFound();
            }

            await _business.RemoveAsync(id);
            return Ok();
        }
    }
}
