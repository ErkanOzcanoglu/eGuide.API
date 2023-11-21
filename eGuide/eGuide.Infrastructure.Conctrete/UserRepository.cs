using eGuide.Data.Context.Context;
using eGuide.Data.Dto.Logs;
using eGuide.Data.Entities.Client;
using eGuide.Infrastructure.Concrete;
using eGuide.Infrastructure.Interface;
using Microsoft.EntityFrameworkCore;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eGuide.Infrastructure.Conctrete
{
    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="eGuide.Infrastructure.Concrete.GenericRepository&lt;eGuide.Data.Entities.Client.User&gt;" />
    /// <seealso cref="eGuide.Infrastructure.Interface.IUserRepository" />
    public class UserRepository : GenericRepository<User> , IUserRepository
    {
        /// <summary>
        /// The context
        /// </summary>
        protected readonly eGuideContext _context;

        /// <summary>
        /// The collection
        /// </summary>
        private readonly IMongoCollection<UserLogs> _collection;

        /// <summary>
        /// Initializes a new instance of the <see cref="UserRepository"/> class.
        /// </summary>
        /// <param name="context">The context.</param>
        public UserRepository(eGuideContext context, IMongoDatabase mongoContext) : base(context)
        {
            _context = context;
            _collection = mongoContext.GetCollection<UserLogs>("Users");
        }

        public async Task<UserLogs> CreateUsersLog(UserLogs comment) {
            comment.Id = Guid.NewGuid();
            comment.CreatedTime = DateTime.Now;
            await _collection.InsertOneAsync(comment);
            return comment;
        }

        public async Task<IEnumerable<UserLogs>> GetAllAsyncLog() {
            return await _collection.Find(x => x.Level == "info").ToListAsync();
        }

    }
}
