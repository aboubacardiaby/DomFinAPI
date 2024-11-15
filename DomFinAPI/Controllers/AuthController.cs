using System.Text;
using DomFinAPI.Models;
using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.AspNetCore.Authorization;

namespace DomFinAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private IConfiguration _config;

        public AuthController(IConfiguration config)
        {
            _config = config;
        }

        // POST: api/Auth/Login
        [AllowAnonymous]
        [HttpPost("Login")]
        public IActionResult Login([FromBody] LoginModel login)
        {
            var user = AuthenticateUser(login);

            if (user != null)
            {
                var tokenString = GenerateJWT(user);
                return Ok(new { token = tokenString });
            }

            return Unauthorized();
        }

        private UserModel AuthenticateUser(LoginModel login)
        {
            // Validate the user credentials
            // This should check against a user store
            if (login.Username == "testuser" && login.Password == "password")
            {
                return new UserModel { Username = "testuser", Role = "Administrator" };
            }
            return null;
        }

        private string GenerateJWT(UserModel userInfo)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new[]
            {
                new Claim(ClaimTypes.Name, userInfo.Username),
                new Claim(ClaimTypes.Role, userInfo.Role)
            };

            var token = new JwtSecurityToken(_config["Jwt:Issuer"],
              _config["Jwt:Audience"],
              claims,
              expires: DateTime.Now.AddMinutes(120),
              signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}

