using WetBusinessApp.Domain.ValueObjects;

namespace WetBusinessApp.Application.Abstractions.Auth;

public interface ILoginUseCase
{
    Task<Result<string>> ExecuteAsync(string userName, string password);
}