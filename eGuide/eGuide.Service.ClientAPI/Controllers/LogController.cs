using eGuide.Business.Interface;
using eGuide.Data.Dto.Logger;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace eGuide.Service.ClientAPI.Controllers {
    [Route("api/[controller]")]
    [ApiController]
    public class LogController : ControllerBase {

        /// <summary>
        /// The business
        /// </summary>
        private readonly ILogBusiness _business;

        /// <summary>
        /// Initializes a new instance of the <see cref="LogController"/> class.
        /// </summary>
        /// <param name="business">The business.</param>
        public LogController(ILogBusiness business) {
            _business = business;
        }

        /// <summary>
        /// Userses the log.
        /// </summary>
        /// <param name="user">The user.</param>
        /// <returns></returns>
        [HttpPost("users-log")]
        public async Task<IActionResult> UsersLog(UserLogs user) {
            await _business.CreateUsersLog(user);
            return Ok();
        }

        /// <summary>
        /// Gets the users log.
        /// </summary>
        /// <returns></returns>
        [HttpGet("get-users-log")]
        public async Task<IActionResult> GetUsersLog() {
            var usersLog = await _business.GetAllAsyncLog();
            return Ok(usersLog);
        }
    }
}
