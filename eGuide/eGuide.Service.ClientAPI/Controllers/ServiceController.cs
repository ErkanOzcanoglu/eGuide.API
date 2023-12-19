using AutoMapper;
using eGuide.Business.Interface;
using eGuide.Data.Entities.Admin;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace eGuide.Service.ClientAPI.Controllers {
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
        [HttpGet("lang")]
        public async Task<ActionResult> Get(string lang)
        {
            IQueryable<Services> services;

            if (lang == "en")
            {
                services = _business.Where(v => v.Language == "en" && v.Status==1);
            }
            else if (lang == "tr")
            {
                services = _business.Where(v => v.Language == "tr" && v.Status == 1);
            }
            else
            {
                return BadRequest("Desteklenmeyen dil");
            }

            var result = await services.ToListAsync();
            return Ok(result);
        }
    }
}
