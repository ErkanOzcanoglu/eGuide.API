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

        /// <summary>
        /// The comment repository
        /// </summary>
        private readonly ICommentRepository _commentRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="CommentBusiness"/> class.
        /// </summary>
        /// <param name="commentRepository">The comment repository.</param>
        public CommentBusiness(ICommentRepository commentRepository) {
            _commentRepository = commentRepository;
        }

        /// <summary>
        /// Adds the comment.
        /// </summary>
        /// <param name="comment">The comment.</param>
        public async void AddComment(Comment comment) {
            comment.Id = Guid.NewGuid();
            await _commentRepository.AddAsync(comment);
        }

        /// <summary>
        /// Gets all comments.
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<Comment>> GetAllComments() {
            return await _commentRepository.GetAllAsync();
        }

        /// <summary>
        /// Gets all comments by station identifier.
        /// </summary>
        /// <param name="stationId">The station identifier.</param>
        /// <returns></returns>
        public Task<IEnumerable<Comment>> GetAllCommentsByStationId(Guid stationId) {
            return _commentRepository.GetAllByStationIdAsync(stationId);
        }
    }
}
