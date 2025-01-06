using WetBusinessApp.Application.Abstractions.Auth;
using WetBusinessApp.Application.DTO;
using WetBusinessApp.Application.Services;
using WetBusinessApp.Domain;

namespace WetBusinessApp.Application.UseCases.AuthenticationUseCases;

public class RefreshTokenUseCase:IRefreshTokenUseCase
{
    private readonly UserService _userService; 
    private readonly TokenService _tokenService;
    
    public RefreshTokenUseCase(UserService userService, TokenService tokenService)
    {
        _userService = userService;
        _tokenService = tokenService;
    }
    
    public async Task<Result<AuthDTO>> ExecuteAsync(string expiredAccessToken, string refreshToken)
    {
        var getUserNameFromExpiredTokenResult = _tokenService.GetUserNameFromExpiredToken(expiredAccessToken);
        if (!getUserNameFromExpiredTokenResult.IsSuccess)
        {
            return Result<AuthDTO>.Fail(getUserNameFromExpiredTokenResult.Error);
        }
        
        var getUserResult = await _userService.GetUserByName(getUserNameFromExpiredTokenResult.Value);
        if (!getUserResult.IsSuccess) return Result<AuthDTO>.Fail(getUserResult.Error);
        var user = getUserResult.Value;
        if(user.RefreshToken != refreshToken || user.RefreshTokenExpiryTime <= DateTime.UtcNow) return Result<AuthDTO>.Fail("refresh токен невалидный, либо просрочен");
        
        var getRefreshTokenResult = await _tokenService.GetAccessAndRefreshToken(getUserResult.Value);
        if (!getRefreshTokenResult.IsSuccess) return Result<AuthDTO>.Fail(getRefreshTokenResult.Error);
        
        var refreshResult = Result<AuthDTO>.Ok(getRefreshTokenResult.Value);
        return refreshResult;
    }
}