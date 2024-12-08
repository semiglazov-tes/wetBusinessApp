using WetBusinessApp.Domain;

namespace WetBusinessApp.Application.Abstractions.Auth;

public interface IRefreshTokenUsecase
{
    Task<Result> ExecuteAsync(string accessToken, string refreshToken);
}