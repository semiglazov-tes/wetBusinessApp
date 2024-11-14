using WetBusinessApp.Application.Abstractions.Auth;

namespace WetBusinessApp.Infrastructure.Auth;

public class AuthSettings:IAuthSettings
{
    public TimeSpan Expires { get; set; }
    public string SecretKey { get; set; }
}