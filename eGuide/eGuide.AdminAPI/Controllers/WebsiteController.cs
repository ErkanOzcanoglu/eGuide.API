using AutoMapper;
using eGuide.Business.Interface;
using eGuide.Data.Dto.OutComing.Admin;
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
        public async Task<ActionResult<WebsiteDto>> All() {
            try {
                var websites = await _business.GetAllAsync();

                if (websites == null || !websites.Any()) {
                    return NotFound("There are no websites in the database or the database is empty.");
                }

                var websitedto = _mapper.Map<List<WebsiteDto>>(websites.ToList());

                return Ok(websitedto);
            }
            catch (DbUpdateException ex) {
                return BadRequest("An error occurred while accessing the database. Please try again later.");
            }
        }
    }
}
