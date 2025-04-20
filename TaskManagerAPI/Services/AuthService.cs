using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using TaskManager.Api.Models;

namespace TaskManager.Api.Services
{
    public class AuthService : IAuthService
    {
        private readonly List<User> _users = new()
        {
            new User { Id = 1, Username = "admin", Password = "admin123", Role = "Admin" },
                new User { Id = 2, Username = "user1", Password = "user123", Role = "User" },
                new User { Id = 3, Username = "user2", Password = "user123", Role = "User" }
        };

        public string Authenticate(string username, string password)
        {
            var user = _users.SingleOrDefault(u => u.Username == username && u.Password == password);
            if (user == null) return string.Empty;

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.UTF8.GetBytes("12345678Darshan12345678Darshan12345678");
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                {
                    new Claim(ClaimTypes.Name, user.Username),
                    new Claim(ClaimTypes.Role, user.Role)
                }),
                Expires = DateTime.UtcNow.AddHours(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }

        public User? GetUser(string username) => _users.SingleOrDefault(u => u.Username == username);
    }
}