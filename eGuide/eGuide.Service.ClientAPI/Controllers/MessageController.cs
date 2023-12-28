using AutoMapper;
using eGuide.Business.Interface;
using eGuide.Data.Context.Context;
using eGuide.Data.Dto.InComing.CreationDto.Message;
using eGuide.Data.Entities.Hubs;
using eGuide.Data.Entities.Message;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.SignalR;

namespace eGuide.Service.ClientAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MessageController : ControllerBase
    {


        /// <summary>
        /// Initializes a new instance of the <see cref="UserController"/> class.
        /// </summary>
        /// <param name="business">The business.</param>
        /// <param name="mapper">The mapper.</param>
        /// 
        protected readonly eGuideContext _context;

        /// <summary>
        /// The mapper
        /// </summary>
        private readonly IMapper _mapper;

        /// <summary>
        /// The hub context
        /// </summary>
        private readonly IHubContext<BroadCastHub, IHubClient> _hubContext;

        /// <summary>
        /// Initializes a new instance of the <see cref="MessageController"/> class.
        /// </summary>
        /// <param name="mapper">The mapper.</param>
        /// <param name="hubContext">The hub context.</param>
        /// <param name="context">The context.</param>
        public MessageController(IMapper mapper, IHubContext<BroadCastHub, IHubClient> hubContext, eGuideContext context)
        {
          
            _mapper = mapper;
            _hubContext = hubContext;
            _context = context;
        }


        /// <summary>
        /// Broadcasts the message.
        /// </summary>
        /// <param name="messageDto">The message dto.</param>
        /// <returns></returns>
        [HttpPost("broadcast")]
        public async Task<IActionResult> BroadcastMessage(CreationDtoForMessage messageDto)
        {
            try
            {
                var receiverIdString = messageDto.ReceiverId.ToString();
                var message = _mapper.Map<Messages>(messageDto);
                await _context.Messages.AddAsync(message);
                await _context.SaveChangesAsync();
                await _hubContext.Clients.User(receiverIdString).BroadcastMessage(message);
                return Ok(message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal Server Error: {ex.Message}");
            }
        }
    }
}
