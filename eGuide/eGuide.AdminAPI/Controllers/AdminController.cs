using AutoMapper;
using eGuide.Business.Interface;
using eGuide.Common.Mappers;
using eGuide.Data.Dto.InComing.CreationDto.Admin;
using eGuide.Data.Dto.InComing.UpdateDto.Admin;
using eGuide.Data.Dto.OutComing.Admin;
using eGuide.Data.Entites.Authorization;
using eGuide.Data.Entities.Admin;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using MimeKit;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using MailKit.Net.Smtp;
using MailKit.Security;

namespace eGuide.Service.AdminAPI.Controllers {
    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="eGuide.Service.AdminAPI.Controllers.GenericController&lt;eGuide.Data.Entities.Admin.AdminProfile, eGuide.Data.Dto.OutComing.Admin.AdminProfileDto, eGuide.Data.Dto.InComing.UpdateDto.Admin.UpdateDtoForAdmin, eGuide.Data.Dto.InComing.CreationDto.Admin.CreationDtoForAdminProfile&gt;" />
    [Route("api/[controller]")]
    [ApiController]

    public class AdminController : ControllerBase
    {

        /// <summary>
        /// The business
        /// </summary>
        private readonly IAdminProfileBusiness _business;

        private readonly IMapper _mapper;


        /// <summary>
        /// Initializes a new instance of the <see cref="AdminController"/> class.
        /// </summary>
        /// <param name="business">The business.</param>
        public AdminController(IAdminProfileBusiness business, IMapper mapper)
        {

            _business = business;
            _mapper = mapper;
        }


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

                var userDto = _mapper.Map<List<AdminProfileDto>>(users.ToList());

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

                
                return Ok(user);
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

        [HttpPut("{userId}")]
        public async Task<IActionResult> UpdateUser(Guid userId, [FromBody] UpdateDtoForAdmin userDto)
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

                await _business.UpdateAsync(_mapper.Map<AdminProfile>(existingUser));

                return Ok(existingUser);
            }

            catch (Exception ex)
            {
                return BadRequest($"Error: {ex.Message}");
            }
        }

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

        [HttpPost("registerAdmin")]
        public async Task<ActionResult<AdminProfile>> RegisterAdmin(CreationDtoForAdminProfile register)
        {
            if (register.Password != register.ConfirmPassword)
            {
                return BadRequest("Şifreler eşleşmiyor.");
            }

            byte[] passwordHash, passwordSalt;
            CreatePasswordHash(register.Password, out passwordHash, out passwordSalt);

            var user = new AdminProfile
            {
                Surname = register.Surname,
                Name = register.Name,
                Email = register.Email,
                PassWordHash = passwordHash,
                PassWordSalt = passwordSalt,
                ConfirmationToken = CreatedToken(register),
                CreatedDate = DateTime.Now

            };

            user.Status = 1;

            await _business.AddAsync(user);

            string confirmationLink = $"http://localhost:4200/verify-email/{user.ConfirmationToken}";
            string confirmationEmailBody = $"Hesabınızı onaylamak için lütfen şu bağlantıya tıklayın: {confirmationLink}";
            SendEmail(confirmationEmailBody, user.Email);

            return Ok(user);
        }


        [HttpGet("confirm")]
        public async Task<IActionResult> ConfirmAccount(string token)
        {
            var user = await _business.FirstOrDefault(u => u.ConfirmationToken == token);

            if (user == null)
            {
                return BadRequest("Invalid confirmation code.");
            }

            user.VerifiedAt = DateTime.Now;
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
            if (entity.Status == 1)
            {
                return Ok(entity);
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
        private string CreatedToken(CreationDtoForAdminProfile user)
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

        [HttpPost("forgot-password")]
        public async Task<IActionResult> ForgotPassword(Guid userId)
        {
            var user = await _business.FirstOrDefault(u => u.Id == userId);

            if (user == null)
            {
                return BadRequest("UserNotFound");
            }

            var userMap = _mapper.Map<CreationDtoForAdminProfile>(user);

            user.PasswordResetToken = CreatedToken(userMap);
            user.ResetTokenExpires = DateTime.Now.AddDays(1);
            await _business.UpdateAsync(user);

            return Ok("You may now reset your password");
        }

      
        [HttpPost("reset-password")]
        public async Task<IActionResult> ResetPassword(ResetPassword request, Guid userId)
        {
            var user = await _business.FirstOrDefault(u => u.PasswordResetToken != null && u.Id == userId);

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

       
        [HttpPost("forgot-password/{userEmail}")]
        public async Task<IActionResult> ForgotPasswordScreen(string userEmail)
        {
            var user = await _business.FirstOrDefault(u => u.Email == userEmail);

            if (user == null)
            {
                return BadRequest("UserNotFound");
            }

            var userMap = _mapper.Map<CreationDtoForAdminProfile>(user);

            user.PasswordResetToken = CreatedToken(userMap);
            user.ResetTokenExpires = DateTime.Now.AddDays(1);
            await _business.UpdateAsync(user);

            string confirmationLink = $"http://localhost:4200/forgot-admin-password/{user.PasswordResetToken}";
            string confirmationEmailBody = $"Hesabınızı şifrenizi sıfırlamak için lütfen şu bağlantıya tıklayın: {confirmationLink}";
            string recipientEmail = user.Email;

            SendEmail(confirmationEmailBody, recipientEmail);

            return Ok("You may now reset your password");

        }

        /// <summary>
        /// Resets the password screen.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <param name="token">The token.</param>
        /// <returns></returns>
        [HttpPost("reset-password-screen")]
        public async Task<IActionResult> ResetPasswordScreen(ResetPassword request, string token)
        {
            var user = await _business.FirstOrDefault(u => u.PasswordResetToken != null && u.PasswordResetToken == token);

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

            return Ok("Password successfully changed");
        }
    }
}
