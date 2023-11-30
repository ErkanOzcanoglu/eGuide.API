using eGuide.Data.Entities.Station;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eGuide.Infrastructure.Interface {

    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface ICommentRepository {

        /// <summary>
        /// Adds the asynchronous.
        /// </summary>
        /// <param name="comment">The comment.</param>
        /// <returns></returns>
        Task<Comment> AddAsync(Comment comment);

        /// <summary>
        /// Gets all asynchronous.
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<Comment>> GetAllAsync();

        /// <summary>
        /// Gets all by station identifier asynchronous.
        /// </summary>
        /// <param name="stationId">The station identifier.</param>
        /// <returns></returns>
        Task<IEnumerable<Comment>> GetAllByStationIdAsync(Guid stationId);
    }
}
