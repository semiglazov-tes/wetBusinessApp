using Microsoft.AspNetCore.Mvc;
using WetBusinessApp.Application.Abstractions.Auth;

namespace WetBusinessApp.Presentation.Controllers;

public class TokenController:ControllerBase
{
    private readonly IRefreshTokenUsecase _refreshTokenUseCase;

    public TokenController(IRefreshTokenUsecase refreshTokenUseCase)
    {
        _refreshTokenUseCase = refreshTokenUseCase;
        
        
    }

    [HttpGet("refresh")]
    public async Task<IResult> Refresh()
    {
        if (Request.Cookies.TryGetValue("accessToken", out var accessToken) &&
            Request.Cookies.TryGetValue("refreshToken", out var refreshToken))
        {
            var principal = _refreshTokenUseCase.ExecuteAsync(accessToken, refreshToken);
            return Results.Ok();
        }
        else
        {
            return Results.BadRequest("Отсутствует access/refresh token");
        }
    }
}