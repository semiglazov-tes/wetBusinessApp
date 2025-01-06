using WetBusinessApp.Application.Abstractions.Auth;
using WetBusinessApp.Application.DTO;
using WetBusinessApp.Domain;
using WetBusinessApp.Domain.Entities;

namespace WetBusinessApp.Application.Services;

public class TokenService
{
    private readonly UserService _userService;
    private readonly IJwtTokenService _jwtTokenService;
    
    public TokenService(UserService userService, IJwtTokenService jwtTokenService)
    {
        _userService = userService;
        _jwtTokenService = jwtTokenService;
    }
    
    public async Task<Result<AuthDTO>> GetAccessAndRefreshToken(User user)
    {
        var accessToken = _jwtTokenService.GenerateAccessToken(user);
        var refreshToken = _jwtTokenService.GenerateRefreshToken();
        
        var userId = user.Id;
        var getUserRefreshTokenDataResult = await _userService.UpdateRefreshTokenData(userId, refreshToken, _jwtTokenService.RefreshTokenExpires);
        if (!getUserRefreshTokenDataResult.IsSuccess) 
        {
            return Result<AuthDTO>.Fail(getUserRefreshTokenDataResult.Error);
        }
        
        var authDto = new AuthDTO(accessToken,refreshToken);
        var accessAndRefreshTokenResult = Result<AuthDTO>.Ok(authDto);
        return accessAndRefreshTokenResult;
    }

    public Result<string> GetUserNameFromExpiredToken(string expiredAccessToken)
    {
        var getUserNameFromExpiredTokenResult =  _jwtTokenService.GetUserNameFromExpiredToken(expiredAccessToken);
        return getUserNameFromExpiredTokenResult;
    }

}