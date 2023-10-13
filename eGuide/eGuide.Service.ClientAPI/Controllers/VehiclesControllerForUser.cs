using AutoMapper;
using eGuide.Business.Interface;
using eGuide.Data.Dto.InComing.CreationDto.Client;
using eGuide.Data.Dto.InComing.UpdateDto.Client;
using eGuide.Data.Dto.OutComing.Client;
using eGuide.Data.Entities.Client;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace eGuide.Service.ClientAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VehiclesControllerForUser : ControllerBase
    {
        /// <summary>
        /// The business
        /// </summary>
        private readonly IVehicleBusiness _business;

        /// <summary>
        /// The mapper
        /// </summary>
        private readonly IMapper _mapper;

        /// <summary>
        /// Initializes a new instance of the <see cref="VehicleController"/> class.
        /// </summary>
        /// <param name="business">The business.</param>
        /// <param name="mapper">The mapper.</param>
        public VehiclesControllerForUser(IVehicleBusiness business, IMapper mapper)
        {
            _business = business;
            _mapper = mapper;
        }

        /// <summary>
        /// Alls this instance.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult<VehicleDto>> All()
        {
            try
            {
                var vehicles = await _business.GetAllAsync();

                if (vehicles == null || !vehicles.Any())
                {
                    return NotFound("There are no vehicles in the database or the database is empty.");
                }

                var vehicledto = _mapper.Map<List<VehicleDto>>(vehicles.ToList());

                return Ok(vehicledto);
            }
            catch (DbUpdateException ex)
            {
                return BadRequest("An error occurred while accessing the database. Please try again later.");
            }
            catch (Exception ex)
            {
                return BadRequest($"Hata: {ex.Message}");
            }
        }

        [HttpGet("brands")]
        public async Task<ActionResult<IEnumerable<string>>> GetAllBrands()
        {
            try
            {
                var brands = await _business.GetAllBrandsAsync();

                if (brands == null || !brands.Any())
                {
                    return NotFound("There are no brands in the database.");
                }

                return Ok(brands);
            }
            catch (DbUpdateException ex)
            {
                return BadRequest("An error occurred while accessing the database. Please try again later.");
            }
            catch (Exception ex)
            {
                return BadRequest($"Hata: {ex.Message}");
            }
        }

        /// <summary>
        /// Creates the specified entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        [HttpPost]
        public async Task<IActionResult> Create(CreationDtoForVehicle entity)
        {

            await _business.AddAsync(_mapper.Map<Vehicle>(entity));
            return Ok();

        }

        /// <summary>
        /// Deletes the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            try
            {
                await _business.RemoveAsync(id);

                return Ok();
            }
            catch (DbUpdateException ex)
            {
                return BadRequest("An error occurred while accessing the database. Please try again later.");
            }
            catch (Exception ex)
            {
                return BadRequest($"Hata: {ex.Message}");
            }

        }

        /// <summary>
        /// Updates the vehicle.
        /// </summary>
        /// <param name="vehicleId">The vehicle identifier.</param>
        /// <param name="vehicleDto">The vehicle dto.</param>
        /// <returns></returns>
        [HttpPut("{vehicleId}")]
        public async Task<IActionResult> UpdateVehicle(Guid vehicleId, [FromBody] UpdateDtoForVehicle vehicleDto)
        {
            try
            {
                var existingVehicle = await _business.GetbyIdAsync(vehicleId);

                if (existingVehicle == null)
                {
                    return NotFound($"Vehicle with ID {vehicleId} not found.");
                }

                existingVehicle.Brand = vehicleDto.Brand;
                existingVehicle.Model = vehicleDto.Model;

                await _business.UpdateAsync(_mapper.Map<Vehicle>(existingVehicle));

                return Ok(existingVehicle);
            }
            catch (DbUpdateException ex)
            {
                return BadRequest("An error occurred while accessing the database. Please try again later.");
            }
            catch (Exception ex)
            {
                return BadRequest($"Hata: {ex.Message}");
            }
        }

        /// <summary>
        /// Gets the models by brand.
        /// </summary>
        /// <param name="brand">The brand.</param>
        /// <returns></returns>
        [HttpGet("models/{brand}")]
        public async Task<ActionResult<List<string>>> GetModelsByBrand(string brand)
        {
            try
            {
                var models = await _business.GetModelsByBrandAsync(brand);

                if (models == null || !models.Any())
                {
                    return NotFound("No models found for the specified brand.");
                }

                return Ok(models);
            }
            catch (DbUpdateException ex)
            {
                return BadRequest("An error occurred while accessing the database. Please try again later.");
            }
            catch (Exception ex)
            {
                return BadRequest($"Error: {ex.Message}");
            }
        }

        /// <summary>
        /// Gets the primary key by brand and model.
        /// </summary>
        /// <param name="brand">The brand.</param>
        /// <param name="model">The model.</param>
        /// <returns></returns>
        [HttpGet("primarykey/{brand}/{model}")]
        public async Task<ActionResult<Guid>> GetPrimaryKeyByBrandAndModel(string brand, string model)
        {
            try
            {
                var primaryKey = await _business.GetPrimaryKeyByBrandAndModelAsync(brand, model);

                if (primaryKey == null)
                {
                    return NotFound("No vehicle found for the specified brand and model.");
                }

                return Ok(primaryKey);
            }
            catch (DbUpdateException ex)
            {
                return BadRequest("An error occurred while accessing the database. Please try again later.");
            }
            catch (Exception ex)
            {
                return BadRequest($"Error: {ex.Message}");
            }
        }

    }
}

