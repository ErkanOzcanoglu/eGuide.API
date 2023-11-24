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
        private readonly IWebsiteBusiness _business;
        private readonly IMapper _mapper;

        public WebsiteController(IWebsiteBusiness business, IMapper mapper) {
            _business = business;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<Website>> All() {
            var websites = await _business.GetAllAsync();
            return Ok(websites); 
        }

        [HttpPost]
        public async Task<ActionResult<Website>> Create(CreationDtoForWebsite website) {
            var entity = _mapper.Map<Website>(website);
            var result = await _business.AddAsync(entity);
            return Ok(result);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Website>> Update(Guid id, UpdateDtoForWebsite website) {
            var entity = await _business.GetbyIdAsync(id);

            if (entity == null) {
                return NotFound();
            }

            entity.Footer = website.Footer;
            entity.Navbar = website.Navbar;
            entity.UpdatedDate = DateTime.Now;


            var mappedEntity = _mapper.Map<Website>(entity);
            await _business.UpdateAsync(mappedEntity);
            return Ok(mappedEntity);
        }
    }
}
