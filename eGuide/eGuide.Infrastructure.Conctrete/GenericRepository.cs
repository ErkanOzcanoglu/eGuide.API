

using AutoMapper;
using eGuide.Data.Context.Context;
using eGuide.Data.Entities;
using eGuide.Infrastructure.Interface;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace eGuide.Infrastructure.Concrete
{

    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <seealso cref="eGuide.Infrastructure.Interface.IGenericRepository&lt;T&gt;" />
    public class GenericRepository<T, TDto, TUpdate, TCreate> : IGenericRepository<T, TDto, TUpdate, TCreate> where T : BaseModel
    {
        /// <summary>The context</summary>
        protected readonly eGuideContext _context;

        /// <summary>
        /// The database set
        /// </summary>
        private readonly DbSet<T> _dbSet;

        private readonly IMapper _mapper;

        /// <summary>
        /// Initializes a new instance of the <see cref="GenericRepository{T}"/> class.
        /// </summary>
        /// <param name="context">The context.</param>
        public GenericRepository(eGuideContext context, IMapper mapper)
        {
            _context = context;
            _dbSet = _context.Set<T>();
            _mapper = mapper;
        }

        /// <summary>
        /// Adds the specified entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        public async Task Add(TCreate entity)
        {
            await _dbSet.AddAsync(_mapper.Map<T>(entity));
        }

        /// <summary>
        /// Gets all.
        /// </summary>
        /// <returns></returns>
        public IQueryable<T> GetAll()
        {
            return _dbSet.Where(x => x.Status == 1);
        }

        /// <summary>
        /// Getbies the identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        public async Task<T> GetbyId(Guid id)
        {
            var entity = await _dbSet.FindAsync(id);
            if (entity.Status == 1) {
                return entity;
            }
            else {
                return null;
            }
        }

        /// <summary>
        /// Removes the specified entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        public async void Remove(Guid id)
        {
            var entity = _dbSet.Find(id);
            entity.Status = 0;
        }

        /// <summary>
        /// Updates the specified entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        public void Update(T entity)
        {
             _dbSet.Update(entity);
        }

        /// <summary>
        /// Wheres the specified expression.
        /// </summary>
        /// <param name="expression">The expression.</param>
        /// <returns></returns>
        public IQueryable<T> Where(Expression<Func<T, bool>> expression)
        {
            return _dbSet.Where(expression);
        }
    }
}
