using eGuide.Data.Entities.Station;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eGuide.Business.Interface {
    public interface ICommentBusiness {
        /// <summary>
        /// Adds the comment.
        /// </summary>
        /// <param name="comment">The comment.</param>
        void AddComment(Comment comment);

        /// <summary>
        /// Gets all comments.
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<Comment>> GetAllComments();

        /// <summary>
        /// Gets all comments by station identifier.
        /// </summary>
        /// <param name="stationId">The station identifier.</param>
        /// <returns></returns>
        Task<IEnumerable<Comment>> GetAllCommentsByStationId(Guid stationId);
    }
}
