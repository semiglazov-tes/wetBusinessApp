using WetBusinessApp.Application.Abstractions.Auth;
using WetBusinessApp.Domain.ValueObjects;

namespace WetBusinessApp.Infrastructure.Auth;

public class PasswordHasher:IPasswordHasher
{
    public string Generate(string password)
    {
        return BCrypt.Net.BCrypt.EnhancedHashPassword(password);
    }

    public  Result Verify(string password, string passwordHash)
    {
        bool isVerify = BCrypt.Net.BCrypt.EnhancedVerify(password, passwordHash);
        if (!isVerify)
        {
            return Result.Fail("Введный пароль невалидный");
        }

        return Result.Ok();
    }
}