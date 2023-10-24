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
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace eGuide.Service.AdminAPI.Controllers {
    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="eGuide.Service.AdminAPI.Controllers.GenericController&lt;eGuide.Data.Entities.Admin.AdminProfile, eGuide.Data.Dto.OutComing.Admin.AdminProfileDto, eGuide.Data.Dto.InComing.UpdateDto.Admin.UpdateDtoForAdmin, eGuide.Data.Dto.InComing.CreationDto.Admin.CreationDtoForAdminProfile&gt;" />
    [Route("api/[controller]")]
    [ApiController]
    
    public class AdminController : ControllerBase {

        /// <summary>
        /// The business
        /// </summary>
        private readonly IAdminAuthorizationBusiness _business;

        private readonly IMapper _mapper;


        /// <summary>
        /// Initializes a new instance of the <see cref="AdminController"/> class.
        /// </summary>
        /// <param name="business">The business.</param>
        public AdminController(IAdminAuthorizationBusiness business , IMapper mapper) {

            _business = business;
            _mapper = mapper;
        }


        [HttpPost("register")]
        public async Task<ActionResult<AdminProfile>> Register(CreationDtoForAdminProfile register)
        {
            byte[] passwordHash, passwordSalt;
            CreatePasswordHash(register.Password, out passwordHash, out passwordSalt);

            var user = new AdminProfile
            {
                Id = register.Id,
                Surname = register.Surname,
                Name = register.Name,
                Username=register.Username,
                Email = register.Email,
                PassWordHash = passwordHash,
                PassWordSalt = passwordSalt
            };

            await _business.Register(user);
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

            var entity = _business.Where(x => x.Email == login.Email).FirstOrDefault();

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

        private string CreatedToken(AdminProfile user)
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

        //[HttpPost("forgot-password")]
        //public async Task<ActionResult<AdminProfile>> ForgotPassword(string email)
        //{
        //    var user = await _dbSet.FirstOrDefaultAsync(x => x.Mail == email);
        //    if (user == null)
        //    {
        //        return BadRequest("User not found.");
        //    }

        //    user.PasswordResetToken = CreateRandomToken();
        //    user.PasswordResetTokenExpiresAt = DateTime.Now.AddDays(1);
        //    await _context.SaveChangesAsync();

        //    return Ok("You may now reset your passwords");

        //}


    }
}
