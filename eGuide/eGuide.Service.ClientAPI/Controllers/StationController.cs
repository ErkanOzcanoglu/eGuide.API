using AutoMapper;
using eGuide.Business.Interface;
using eGuide.Cache.Interface;
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
        /// The cache
        /// </summary>
        private readonly ICache _cache;

        /// <summary>
        /// Initializes a new instance of the <see cref="StationController"/> class.
        /// </summary>
        /// <param name="business">The business.</param>
        /// <param name="mapper">The mapper.</param>
        public StationController(IStationBusiness business, IMapper mapper, ICache cache) {
            _business = business;
            _cache = cache;
            _mapper = mapper;
        }

        /// <summary>
        /// Gets this instance.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> Get() {

            var cacheData = _cache.GetData<IEnumerable<StationProfile>>("station");

            if (cacheData != null && cacheData.Count() > 0)
                return Ok(cacheData);

            cacheData = await _business.GetAllS();
            var filteredResult = cacheData.Where(item => item.StationStatus == 1).ToList();

            var expirationTime = DateTimeOffset.Now.AddMinutes(60);
            _cache.SetData<IEnumerable<StationProfile>>("station", filteredResult, expirationTime);

            return Ok(filteredResult);
        }

        /// <summary>
        /// Gets the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<ActionResult> Get(Guid id) {
            var result = await _business.GetbyIdAsync(id);
            return Ok(result);
        }

        // clear cache 
        [HttpGet("clear")]
        public async Task<ActionResult> ClearCache() {
            _cache.RemoveData("station");
            //call get function
            this.Get();
            return Ok();
        }
    }
}
