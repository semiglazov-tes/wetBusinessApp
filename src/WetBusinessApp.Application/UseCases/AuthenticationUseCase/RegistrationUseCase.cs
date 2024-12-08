using WetBusinessApp.Application.Abstractions.Auth;
using WetBusinessApp.Application.Abstractions.Storage;
using WetBusinessApp.Domain.Entities;
using WetBusinessApp.Domain;

namespace WetBusinessApp.Application.UseCases.AuthenticationUseCase;

public class RegistrationUseCase : IRegistrationUseCase
{
    private readonly IUserStorage _userStorage;
    private readonly IPasswordHasher _passwordHasher;
    
    public RegistrationUseCase(IUserStorage userStorage, IPasswordHasher passwordHasher)
    {
        _userStorage = userStorage;
        _passwordHasher = passwordHasher;
    }
    
    public async Task<Result> ExecuteAsync(string userName, string userEmail, string password )
    {
        var passwordHash = _passwordHasher.Generate(password);
        var user = User.Create(Guid.NewGuid(), userName, userEmail, passwordHash);
        var registerResult = await _userStorage.Create(user);
        return registerResult;
    }
}