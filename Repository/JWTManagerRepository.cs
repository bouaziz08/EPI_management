using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.Extensions.Configuration;
using HSE.Services;
using HSE.Models.Auth;

namespace HSE.Repository
{
    public class JWTManagerRepository : IJWTManagerRepository
    {
        private readonly IConfiguration _configuration;

        public JWTManagerRepository(IConfiguration configuration)
        {
            _configuration = configuration;
    
        }

        public Tokens CreateToken(string username, string role, string preferredLanguage)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var tokenKey = Encoding.UTF8.GetBytes(_configuration["JWT:Key"]);

            // Ensure tokenKey length is sufficient for the algorithm
            if (tokenKey.Length < 32)
            {
                throw new InvalidOperationException("JWT key length is insufficient.");
            }

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                {
                    new Claim(ClaimTypes.Name, username),
                    new Claim(ClaimTypes.Role, role),
                    new Claim("preferred_language", preferredLanguage) // Add preferredLanguage to claims if needed
                }),
                Expires = DateTime.UtcNow.AddDays(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(tokenKey), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            return new Tokens
            {
                Token = tokenHandler.WriteToken(token),
                Role = role,
                PreferredLanguage = preferredLanguage
            };
        }
    }
}
