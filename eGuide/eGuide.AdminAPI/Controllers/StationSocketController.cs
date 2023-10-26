using AutoMapper;
using eGuide.Business.Concrete;
using eGuide.Business.Interface;
using eGuide.Data.Context.Context;
using eGuide.Data.Dto.InComing.CreationDto.Station;
using eGuide.Data.Dto.InComing.UpdateDto.Station;
using eGuide.Data.Dto.OutComing.Station;
using eGuide.Data.Entites.Station;
using eGuide.Data.Entities.Station;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using MongoDB.Bson.IO;


namespace eGuide.Service.AdminAPI.Controllers {
    [Route("api/[controller]")]
    [ApiController]
    public class StationSocketController : ControllerBase {

        /// <summary>
        /// The station socket business
        /// </summary>
        private readonly IStationSocketBusiness _stationSocketBusiness;

        /// <summary>
        /// The mapper
        /// </summary>
        private readonly IMapper _mapper;

        /// <summary>
        /// The context
        /// </summary>
        private readonly eGuideContext _context;

        /// <summary>
        /// The database set
        /// </summary>
        private readonly DbSet<StationInformationDto> _dbSet;

        /// <summary>
        /// Initializes a new instance of the <see cref="StationSocketController"/> class.
        /// </summary>
        /// <param name="stationSocketBusiness">The station socket business.</param>
        /// <param name="mapper">The mapper.</param>
        public StationSocketController(IStationSocketBusiness stationSocketBusiness, IMapper mapper, eGuideContext context) {
            _stationSocketBusiness = stationSocketBusiness;
            _mapper = mapper;
            _context = context;
            _dbSet = _context.Set<StationInformationDto>();
        }

        /// <summary>
        /// Gets all.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetAll() {
            var stationSockets = await _stationSocketBusiness.GetAllAsync();
            return Ok(stationSockets);
        }

        /// <summary>
        /// Adds the station socket.
        /// </summary>
        /// <param name="stationSocket">The station socket.</param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> AddStationSocket(CreationDtoForStationSockets stationSocket) {
            var stationSocketEntity = _mapper.Map<StationSockets>(stationSocket);
            await _stationSocketBusiness.AddAsync(stationSocketEntity);
            return Ok();
        }

        /// <summary>
        /// Puts the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="stationSocket">The station socket.</param>
        /// <returns></returns>
        [HttpPut]
        public async Task<ActionResult> Put(Guid id, UpdateDtoForStationSocket stationSocket) {
            var entity = await _stationSocketBusiness.GetbyIdAsync(id);
            if (entity == null) {
                return NotFound();
            }
            entity.StationModelId = stationSocket.StationModelId;
            entity.SocketId = stationSocket.SocketId;

            var mappedEntity = _mapper.Map<StationSockets>(entity);

            await _stationSocketBusiness.UpdateAsync(mappedEntity);
            return Ok();
        }

        /// <summary>
        /// Deletes the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        [HttpDelete]
        public async Task<ActionResult> Delete(Guid id) {
            await _stationSocketBusiness.RemoveAsync(id);
            return Ok();
        }

        /// <summary>
        /// Gets the station information by station model identifier.
        /// </summary>
        /// <param name="stationModelId">The station model identifier.</param>
        /// <returns></returns>
        [HttpGet("{stationModelId}")]
        public async Task<IActionResult> GetStationInformationByStationModelId(Guid stationModelId) {
            try {
                var parameters = new SqlParameter[]
                {
                new SqlParameter("@stationModelId", stationModelId)
                };

                var stationInformation = await _dbSet.FromSqlRaw("EXEC GetStationInformationByStationModelId @stationModelId", parameters).ToListAsync();

                if (stationInformation == null || stationInformation.Count == 0) {
                    return NotFound();
                }

                return Ok(stationInformation);
            } catch (Exception ex) {
                return StatusCode(500, $"Internal server error: {ex}");
            }
        }

        [HttpGet("GetAllStationProfile")]
        public async Task<IActionResult> GetAllStationProfileInformation() {
            try {
                var stationInformation = await _dbSet.FromSqlRaw("EXEC [GetStationInformation]").ToListAsync();

                if (stationInformation == null) {
                    return NotFound();
                }

                var jsonString = JsonConvert.
                var parsedData = JsonConvert.DeserializeObject<List<StationInformationDto>>(jsonString);

                return Ok(parsedData);
            } catch (Exception ex) {
                return StatusCode(500, $"Internal server error: {ex}");
            }
        }

    } 
}
