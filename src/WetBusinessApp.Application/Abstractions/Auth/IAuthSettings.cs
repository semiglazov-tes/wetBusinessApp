namespace WetBusinessApp.Application.Abstractions.Auth;

public interface IAuthSettings
{
    TimeSpan AccessTokenExpires { get; set; }
    TimeSpan RefreshTokenExpires { get; set; }
    string SecretKey { get; set; }
    
}