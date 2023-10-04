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
    public class CommentRepository<T> : ICommentRepository<T> where T : class {
        private readonly IMongoCollection<T> _collection;

        public CommentRepository(IMongoDatabase context) {
            _collection = context.GetCollection<T>("Comments");
        }

        public async Task<T> AddAsync(T comment) {
            await _collection.InsertOneAsync(comment);
            return comment;
        }

        public async Task<IEnumerable<T>> GetAllAsync() {
            return await _collection.Find(_ => true).ToListAsync();
        }
    }
}
