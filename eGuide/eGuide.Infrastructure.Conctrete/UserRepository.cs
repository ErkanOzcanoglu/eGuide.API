using eGuide.Data.Context.Context;
using eGuide.Data.Entities.Client;
using eGuide.Infrastructure.Concrete;
using eGuide.Infrastructure.Interface;
using Microsoft.EntityFrameworkCore;
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
        /// The database set
        /// </summary>
        private readonly DbSet<User> _dbSet;

        /// <summary>
        /// Initializes a new instance of the <see cref="UserRepository"/> class.
        /// </summary>
        /// <param name="context">The context.</param>
        public UserRepository(eGuideContext context) : base(context)
        {
            _context = context;
            _dbSet = _context.Set<User>();
        }
    }
}
