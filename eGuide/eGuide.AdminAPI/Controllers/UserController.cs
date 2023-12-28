using AutoMapper;
using eGuide.Business.Interface;
using eGuide.Data.Dto.InComing.UpdateDto.Client;
using eGuide.Data.Dto.OutComing.Client;
using eGuide.Data.Entities.Client;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace eGuide.Service.AdminAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        /// <summary>
        /// The business
        /// </summary>
        private readonly IUserBusiness _business;

        /// <summary>
        /// The mapper
        /// </summary>
        private readonly IMapper _mapper;

        /// <summary>
        /// Initializes a new instance of the <see cref="UserController"/> class.
        /// </summary>
        /// <param name="business">The business.</param>
        /// <param name="mapper">The mapper.</param>
        public UserController(IUserBusiness business, IMapper mapper)
        {
            _business = business;
            _mapper = mapper;
        }

        /// <summary>
        /// Alls this instance.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> All()
        {
            try
            {
                var users = await _business.GetAllAsync();

                if (users == null || !users.Any())
                {
                    return NotFound("No users found in the database.");
                }

                var userDto = _mapper.Map<List<UserDto>>(users.ToList());

                return Ok(userDto);
            }
            catch (DbUpdateException ex)
            {
                return BadRequest("A database connection error occurred. Please try again later.");
            }
            catch (Exception ex)
            {
                return BadRequest($"Error: {ex.Message}");
            }
        }

        /// <summary>
        /// Gets the by identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        [HttpGet("getbyId")]
        public async Task<IActionResult> GetById(Guid id)
        {
            try
            {
                var user = await _business.GetbyIdAsync(id);

                if (user == null)
                {
                    return NotFound($"User with ID {id} not found.");
                }

                var userDto = _mapper.Map<UserDto>(user);

                return Ok(userDto);
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
        /// Deletes the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        [HttpDelete]
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
        /// Updates the specified entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        [HttpPut("{userId}")]
        public async Task<IActionResult> UpdateUser(Guid userId, [FromBody] UpdateDtoForUser userDto)
        {
            try
            {
                var existingUser = await _business.GetbyIdAsync(userId);

                if (existingUser == null)
                {
                    return NotFound($"User with ID {userId} not found.");
                }

                existingUser.Name = userDto.Name;
                existingUser.Surname = userDto.Surname;
                existingUser.Email = userDto.Email;

                await _business.UpdateAsync(_mapper.Map<User>(existingUser));

                return Ok(existingUser);
            }

            catch (Exception ex)
            {
                return BadRequest($"Error: {ex.Message}");
            }
        }
    }
}
