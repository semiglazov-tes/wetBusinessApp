using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using WetBusinessApp.Application.Abstractions.Auth;
using WetBusinessApp.Domain;
using WetBusinessApp.Domain.Entities;

namespace WetBusinessApp.Infrastructure.Auth;

public class JwtTokenService:IJwtTokenService
{
    private readonly SymmetricSecurityKey _issuerSigningKey;
    private readonly DateTime _accessTokenExpires;
    public DateTime RefreshTokenExpires { get;}

    private List<Claim> CreateClaims(User user)
    {
        var claims = new List<Claim>
        {
            new Claim("userEmail", user.UserEmail),
            new Claim(ClaimTypes.Name,user.UserName)
        };
        return claims;
    }
    
    public JwtTokenService(IOptions<AuthSettings> authOptions)
    {
        _accessTokenExpires = DateTime.Now.Add(authOptions.Value.AccessTokenExpires);
        RefreshTokenExpires = DateTime.UtcNow.Add(authOptions.Value.RefreshTokenExpires);
        _issuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(authOptions.Value.SecretKey));
    }
    public string GenerateAccessToken(User user)
    {
       var claims =  CreateClaims(user);
       var signinCredentials = new SigningCredentials(_issuerSigningKey, SecurityAlgorithms.HmacSha256);

        var jwtTokenOptions = new JwtSecurityToken(
            expires: _accessTokenExpires,
            claims: claims,
            signingCredentials:signinCredentials
        );
        
        var jwtTokenString = new JwtSecurityTokenHandler().WriteToken(jwtTokenOptions);

        return jwtTokenString;
    }
    
    public string GenerateRefreshToken()
    {
        var randomNumber = new byte[32];
        using (var rng = RandomNumberGenerator.Create())
        {
            rng.GetBytes(randomNumber);
            return Convert.ToBase64String(randomNumber);
        }
    }
    
    public Result<string>  GetUserNameFromExpiredToken(string token)
    {
        var tokenValidationParameters = new TokenValidationParameters().Generate(_issuerSigningKey);
        var tokenHandler = new JwtSecurityTokenHandler();
        SecurityToken securityToken;
        var principal = tokenHandler.ValidateToken(token, tokenValidationParameters, out securityToken);
        var jwtSecurityToken = securityToken as JwtSecurityToken;
        if (jwtSecurityToken == null || !jwtSecurityToken.Header.Alg.Equals(SecurityAlgorithms.HmacSha256, StringComparison.InvariantCultureIgnoreCase))
            return Result<string>.Fail("Невалидный токен");
        
        return  Result<string>.Ok(principal.Identity.Name) ;
    }
    
      
}