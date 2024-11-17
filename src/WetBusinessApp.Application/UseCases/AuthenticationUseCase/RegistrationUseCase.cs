using WetBusinessApp.Application.Abstractions.Auth;
using WetBusinessApp.Application.Abstractions.Storage;
using WetBusinessApp.Domain.Entities;
using WetBusinessApp.Domain.ValueObjects;

namespace WetBusinessApp.Application.UseCases.AuthenticationUseCase;

public class RegistrationUseCase
{
    private readonly IUserRepository _userRepository;
    private readonly IPasswordHasher _passwordHasher;
    
    public RegistrationUseCase(IUserRepository userRepository, IPasswordHasher passwordHasher)
    {
        _userRepository = userRepository;
        _passwordHasher = passwordHasher;
    }
    
    public async Task<Result> ExecuteAsync(string userName, string userEmail, string password )
    {
        var passworHash = _passwordHasher.Generate(password);
        var user = User.Create(Guid.NewGuid(), userName, userEmail, passworHash);
        var registerResult = await _userRepository.Create(user);
        return registerResult;
    }
}