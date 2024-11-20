using WetBusinessApp.Application.Abstractions.Auth;
using WetBusinessApp.Application.Abstractions.Storage;
using WetBusinessApp.Domain.ValueObjects;

namespace WetBusinessApp.Application.UseCases.AuthenticationUseCase;

public class LoginUseCase : ILoginUseCase
{
    private readonly IUserRepository _userRepository;
    private readonly IJwtTokenService _jwtTokenService;
    private readonly IPasswordHasher _passwordHasher;
    
    
    public LoginUseCase(IUserRepository userRepository, IJwtTokenService jwtTokenService,  IPasswordHasher passwordHasher)
    {
        _userRepository = userRepository;
        _jwtTokenService = jwtTokenService;
        _passwordHasher = passwordHasher;
    }
    
    public async Task<Result<string>> ExecuteAsync(string userName, string password )
    {
        var getUserResult = await _userRepository.GetByUserName(userName);
        if (!getUserResult.IsSuccess)
        {
            return Result<string>.Fail(getUserResult.Error);
        }
        var passwordValidResult = _passwordHasher.Verify(password, getUserResult.Value.PasswordHash);
        if (!passwordValidResult.IsSuccess) 
        {
            return Result<string>.Fail(passwordValidResult.Error);
        }
        var jwtTokenString = _jwtTokenService.Generate(getUserResult.Value);

        var loginResult = Result<string>.Ok(jwtTokenString);

        return loginResult;
    }
}