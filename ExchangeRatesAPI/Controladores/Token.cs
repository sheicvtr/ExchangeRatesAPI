using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace ExchangeRatesAPI.Controladores
{
    [ApiController]
    [Route("[controller]")]
    public class AuthController : ControllerBase
    {
        private static List<User> users = new List<User>
        {
            new User { Username = "usuario1", Password = "aA123456!" },
            new User { Username = "usuario2", Password = "bB123456!" }
        };

        [HttpPost("login")]
        public IActionResult Login([FromBody] UserLogin model)
        {
            var user = users.Find(u => u.Username == model.Username && u.Password == model.Password);
            if (user == null)
            {
                return Unauthorized(new { message = "Username or password is incorrect" });
            }

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes("ThisIsASecretKeyWith32Characters12345");
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[] { new Claim("id", user.Username) }),
                Expires = DateTime.UtcNow.AddHours(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            var tokenString = tokenHandler.WriteToken(token);

            return Ok(new { Token = tokenString });
        }
    }

    public class UserLogin
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }

    public class User
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }
}

