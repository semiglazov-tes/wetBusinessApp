namespace WetBusinessApp.Application.Abstractions.Auth;

public interface IAuthSettings
{
    TimeSpan Expires { get; }
    string SecretKey { get; }
}