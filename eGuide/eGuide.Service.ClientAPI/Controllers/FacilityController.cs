using AutoMapper;
using eGuide.Business.Interface;
using eGuide.Data.Dto.InComing.CreationDto.Station;
using eGuide.Data.Entites.Station;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace eGuide.Service.ClientAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FacilityController : ControllerBase
    {
        /// <summary>
        /// The business
        /// </summary>
        private readonly IFacilityBusiness _business;

        /// <summary>
        /// The mapper
        /// </summary>
        private readonly IMapper _mapper;

        /// <summary>
        /// Initializes a new instance of the <see cref="StationFacilityController"/> class.
        /// </summary>
        /// <param name="business">The business.</param>
        /// <param name="mapper">The mapper.</param>
        public FacilityController(IFacilityBusiness business, IMapper mapper)
        {
            _business = business;
            _mapper = mapper;
        }
       

        [HttpGet("facility-by-facility-id/{facilityId}")]
        public async Task<ActionResult> GetFacilityById(Guid facilityId)
        {
            var result = await _business.GetByFacilityId(facilityId);
            return Ok(result);
        }

        [HttpGet]
        public async Task<ActionResult> Get()
        {
            var result = await _business.GetAllAsync();
            return Ok(result);
        }
    }
}
