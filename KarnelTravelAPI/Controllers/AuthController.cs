using KarnelTravelAPI.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using TOKENDEMO.Models;

namespace KarnelTravelAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly DatabaseContext _databaseContext;
        private readonly IConfiguration configuration;
        public AuthController(DatabaseContext databaseContext, IConfiguration configuration)
        {
            _databaseContext = databaseContext;
            this.configuration = configuration;
        }

        [HttpPost]
        [AllowAnonymous]
        public ActionResult Login(UserLogin userLogin)
        {
            var user = Authenticate(userLogin);

            if (user != null)
            {
                var token = GenerateToken(user);
                var userToken = new UserModel
                {
                    Email = user.Email,
                    User_name = user.User_name,
                    Role = user.Role

                };
                return Ok(new { token, userToken });
            }

            return NotFound("user not found");
        }

        private UserModel Authenticate(UserLogin userLogin) 
        {
            var listUser = _databaseContext.Users.ToList();
            if (listUser != null && listUser.Count > 0)
            {
                var currentUser = listUser.FirstOrDefault(u => u.Email.ToLower() == userLogin.Email && u.Password == userLogin.Password);
                return currentUser;
            }
            return null;
        }

        private string GenerateToken(UserModel user)
        {
            var securityKey = new SymmetricSecurityKey
                (Encoding.UTF8.GetBytes(configuration["Jwt:Key"]));
            var credentials = new SigningCredentials
                (securityKey, SecurityAlgorithms.HmacSha256);
            var claims = new[]
            {
                new Claim("Username",user.User_name),
                new Claim("Email",user.Email),
                new Claim(ClaimTypes.Role,user.Role)
            };
            var token = new JwtSecurityToken(configuration["Jwt:Issuer"],
                configuration["Jwt:Audience"],
                claims,
                expires: DateTime.Now.AddMinutes(15),
                signingCredentials: credentials);


            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
