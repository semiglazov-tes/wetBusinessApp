using WetBusinessApp.Application.DTO;
using WetBusinessApp.Domain;

namespace WetBusinessApp.Application.Abstractions.Auth;

public interface IRefreshTokenUseCase
{
    Task<Result<AuthDTO>> ExecuteAsync(string expiredAccessToken, string refreshToken);
}