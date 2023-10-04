using AutoMapper;
using eGuide.Business.Interface;
using eGuide.Data.Dto.OutComing.Station;
using eGuide.Data.Entities.Station;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace eGuide.Service.AdminAPI.Controllers {
    [Route("api/[controller]")]
    [ApiController]
    public class CommentController : ControllerBase {
        private readonly ICommentBusiness<Comment> _business;
        private readonly IMapper _mapper;

        public CommentController(ICommentBusiness<Comment> business, IMapper mapper) {
            _business = business;
            _mapper = mapper;

        }

        [HttpPost]
        public IActionResult CreateComment(CommentDto comment) {
            var commentEntity = _mapper.Map<Comment>(comment);
            _business.AddComment(commentEntity);
            return Ok();
        }

        [HttpGet]
        public async Task<IActionResult> GetAllComments() {
            var comments = await _business.GetAllComments();
            var commentsDto = _mapper.Map<CommentDto[]>(comments);
            return Ok(commentsDto);
        }
    }
}
