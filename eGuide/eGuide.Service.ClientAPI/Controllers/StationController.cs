using AutoMapper;
using eGuide.Business.Interface;
using eGuide.Data.Dto.InComing.CreationDto.Station;
using eGuide.Data.Dto.InComing.UpdateDto.Station;
using eGuide.Data.Entities.Station;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace eGuide.Service.ClientAPI.Controllers {
    [Route("api/[controller]")]
    [ApiController]
    public class StationController : ControllerBase {

        /// <summary>
        /// The business
        /// </summary>
        private readonly IStationBusiness _business;

        /// <summary>
        /// The mapper
        /// </summary>
        private readonly IMapper _mapper;

        /// <summary>
        /// Initializes a new instance of the <see cref="StationController"/> class.
        /// </summary>
        /// <param name="business">The business.</param>
        /// <param name="mapper">The mapper.</param>
        public StationController(IStationBusiness business, IMapper mapper) {
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

        [HttpGet("{id}")]
        public async Task<ActionResult> Get(Guid id) {
            var result = await _business.GetbyIdAsync(id);
            return Ok(result);
        }
    }
}
