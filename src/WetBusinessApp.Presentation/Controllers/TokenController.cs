using Microsoft.AspNetCore.Mvc;
using WetBusinessApp.Application.Abstractions.Auth;

namespace WetBusinessApp.Presentation.Controllers;

public class TokenController:ControllerBase
{
    private readonly IRefreshTokenUseCase _refreshTokenUseCase;

    public TokenController(IRefreshTokenUseCase refreshTokenUseCase)
    {
        _refreshTokenUseCase = refreshTokenUseCase;
    }

    [HttpGet("refresh")]
    public async Task<IResult> Refresh()
    {
        if (Request.Cookies.TryGetValue("accessToken", out var accessToken) &&
            Request.Cookies.TryGetValue("refreshToken", out var refreshToken))
        {
            var refreshResult = await _refreshTokenUseCase.ExecuteAsync(accessToken, refreshToken);
            if (refreshResult.IsSuccess)
            {
                return Results.Ok();
            }
            return Results.BadRequest(refreshResult.Error);
        }
        return Results.BadRequest("Отсутствует access/refresh token");
    }
}