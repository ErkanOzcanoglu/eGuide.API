using AutoMapper;
using eGuide.Business.Interface;
using eGuide.Data.Dto.InComing.CreationDto.Admin;
using eGuide.Data.Dto.InComing.UpdateDto.Admin;
using eGuide.Data.Dto.OutComing.Admin;
using eGuide.Data.Entities.Admin;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace eGuide.Service.AdminAPI.Controllers {
    [Route("api/[controller]")]
    [ApiController]
    public class WebsiteController : ControllerBase {

        /// <summary>
        /// The business
        /// </summary>
        private readonly IWebsiteBusiness _business;

        /// <summary>
        /// The mapper
        /// </summary>
        private readonly IMapper _mapper;

        /// <summary>
        /// Initializes a new instance of the <see cref="WebsiteController"/> class.
        /// </summary>
        /// <param name="business">The business.</param>
        /// <param name="mapper">The mapper.</param>
        public WebsiteController(IWebsiteBusiness business, IMapper mapper) {
            _business = business;
            _mapper = mapper;
        }

        /// <summary>
        /// Gets this instance.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult<Website>> Get() {
            var website = await _business.GetAllAsync();
            if (website == null) {
                return NotFound();
            }

            return Ok(website);
        }

        /// <summary>
        /// Gets the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<Website>> Get(Guid id) {
            var website = await _business.GetbyIdAsync(id);
            if (website == null) {
                return NotFound();
            }

            return Ok(website);
        }

        /// <summary>
        /// Creates the specified website.
        /// </summary>
        /// <param name="website">The website.</param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<Website>> Create(CreationDtoForWebsite website) {
            var entity = _mapper.Map<Website>(website);
            var result = await _business.AddAsync(entity);
            return Ok(result);
        }

        /// <summary>
        /// Updates the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="website">The website.</param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public async Task<ActionResult<Website>> Update(Guid id, UpdateDtoForWebsite website) {
            var entity = await _business.GetbyIdAsync(id);

            if (entity == null) {
                return NotFound();
            }

            entity.Footer = website.Footer;
            entity.Navbar = website.Navbar;
            entity.Name = website.Name;
            entity.Address = website.Address;
            entity.Description = website.Description;
            entity.Email = website.Email;
            entity.PhoneNumber = website.PhoneNumber;
            entity.UpdatedDate = DateTime.Now;


            var mappedEntity = _mapper.Map<Website>(entity);
            await _business.UpdateAsync(mappedEntity);
            return Ok(mappedEntity);
        }

        /// <summary>
        /// Updates the navbar.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="num">The number.</param>
        /// <returns></returns>
        [HttpPut("updateNavbar/{id}")]
        public async Task<ActionResult<Website>> UpdateNavbar(Guid id, int num) {
            var entity = await _business.GetbyIdAsync(id);

            if (entity == null) {
                return NotFound();
            }

            entity.Navbar = num;
            entity.UpdatedDate = DateTime.Now;

            var mappedEntity = _mapper.Map<Website>(entity);

            await _business.UpdateAsync(mappedEntity);
            return Ok(mappedEntity);
        }

        /// <summary>
        /// Updates the footer.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="num">The number.</param>
        /// <returns></returns>
        [HttpPut("updateFooter/{id}")]
        public async Task<ActionResult<Website>> UpdateFooter(Guid id, int num) {
            var entity = await _business.GetbyIdAsync(id);

            if (entity == null) {
                return NotFound();
            }

            entity.Footer = num;
            entity.UpdatedDate = DateTime.Now;

            var mappedEntity = _mapper.Map<Website>(entity);

            await _business.UpdateAsync(mappedEntity);
            return Ok(mappedEntity);
        }
    }
}
