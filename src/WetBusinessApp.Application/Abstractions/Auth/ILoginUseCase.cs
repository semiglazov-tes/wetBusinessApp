using WetBusinessApp.Application.DTO;
using WetBusinessApp.Domain;

namespace WetBusinessApp.Application.Abstractions.Auth;

public interface ILoginUseCase
{
    Task<Result<AuthDTO>> ExecuteAsync(string userName, string password);
}