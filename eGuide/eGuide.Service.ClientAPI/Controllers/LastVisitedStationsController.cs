using eGuide.Business.Interface;
using eGuide.Data.Dto.Logger;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace eGuide.Service.ClientAPI.Controllers {
    [Route("api/[controller]")]
    [ApiController]
    public class LastVisitedStationsController : ControllerBase {

        /// <summary>
        /// The business
        /// </summary>
        private readonly ILastVisitedStationsBusiness _business;

        /// <summary>
        /// Initializes a new instance of the <see cref="LastVisitedStationsController"/> class.
        /// </summary>
        /// <param name="business">The business.</param>
        public LastVisitedStationsController(ILastVisitedStationsBusiness business) {
            _business = business;
        }

        /// <summary>
        /// Gets the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<ActionResult> Get(Guid id) {
            var result = await _business.GetLastVisitedStationsByUserId(id);
            return Ok(result);
        }

        /// <summary>
        /// Posts the specified LVS.
        /// </summary>
        /// <param name="lvs">The LVS.</param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Post(LastVisitedStations lvs) {
            _business.CreateUsersLog(lvs);
            return Ok();
        }

        /// <summary>
        /// Deletes the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id) {
            var result = await _business.RemoveLastVisitedStation(id);
            return Ok(result);
        }
    }
}
