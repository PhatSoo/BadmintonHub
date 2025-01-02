using BadmintonHub.Mappings;
using BadmintonHub.Models;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace BadmintonHub.Handlers
{
    public class GenerateJwtTokenHandler
    {
        private readonly JwtMapping _jwtMapping;

        public GenerateJwtTokenHandler(IOptionsMonitor<JwtMapping> optionMonitor)
        {
            _jwtMapping = optionMonitor.CurrentValue;
        }
        public string GenerateJwtToken(User user)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                {
                    new Claim(ClaimTypes.Name, user.DisplayName),
                    new Claim(ClaimTypes.Role, user.Role.ToString()),
                    new Claim("Email", user.Email)
                }),
                Expires = DateTime.UtcNow.AddHours(1),
                Issuer = _jwtMapping.Issuer,
                Audience = _jwtMapping.Audience,
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(Encoding.ASCII.GetBytes(_jwtMapping.Key ?? "secret_key")), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}
