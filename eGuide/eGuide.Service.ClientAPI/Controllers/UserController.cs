using AutoMapper;
using eGuide.Business.Interface;
using eGuide.Data.Dto.InComing.CreationDto.Client;
using eGuide.Data.Dto.OutComing.Client;
using eGuide.Data.Entites.Authorization;
using eGuide.Data.Entities.Client;
using MailKit.Net.Smtp;
using MailKit.Security;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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
        private readonly IUserBusiness _business;

        private readonly IMapper _mapper;

        public UserController(IUserBusiness business, IMapper mapper)
        {

            _business = business;
            _mapper = mapper;
        }
        
        [HttpGet]
        public async Task<List<UserDto>> All()
        {
            var user = await _business.GetAllAsync();
            var userdto = _mapper.Map<List<UserDto>>(user.ToList());
            return userdto;
        }
      
        [HttpGet("getbyId")]
        public async Task<UserDto> GetById(Guid id)
        {
            var user = await _business.GetbyIdAsync(id);
            var userdto = _mapper.Map<UserDto>(user);
            return userdto;
        }

        [HttpPost]
        public async Task Create(CreationDtoForUser entity)
        {
            await _business.AddAsync(_mapper.Map<User>(entity));
        }

        [HttpDelete]
        public async Task Delete(Guid id)
        {
            _business.RemoveAsync(id);
        }


        [HttpPut]
        public async Task Update(User entity)
        {
            await _business.UpdateAsync(entity);
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

        //[HttpPost("register")]
        //public async Task<ActionResult<User>> Register(CreationDtoForUser register)
        //{
        //    byte[] passwordHash, passwordSalt;
        //    CreatePasswordHash(register.Password, out passwordHash, out passwordSalt);

        //    var user = new User
        //    {
        //        Id = register.Id,
        //        Surname = register.Surname,
        //        Name = register.Name,
        //        Email = register.Email,
        //        PassWordHash = passwordHash,
        //        PassWordSalt = passwordSalt
        //    };

        //    await _business.AddAsync(user);
        //    return Ok(user);
        //}

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
                PassWordSalt = passwordSalt
                
            };

            await _business.AddAsync(user);
            return Ok(user);
        }

        private void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using (var hmac = new HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
            }
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(Login login)
        {

            var entity = _business.Where(x => x.Name == login.Username).FirstOrDefault();

            if (entity == null)
            {
                return Ok("wrong username");
            }

            if (!VerifyPasswordHash(login.Password, entity.PassWordHash, entity.PassWordSalt))
            {
                return Ok("wrong password");
            }
            //return CreatedToken(entity);
            return Ok(entity.Id);
        }

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

        private bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt)
        {
            using (var hmac = new HMACSHA512(passwordSalt))
            {
                var computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
                return computedHash.SequenceEqual(passwordHash);
            }
        }

    }
}