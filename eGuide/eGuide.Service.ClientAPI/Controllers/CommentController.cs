using AutoMapper;
using eGuide.Business.Interface;
using eGuide.Data.Dto.OutComing.Station;
using eGuide.Data.Entities.Station;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace eGuide.Service.ClientAPI.Controllers {
    [Route("api/[controller]")]
    [ApiController]
    public class CommentController : ControllerBase {
        /// <summary>
        /// The business
        /// </summary>
        private readonly ICommentBusiness _business;

        /// <summary>
        /// The mapper
        /// </summary>
        private readonly IMapper _mapper;

        /// <summary>
        /// Initializes a new instance of the <see cref="CommentController"/> class.
        /// </summary>
        /// <param name="business">The business.</param>
        /// <param name="mapper">The mapper.</param>
        public CommentController(ICommentBusiness business, IMapper mapper) {
            _business = business;
            _mapper = mapper;

        }

        /// <summary>
        /// Creates the comment.
        /// </summary>
        /// <param name="comment">The comment.</param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult CreateComment(CommentDto comment) {
            var commentEntity = _mapper.Map<Comment>(comment);
            _business.AddComment(commentEntity);
            return Ok();
        }

        /// <summary>
        /// Gets all comments.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetAllComments() {
            var comments = await _business.GetAllComments();
            var commentsDto = _mapper.Map<CommentDto[]>(comments);
            return Ok(commentsDto);
        }

        [HttpGet("{stationId}")]
        public async Task<IActionResult> GetCommentsByStationId(Guid stationId) {
            var comments = await _business.GetAllCommentsByStationId(stationId);
            var commentsDto = _mapper.Map<CommentDto[]>(comments);
            return Ok(commentsDto);
        }
    }
}