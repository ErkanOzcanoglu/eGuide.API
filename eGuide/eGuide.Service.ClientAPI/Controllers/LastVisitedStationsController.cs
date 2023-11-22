using eGuide.Business.Interface;
using eGuide.Data.Dto.Logger;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace eGuide.Service.ClientAPI.Controllers {
    [Route("api/[controller]")]
    [ApiController]
    public class LastVisitedStationsController : ControllerBase {
        private readonly ILastVisitedStationsBusiness _business;

        public LastVisitedStationsController(ILastVisitedStationsBusiness business) {
            _business = business;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> Get(Guid id) {
            var result = await _business.GetLastVisitedStationsByUserId(id);
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Post(LastVisitedStations lvs) {
            _business.CreateUsersLog(lvs);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id) {
            var result = await _business.RemoveLastVisitedStation(id);
            return Ok(result);
        }
    }
}
