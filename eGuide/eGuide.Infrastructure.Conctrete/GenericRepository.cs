﻿

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
    public class GenericRepository<T> : IGenericRepository<T> where T : BaseModel
    {
        /// <summary>The context</summary>
        protected readonly eGuideContext _context;

        /// <summary>
        /// The database set
        /// </summary>
        private readonly DbSet<T> _dbSet;

        /// <summary>
        /// Initializes a new instance of the <see cref="GenericRepository{T}"/> class.
        /// </summary>
        /// <param name="context">The context.</param>
        public GenericRepository(eGuideContext context)
        {
            _context = context;
            _dbSet = _context.Set<T>();
           
        }

        /// <summary>
        /// Adds the specified entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        public async Task Add(T entity)
        {
            await _dbSet.AddAsync(entity);
        }

        public Task<T> FirstOrDefault(Expression<Func<T, bool>> predicate)
        {
            return _dbSet.FirstAsync(predicate);
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
                return entity;
            
        }

        /// <summary>
        /// Removes the specified entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        public async void Remove(Guid id)
        {
            var entity = _dbSet.Find(id);
            entity.DeletedDate= DateTime.Now;
            entity.Status = 0;
        }

        /// <summary>
        /// Updates the specified entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        public void Update(T entity)
        {
            entity.UpdatedDate = DateTime.Now;
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

        /// <summary>
        /// Hards the remove.
        /// </summary>
        /// <param name="id">The identifier.</param>
        public void HardRemove(Guid id) {
            var entity = _dbSet.Find(id);
            if(entity != null) {
                _dbSet.Remove(entity);
            }
        }
    }
}
