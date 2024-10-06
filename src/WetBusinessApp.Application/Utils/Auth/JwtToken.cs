
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using WetBusinessApp.Domain;

namespace WetBusinessApp.Application.Utils.Auth
{
    public class JwtToken
    {
        public readonly IOptions<AuthSettings> _authOptions;

        public JwtToken(IOptions<AuthSettings> authOptions)
        {
            _authOptions = authOptions;

        }
        public string Generate(User user)
        {
            var claims = new List<Claim>
            {
                new Claim("userEmail", user.UserEmail),
                new Claim("userName",user.UserName)
            };

            var jwtToken = new JwtSecurityToken(
                expires: DateTime.UtcNow.Add(_authOptions.Value.Expires),
                claims: claims,
                signingCredentials:
                    new SigningCredentials(
                    new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_authOptions.Value.SecretKey)),
                    SecurityAlgorithms.HmacSha256)
                );

            return new JwtSecurityTokenHandler().WriteToken(jwtToken);
        }
    }
}
