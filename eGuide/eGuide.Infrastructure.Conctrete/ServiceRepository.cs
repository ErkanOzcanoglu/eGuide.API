using eGuide.Data.Context.Context;
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
    public class ServiceRepository : GenericRepository<Services>, IServiceRepository
    {
        protected readonly eGuideContext _context;
        private readonly DbSet<Services> _dbSet;

        public ServiceRepository(eGuideContext context) : base(context)
        {
            _context = context;
            _dbSet = _context.Set<Services>();
        }
    }
}
