using eGuide.Data.Context.Context;
using eGuide.Data.Entities.Station;
using eGuide.Infrastructure.Interface;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eGuide.Infrastructure.Conctrete {
    public class CommentRepository : ICommentRepository{

        /// <summary>
        /// The collection
        /// </summary>
        private readonly IMongoCollection<Comment> _collection;

        /// <summary>
        /// Initializes a new instance of the <see cref="CommentRepository"/> class.
        /// </summary>
        /// <param name="context">The context.</param>
        public CommentRepository(IMongoDatabase context) {
            _collection = context.GetCollection<Comment>("Comments");
        }

        /// <summary>
        /// Adds the asynchronous.
        /// </summary>
        /// <param name="comment">The comment.</param>
        /// <returns></returns>
        public async Task<Comment> AddAsync(Comment comment) {
            await _collection.InsertOneAsync(comment);
            return comment;
        }

        /// <summary>
        /// Gets all asynchronous.
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<Comment>> GetAllAsync() {
            return await _collection.Find(_ => true).ToListAsync();
        }

        /// <summary>
        /// Gets all by station identifier asynchronous.
        /// </summary>
        /// <param name="stationId">The station identifier.</param>
        /// <returns></returns>
        public async Task<IEnumerable<Comment>> GetAllByStationIdAsync(Guid stationId) {
            return await _collection.Find(comment => comment.StationId == stationId).ToListAsync();
        }
    }
}
