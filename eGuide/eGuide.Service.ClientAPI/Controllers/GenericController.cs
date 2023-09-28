using eGuide.Business.Interface;
using eGuide.Data.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace eGuide.Service.ClientAPI.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <seealso cref="Microsoft.AspNetCore.Mvc.ControllerBase" />
    [Route("api/[controller]")]
    [ApiController]
    public class GenericController<T> : ControllerBase where T : BaseModel
    {
        /// <summary>
        /// The service
        /// </summary>
        private readonly IBusiness<T> _service;

        /// <summary>
        /// Initializes a new instance of the <see cref="GenericController{T}"/> class.
        /// </summary>
        /// <param name="business">The business.</param>
        public GenericController(IBusiness<T> business)
        {
            _service = business;
        }

        /// <summary>
        /// Alls this instance.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<List<T>> All()
        {
            var personInf = await _service.GetAllAsync();

            return personInf.ToList();
        }

        /// <summary>
        /// Gets the by identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        [HttpGet("getbyId")]
        public async Task<T> GetById(Guid id) //returns only 1 company information
        {
            var person = await _service.GetbyIdAsync(id);

            return person;
        }
    }
}

