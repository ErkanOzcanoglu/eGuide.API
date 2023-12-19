using eGuide.Data.Dto.Logger;
using eGuide.Infrastructure.Interface;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eGuide.Infrastructure.Conctrete {

    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="eGuide.Infrastructure.Interface.ILogRepository" />
    public class LogRepository : ILogRepository {

        /// <summary>
        /// The collection
        /// </summary>
        private readonly IMongoCollection<UserLogs> _collection;

        /// <summary>
        /// Initializes a new instance of the <see cref="LogRepository"/> class.
        /// </summary>
        /// <param name="mongoContext">The mongo context.</param>
        public LogRepository(IMongoDatabase mongoContext) {
            _collection = mongoContext.GetCollection<UserLogs>("Users");
        }

        /// <summary>
        /// Creates the users log.
        /// </summary>
        /// <param name="comment">The comment.</param>
        /// <returns></returns>
        public async Task<UserLogs> CreateUsersLog(UserLogs comment) {
            comment.Id = Guid.NewGuid();
            comment.CreatedTime = DateTime.Now;
            await _collection.InsertOneAsync(comment);
            return comment;
        }

        /// <summary>
        /// Gets all asynchronous log.
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<UserLogs>> GetAllAsyncLog() {
            return await _collection.Find(x => true).ToListAsync();
        }

        public async Task<IEnumerable<UserLogs>> GetErrorLogs() {
            return await _collection.Find(x => x.Level == "error").ToListAsync();
        }

        public async Task<IEnumerable<UserLogs>> GetInfoLogs() {
            return await _collection.Find(x => x.Level == "info").ToListAsync();
        }
    }
}
