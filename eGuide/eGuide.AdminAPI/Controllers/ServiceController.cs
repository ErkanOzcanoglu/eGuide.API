using eGuide.Business.Interface;
using eGuide.Common.Mappers;
using eGuide.Data.Dto.InComing.CreationDto.Admin;
using Microsoft.AspNetCore.Mvc;
using eGuide.Data.Entities.Admin;
using AutoMapper;

namespace eGuide.Service.AdminAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServiceController : ControllerBase
    {
        private readonly IServiceBusiness _serviceBusiness;
        private readonly IMapper _mapper;

        public ServiceController(IServiceBusiness socketBusiness, IMapper mapper)
        {
            _serviceBusiness = socketBusiness;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreationDtoForService entity)
        {

            await _serviceBusiness.AddAsync(_mapper.Map<Services>(entity));
            return Ok();

        }

    }
}
