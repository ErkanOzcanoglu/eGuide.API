﻿using AutoMapper;
using eGuide.Business.Interface;
using eGuide.Data.Context.Context;
using eGuide.Data.Dto.InComing.CreationDto.Client;
using eGuide.Data.Dto.InComing.CreationDto.Message;
using eGuide.Data.Dto.InComing.UpdateDto.Client;
using eGuide.Data.Dto.Logger;
using eGuide.Data.Dto.OutComing.Client;
using eGuide.Data.Entites.Authorization;
using eGuide.Data.Entites.Client;
using eGuide.Data.Entities.Client;
using eGuide.Data.Entities.Hubs;
using eGuide.Data.Entities.Message;
using MailKit.Net.Smtp;
using MailKit.Security;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
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

        protected readonly eGuideContext _context;

        /// <summary>
        /// The mapper
        /// </summary>
        private readonly IMapper _mapper;

        private readonly IHubContext<BroadCastHub, IHubClient> _hubContext;

        /// <summary>
        /// Initializes a new instance of the <see cref="UserController"/> class.
        /// </summary>
        /// <param name="business">The business.</param>
        /// <param name="mapper">The mapper.</param>
        public UserController(IUserBusiness business, IMapper mapper, IHubContext<BroadCastHub, IHubClient> hubContext, eGuideContext context)
        {
            _business = business;
            _mapper = mapper;
            _hubContext=hubContext;
            _context=context;
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
            smtp.Authenticate("eguideacnt@gmail.com", "xcnbnfhndthxnosz");

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
        public async Task<ActionResult<User>> Register(CreationDtoForUser register) {
            if (register.Password != register.ConfirmPassword) {
                return BadRequest("Şifreler eşleşmiyor.");
            }

            byte[] passwordHash, passwordSalt;
            CreatePasswordHash(register.Password, out passwordHash, out passwordSalt);

            var user = new User {
                Surname = register.Surname,
                Name = register.Name,
                Email = register.Email,
                PassWordHash = passwordHash,
                PassWordSalt = passwordSalt,
                ConfirmationToken = CreatedToken(register),
                CreatedDate = DateTime.Now

            };

            user.Status = 0;

            await _business.AddAsync(user);

            string htmlTemplate = System.IO.File.ReadAllText(@"C:\Users\ozcan\Desktop\-_-\eGuide_Temp\emailTemplate_Register_eGuide.html");

            string confirmationLink = $"http://localhost:4201/verify-email/{user.ConfirmationToken}";

            string emailBody = htmlTemplate.Replace("{CONFIRMATION_LINK}", confirmationLink);

            SendEmail(emailBody, user.Email);

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
            if(entity.Status==1)
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
        private string CreatedToken(CreationDtoForUser  user)
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

            var userMap=_mapper.Map<CreationDtoForUser>(user);

            user.PasswordResetToken = CreatedToken(userMap);
            user.ResetTokenExpires = DateTime.Now.AddDays(1);
            await _business.UpdateAsync(user);

            return Ok("You may now reset your password");
        }

        /// <summary>
        /// Resets the password.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns></returns>
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

        /// <summary>
        /// Forgots the password screen.
        /// </summary>
        /// <param name="userEmail">The user email.</param>
        /// <returns></returns>
        [HttpPost("forgot-password/{userEmail}")]
        public async Task<IActionResult> ForgotPasswordScreen(string userEmail) {
            var user = await _business.FirstOrDefault(u => u.Email == userEmail);

            if (user == null) {
                return BadRequest("UserNotFound");
            }

            var userMap = _mapper.Map<CreationDtoForUser>(user);

            user.PasswordResetToken = CreatedToken(userMap);
            user.ResetTokenExpires = DateTime.Now.AddDays(1);
            await _business.UpdateAsync(user);

            string htmlTemplate = System.IO.File.ReadAllText(@"C:\Users\ozcan\Desktop\-_-\eGuide_Temp\emailTemplate_ForgotPassword_eGuide.html");

            string confirmationLink = $"http://localhost:4201/forgot-password/{user.PasswordResetToken}";
            string emailBody = htmlTemplate.Replace("{CONFIRMATION_LINK}", confirmationLink);
            string recipientEmail = user.Email;

            SendEmail(emailBody, recipientEmail);

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

        [HttpPost("broadcast")]
        public async Task<IActionResult> BroadcastMessage( CreationDtoForMessage messageDto)
        {
            try
            {
                var receiverIdString = messageDto.ReceiverId.ToString();
                var message = _mapper.Map<Messages>(messageDto);
                await _context.Messages.AddAsync(message);
                await _context.SaveChangesAsync();
                await _hubContext.Clients.User(receiverIdString).BroadcastMessage(message);
                return Ok(message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal Server Error: {ex.Message}");
            }
        }

        [HttpPost("test")]
        public async Task<IActionResult> Test(CreationDtoForMessage messageDto)
        {
            try
            {
               
                var message = _mapper.Map<Messages>(messageDto);
                await _context.Messages.AddAsync(message);
                await _context.SaveChangesAsync();

                return Ok(message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal Server Error: {ex.Message}");
            }
        }
    }
}