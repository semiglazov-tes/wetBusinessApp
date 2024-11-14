using WetBusinessApp.Application.Abstractions.Auth;

namespace WetBusinessApp.Infrastructure.Auth;

public class PasswordHasher:IPasswordHasher
{
    public string Generate(string password)
    {
        return BCrypt.Net.BCrypt.EnhancedHashPassword(password);
    }

    public  bool Verify(string password, string passwordHash)
    {
        return BCrypt.Net.BCrypt.EnhancedVerify(password, passwordHash);
    }
}