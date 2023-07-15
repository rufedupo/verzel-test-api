using System.IdentityModel.Tokens.Jwt;
using System.Text;
using verzel_test_api.domain.Interfaces.Services;
using verzel_test_api.domain.Models;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using verzel_test_api.domain.Settings;

namespace verzel_test_api.business.Services
{
    public class TokenService : ITokenService
    {
        public string GenerateToken(User user)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(SettingJwt.Secret);
            var tokenDescription = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                {
                    new Claim(ClaimTypes.Name, user.Id.ToString()),
                    new Claim(ClaimTypes.Email, user.Email),
                    new Claim(ClaimTypes.Role, user.Role)
                }),
                Expires = DateTime.UtcNow.AddHours(8),
                SigningCredentials = new SigningCredentials(
                    new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescription);
            return tokenHandler.WriteToken(token);
        }
    }
}