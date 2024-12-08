using System.Text;
using Microsoft.IdentityModel.Tokens;
using WetBusinessApp.Application.Abstractions.Auth;

namespace WetBusinessApp.Infrastructure.Auth;

public class AuthSettings:IAuthSettings
{
    public TimeSpan AccessTokenExpires { get; set; }
    public TimeSpan RefreshTokenExpires { get; set; }
    public string SecretKey { get; set;}
}