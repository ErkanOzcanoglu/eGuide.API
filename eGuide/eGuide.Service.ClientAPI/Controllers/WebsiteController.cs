using AutoMapper;
using eGuide.Business.Interface;
using eGuide.Data.Entities.Admin;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace eGuide.Service.ClientAPI.Controllers {
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
    }
}
