using eGuide.Business.Interface;
using eGuide.Data.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace eGuide.Service.AdminAPI.Controllers {
    [Route("api/[controller]")]
    [ApiController]
    public class GenericController<T, TDto, TUpdate, TCreate> : ControllerBase where T : BaseModel {

        /// <summary>
        /// The business
        /// </summary>
        private readonly IBusiness<T, TDto, TUpdate, TCreate> _business;

        /// <summary>
        /// Initializes a new instance of the <see cref="GenericController{T}"/> class.
        /// </summary>
        /// <param name="business">The business.</param>
        public GenericController(IBusiness<T, TDto, TUpdate, TCreate> business) 
        {
            _business = business;
        }

        /// <summary>
        /// Alls this instance.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<List<T>> All() {
            var adminInf = await _business.GetAllAsync();
            return adminInf.ToList();
        }

        /// <summary>
        /// Gets the by identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        [HttpGet("getbyId")]
        public async Task<T> GetById(Guid id)
        {
            var admin = await _business.GetbyIdAsync(id);
            return admin;
        }

        /// <summary>
        /// Creates the specified entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        [HttpPost]
        public async Task Create(TCreate entity) {
            await _business.AddAsync(entity);
        }

        /// <summary>
        /// Updates the specified entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        [HttpPut]
        public async Task Update(T entity) {
            await _business.UpdateAsync(entity);
        }

        /// <summary>
        /// Deletes the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        [HttpDelete]
        public async Task Delete(Guid id) {
            _business.RemoveAsync(id);
        }
    }
}
