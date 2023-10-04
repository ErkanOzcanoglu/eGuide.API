using AutoMapper;
using eGuide.Data.Context.Context;
using eGuide.Data.Entities;
using eGuide.Data.Entities.Admin;
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
    public class AdminAuthorizationRepository : GenericRepository<AdminProfile>, IAdminAuthorizationRepository
    {
        /// <summary>The context</summary>
        protected readonly eGuideContext _context;

        /// <summary>
        /// The database set
        /// </summary>
        private readonly DbSet<AdminProfile> _dbSet;

        public AdminAuthorizationRepository(eGuideContext context) : base(context)
        {
            _context = context;
            _dbSet = _context.Set<AdminProfile>();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="GenericRepository{T}"/> class.
        /// </summary>
        /// <param name="context">The context.</param>



        public async Task Register(AdminProfile entity)
        {
            await _dbSet.AddAsync(entity);
        }
    }
}
