using WetBusinessApp.Application.Abstractions.Auth;
using WetBusinessApp.Application.DTO;
using WetBusinessApp.Application.Services;
using WetBusinessApp.Domain;


namespace WetBusinessApp.Application.UseCases.AuthenticationUseCases;

public class LoginUseCase : ILoginUseCase
{
    private readonly UserService _userService; 
    private readonly TokenService _tokenService;
    private readonly IPasswordHasher _passwordHasher;
    
    
    public LoginUseCase(UserService userService, TokenService tokenService,  IPasswordHasher passwordHasher)
    {
        _userService = userService;
        _tokenService = tokenService;
        _passwordHasher = passwordHasher;
    }
    
    public async Task<Result<AuthDTO>> ExecuteAsync(string userName, string password )
    {
        var getUserResult = await _userService.GetUserByName(userName);
        if (!getUserResult.IsSuccess) return Result<AuthDTO>.Fail(getUserResult.Error);

        var getPasswordValidResult = _passwordHasher.Verify(password, getUserResult.Value.PasswordHash);
        if (!getPasswordValidResult.IsSuccess) return Result<AuthDTO>.Fail(getPasswordValidResult.Error);

        var getLoginResult = await _tokenService.GetAccessAndRefreshToken(getUserResult.Value);
        if (!getLoginResult.IsSuccess) return Result<AuthDTO>.Fail(getLoginResult.Error);
        
        var loginResult = Result<AuthDTO>.Ok(getLoginResult.Value);
        return loginResult;
    }
}