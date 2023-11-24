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
    public class CommentBusiness<T> : ICommentBusiness<T> where T : BaseModel {
        private readonly ICommentRepository<T> _commentRepository;

        public CommentBusiness(ICommentRepository<T> commentRepository) {
            _commentRepository = commentRepository;
        }

        public async void AddComment(T comment) {
            comment.Id = Guid.NewGuid();
            await _commentRepository.AddAsync(comment);
        }

        public async Task<IEnumerable<T>> GetAllComments() {
            return await _commentRepository.GetAllAsync();
        }
    }
}
