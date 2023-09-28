using eGuide.Business.Interface;
using eGuide.Data.Entities.Client;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace eGuide.Service.ClientAPI.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="eGuide.Service.ClientAPI.Controllers.GenericController&lt;eGuide.Data.Entities.Client.User&gt;" />
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : GenericController<User>
    {

        /// <summary>
        /// The service
        /// </summary>
        private readonly IBusiness<User> _service;

        /// <summary>
        /// Initializes a new instance of the <see cref="UserController"/> class.
        /// </summary>
        /// <param name="business">The business.</param>
        public UserController(IBusiness<User> business) : base(business)
        {
            _service = business;
        }
    }
}

