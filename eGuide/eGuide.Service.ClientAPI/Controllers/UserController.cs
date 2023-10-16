using AutoMapper;
using eGuide.Business.Interface;
using eGuide.Data.Dto.InComing.CreationDto.Client;
using eGuide.Data.Dto.InComing.UpdateDto.Client;
using eGuide.Data.Dto.OutComing.Client;
using eGuide.Data.Entites.Authorization;
using eGuide.Data.Entities.Client;
using MailKit.Net.Smtp;
using MailKit.Security;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using MimeKit;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace eGuide.Service.ClientAPI.Controllers {
    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="eGuide.Service.ClientAPI.Controllers.GenericController&lt;eGuide.Data.Entities.Client.User&gt;" />
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

        /// <summary>
        /// Sends the email.
        /// </summary>
        /// <param name="body">The body.</param>
        /// <param name="recipientEmail">The recipient email.</param>
        /// <returns></returns>
        [HttpPost("mail")]
        public IActionResult SendEmail(string body, string recipientEmail)
        {
            var email = new MimeMessage();
            email.From.Add(MailboxAddress.Parse("crntrim@gmail.com"));
            email.To.Add(MailboxAddress.Parse(recipientEmail));

            email.Subject = "Email Confirmation";
            email.Body = new TextPart(MimeKit.Text.TextFormat.Html) { Text = body };

            using var smtp = new SmtpClient();
            smtp.Connect("smtp.gmail.com", 587, SecureSocketOptions.StartTls);
            smtp.Authenticate("crntrim@gmail.com", "yzlijnhvqjrbipwl");

            smtp.Send(email);

            smtp.Disconnect(true);

            return Ok();

        }

        /// <summary>
        /// Registers the specified register.
        /// </summary>
        /// <param name="register">The register.</param>
        /// <returns></returns>
        [HttpPost("register")]
        public async Task<ActionResult<User>> Register(CreationDtoForUser register)
        {
            if (register.Password != register.ConfirmPassword)
            {
                return BadRequest("Şifreler eşleşmiyor.");
            }

            byte[] passwordHash, passwordSalt;
            CreatePasswordHash(register.Password, out passwordHash, out passwordSalt);

            var user = new User
            {
                Surname = register.Surname,
                Name = register.Name,
                Email = register.Email,
                PassWordHash = passwordHash,
                PassWordSalt = passwordSalt,
                ConfirmationToken = CreateRandomToken()

            };

            await _business.AddAsync(user);
          
            string confirmationLink = Url.Action("ConfirmAccount", "User", new { token = user.ConfirmationToken }, Request.Scheme);
            string confirmationEmailBody = $"Hesabınızı onaylamak için lütfen şu bağlantıya tıklayın: {confirmationLink}";
            SendEmail(confirmationEmailBody, user.Email);

            return Ok(user);
        }

        /// <summary>
        /// Confirms the account.
        /// </summary>
        /// <param name="token">The token.</param>
        /// <returns></returns>
        [HttpGet("confirm")]
        public async Task<IActionResult> ConfirmAccount(string token)
        {
            var user = await _business.FirstOrDefault(u => u.ConfirmationToken == token);

            if (user == null)
            {
                return BadRequest("Invalid confirmation code.");
            }
          
            user.Status = 1;
            await _business.UpdateAsync(user);

            return Ok("Your account has been successfully approved.");
        }


        /// <summary>
        /// Creates the password hash.
        /// </summary>
        /// <param name="password">The password.</param>
        /// <param name="passwordHash">The password hash.</param>
        /// <param name="passwordSalt">The password salt.</param>
        private void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using (var hmac = new HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
            }
        }

        /// <summary>
        /// Logins the specified login.
        /// </summary>
        /// <param name="login">The login.</param>
        /// <returns></returns>
        [HttpPost("login")]
        public async Task<IActionResult> Login(Login login)
        {
            var entity = _business.Where(x => x.Email == login.Email).FirstOrDefault();

            if (entity == null)
            {
                return Ok("wrong email");
            }

            if (!VerifyPasswordHash(login.Password, entity.PassWordHash, entity.PassWordSalt))
            {
                return Ok("wrong password");
            }
            if(entity.Status==1)
            {
                return Ok(entity.Id);
            }
            else
            {
                return Ok("verify your email");
            }
        }

        /// <summary>
        /// Createds the token.
        /// </summary>
        /// <param name="user">The user.</param>
        /// <returns></returns>
        private string CreatedToken(User user)
        {
            List<Claim> claims = new List<Claim> {
                new Claim(ClaimTypes.Name, user.Name)};

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("super secret key"));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

            var token = new JwtSecurityToken(
            claims: claims,
            expires: DateTime.Now.AddDays(1),
            signingCredentials: creds
            );

            var jwt = new JwtSecurityTokenHandler().WriteToken(token);
            return jwt;
        }

        /// <summary>
        /// Verifies the password hash.
        /// </summary>
        /// <param name="password">The password.</param>
        /// <param name="passwordHash">The password hash.</param>
        /// <param name="passwordSalt">The password salt.</param>
        /// <returns></returns>
        private bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt)
        {
            using (var hmac = new HMACSHA512(passwordSalt))
            {
                var computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
                return computedHash.SequenceEqual(passwordHash);
            }
        }

        /// <summary>
        /// Forgots the password.
        /// </summary>
        /// <param name="email">The email.</param>
        /// <returns></returns>
        [HttpPost("forgot-password")]
        public async Task<IActionResult> ForgotPassword(Guid userId)
        {
            var user = await _business.FirstOrDefault(u => u.Id == userId);

            if (user == null)
            {
                return BadRequest("UserNotFound");
            }

            user.PasswordResetToken = CreateRandomToken();
            user.ResetTokenExpires = DateTime.Now.AddDays(1);
            await _business.UpdateAsync(user);

            return Ok("You may now reset your password");
        }

        /// <summary>
        /// Creates the random token.
        /// </summary>
        /// <returns></returns>
        private string CreateRandomToken()
        {
            
            Random random = new Random();
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            return new string(Enumerable.Repeat(chars, 6)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }

        /// <summary>
        /// Resets the password.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns></returns>
        [HttpPost("reset-password")]
        public async Task<IActionResult> ResetPassword(ResetPassword request,Guid userId)
        {
            var user = await _business.FirstOrDefault(u => u.PasswordResetToken != null && u.Id==userId);

            if (user == null)
            {
                return BadRequest("Invalid Token");
            }

            
            if (user.ResetTokenExpires.HasValue && user.ResetTokenExpires < DateTime.Now)
            {
                return BadRequest("Token Expired");
            }

            CreatePasswordHash(request.Password, out byte[] passwordHash, out byte[] passwordSalt);

            user.PassWordHash = passwordHash;
            user.PassWordSalt = passwordSalt;
            user.PasswordResetToken = null;
            user.ResetTokenExpires = null;

            await _business.UpdateAsync(user);

            return Ok("password succesfully changed");

        }

    }
}