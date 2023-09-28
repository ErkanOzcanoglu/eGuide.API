using eGuide.Data.Context.Context;
using eGuide.Infrastructure.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eGuide.Infrastructure.Concrete
{
    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="eGuide.Infrastructure.Interface.IUnitOfWork" />
    public class UnitOfWork : IUnitOfWork
    {
        /// <summary>
        /// The context
        /// </summary>
        private readonly eGuideContext _context;

        /// <summary>
        /// Initializes a new instance of the <see cref="UnitOfWork"/> class.
        /// </summary>
        /// <param name="context">The context.</param>
        public UnitOfWork(eGuideContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Commits this instance.
        /// </summary>
        public void Commit()
        {
            _context.SaveChanges();
        }

        /// <summary>
        /// Commits the asynchronous.
        /// </summary>
        public async Task CommitAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
