using Api.Configurations.v1;
using Api.DataTransferObjects.v1;
using Api.Interfaces.v1;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Api.Services.v1;

public class TokenService : ITokenService
{
    public string GenerateToken(User user)
    {
        var tokenHandler = new JwtSecurityTokenHandler();
        var key = Encoding.ASCII.GetBytes(AppSettings.Secret);
        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = InjectClaims(user),
            Expires = DateTime.UtcNow.AddHours(1),
            SigningCredentials = new(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
        };

        var token = tokenHandler.CreateToken(tokenDescriptor);
        return tokenHandler.WriteToken(token);
    }

    private static ClaimsIdentity InjectClaims(User user) =>
        new([
                new (ClaimTypes.Name, user.Username),
                new (ClaimTypes.Role, user.Role)
            ]);
}