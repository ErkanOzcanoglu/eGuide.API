using AutoMapper;
using eGuide.Business.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace eGuide.Service.ClientAPI.Controllers {
    [Route("api/[controller]")]
    [ApiController]
    public class SocialMediaController : ControllerBase {
        private readonly ISocialMediaBusiness _business;
        private readonly IMapper _mapper;

        public SocialMediaController(ISocialMediaBusiness business, IMapper mapper) {
            _business = business;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> Get() {
            var result = await _business.GetAllAsync();
            return Ok(result);
        }
    }
}
