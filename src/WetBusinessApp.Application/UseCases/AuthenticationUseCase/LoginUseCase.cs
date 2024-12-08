using WetBusinessApp.Application.Abstractions.Auth;
using WetBusinessApp.Application.Abstractions.Storage;
using WetBusinessApp.Application.DTO;
using WetBusinessApp.Domain;

namespace WetBusinessApp.Application.UseCases.AuthenticationUseCase;

public class LoginUseCase : ILoginUseCase
{
    private readonly IUserStorage _userStorage; 
    private readonly IJwtTokenService _jwtTokenService;
    private readonly IPasswordHasher _passwordHasher;
    
    
    public LoginUseCase(IUserStorage userStorage, IJwtTokenService jwtTokenService,  IPasswordHasher passwordHasher)
    {
        _userStorage = userStorage;
        _jwtTokenService = jwtTokenService;
        _passwordHasher = passwordHasher;
    }
    
    public async Task<Result<AuthDto>> ExecuteAsync(string userName, string password )
    {
        var getUserResult = await _userStorage.GetByUserName(userName);
        var userId = getUserResult.Value.Id;
        if (!getUserResult.IsSuccess)
        {
            return Result<AuthDto>.Fail(getUserResult.Error);
        }
        
        var getPasswordValidResult = _passwordHasher.Verify(password, getUserResult.Value.PasswordHash);
        if (!getPasswordValidResult.IsSuccess) 
        {
            return Result<AuthDto>.Fail(getPasswordValidResult.Error);
        }
        
        var accessToken = _jwtTokenService.GenerateAccessToken(getUserResult.Value);
        var refreshToken = _jwtTokenService.GenerateRefreshToken();

        var getUserRefreshTokenDataResult = await _userStorage.UpdateRefreshTokenData(userId, refreshToken, _jwtTokenService.RefreshTokenExpires);
        if (!getUserRefreshTokenDataResult.IsSuccess) 
        {
            return Result<AuthDto>.Fail(getUserRefreshTokenDataResult.Error);
        }
        
        var authDto = new AuthDto(accessToken,refreshToken);
        var loginResult = Result<AuthDto>.Ok(authDto);
        return loginResult;
    }
}