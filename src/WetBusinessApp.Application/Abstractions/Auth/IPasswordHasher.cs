using WetBusinessApp.Domain.ValueObjects;

namespace WetBusinessApp.Application.Abstractions.Auth;

public interface IPasswordHasher
{
    string Generate(string password);
    Result Verify(string password, string passwordHash);
}