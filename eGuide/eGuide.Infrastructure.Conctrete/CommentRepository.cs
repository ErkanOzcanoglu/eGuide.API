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
        private readonly IMongoCollection<Comment> _collection;

        public CommentRepository(IMongoDatabase context) {
            _collection = context.GetCollection<Comment>("Comments");
        }

        public async Task<Comment> AddAsync(Comment comment) {
            await _collection.InsertOneAsync(comment);
            return comment;
        }

        public async Task<IEnumerable<Comment>> GetAllAsync() {
            return await _collection.Find(_ => true).ToListAsync();
        }

        public async Task<IEnumerable<Comment>> GetAllByStationIdAsync(Guid stationId) {
            return await _collection.Find(comment => comment.StationId == stationId).ToListAsync();
        }
    }
}
