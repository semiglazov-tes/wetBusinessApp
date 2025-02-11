using WetBusinessApp.Domain;

namespace WetBusinessApp.Application.Abstractions.Auth;

public interface IRegistrationUseCase
{
    Task<Result> ExecuteAsync(string userName, string userEmail, string password);
}