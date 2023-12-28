using eGuide.Business.Interface;
using eGuide.Data.Entities;
using eGuide.Data.Entities.Station;
using eGuide.Infrastructure.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eGuide.Business.Concrete {
    public class CommentBusiness : ICommentBusiness {
        private readonly ICommentRepository _commentRepository;

        public CommentBusiness(ICommentRepository commentRepository) {
            _commentRepository = commentRepository;
        }

        public async void AddComment(Comment comment) {
            comment.Id = Guid.NewGuid();
            await _commentRepository.AddAsync(comment);
        }

        public async Task<IEnumerable<Comment>> GetAllComments() {
            return await _commentRepository.GetAllAsync();
        }

        public Task<IEnumerable<Comment>> GetAllCommentsByStationId(Guid stationId) {
            return _commentRepository.GetAllByStationIdAsync(stationId);
        }
    }
}
