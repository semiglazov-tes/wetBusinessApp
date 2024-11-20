using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using WetBusinessApp.Application.Abstractions.Auth;
using WetBusinessApp.Domain.Entities;

namespace WetBusinessApp.Infrastructure.Auth;

public class JwtTokenService: IJwtTokenService
{
    public IOptions<IAuthSettings> AuthOptions { get; }
    
    public JwtTokenService(IOptions<AuthSettings> authOptions)
    {
        AuthOptions = authOptions;
    }
    public string Generate(User user) 
    {
        var claims = new List<Claim>
        {
            new Claim("userEmail", user.UserEmail),
            new Claim("userName",user.UserName)
        };

        var jwtToken = new JwtSecurityToken(
            expires: DateTime.UtcNow.Add(AuthOptions.Value.Expires),
            claims: claims,
            signingCredentials:
            new SigningCredentials(
                new SymmetricSecurityKey(Encoding.UTF8.GetBytes(AuthOptions.Value.SecretKey)),
                SecurityAlgorithms.HmacSha256)
        );

        return new JwtSecurityTokenHandler().WriteToken(jwtToken);
    }
}