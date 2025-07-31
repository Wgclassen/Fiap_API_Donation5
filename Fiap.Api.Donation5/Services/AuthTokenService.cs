using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Fiap.Api.Donation5.Services;
public class AuthTokenService
{
    private readonly IConfiguration _configuration;

    public AuthTokenService(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public string GenerateToken(string email, int usuarioId, string regra)
    {
        var claims = new[] {
        new Claim(JwtRegisteredClaimNames.Sub, usuarioId.ToString()),
        new Claim(JwtRegisteredClaimNames.Email, email),
        new Claim(ClaimTypes.Role, email),
        new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
        };


        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:key"]));

        var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

        var token = new JwtSecurityToken(
            issuer: _configuration["Jwt:Issuer"],
            audience: _configuration["Jwt:Audience"],
            claims : claims,
            expires: DateTime.Now.AddMinutes(5),
            signingCredentials: creds
            );

        return new JwtSecurityTokenHandler().WriteToken(token);
    }
}
