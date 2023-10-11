using AutoMapper;
using eGuide.Business.Interface;
using eGuide.Data.Dto.InComing.CreationDto.Station;
using eGuide.Data.Entities.Station;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace eGuide.Service.AdminAPI.Controllers {
    [Route("api/[controller]")]
    [ApiController]
    public class SocketController : ControllerBase {
        private readonly ISocketBusiness _socketBusiness;
        private readonly IMapper _mapper;

        public SocketController(ISocketBusiness socketBusiness, IMapper mapper) {
            _socketBusiness = socketBusiness;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll() {
            var sockets = await _socketBusiness.GetAllAsync();
            return Ok(sockets);
        }

        [HttpPost]
        public async Task<IActionResult> AddSocket(CreationDtoForSocket socket) {
            var socketEntity = _mapper.Map<Socket>(socket);
            await _socketBusiness.AddAsync(socketEntity);
            return Ok();
        }
    }
}
