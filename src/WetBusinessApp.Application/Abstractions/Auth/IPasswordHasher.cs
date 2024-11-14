namespace WetBusinessApp.Application.Abstractions.Auth;

public interface IPasswordHasher
{
    string Generate(string password);
    bool Verify(string password, string passwordHash);
}