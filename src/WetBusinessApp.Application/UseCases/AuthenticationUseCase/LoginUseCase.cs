using WetBusinessApp.Application.Abstractions.Auth;
using WetBusinessApp.Application.Abstractions.Storage;
using WetBusinessApp.Domain.ValueObjects;

namespace WetBusinessApp.Application.UseCases.AuthenticationUseCase;

public class LoginUseCase
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
    
    public async Task<Result> ExecuteAsync(string userName, string password )
    {
        var getUserPassWordHashResult = await _userRepository.GetByUserName(userName);
        if (!getUserPassWordHashResult.IsSuccess)
        {
            return getUserPassWordHashResult;
        }
        var passwordValidResult = _passwordHasher.Verify(password, getUserPassWordHashResult.Value);
        if (!passwordValidResult.IsSuccess) 
        {
            return passwordValidResult;
        }
        var jwtTokenString = _jwtTokenService.Generate(user);
        return jwtTokenString;
    }
}