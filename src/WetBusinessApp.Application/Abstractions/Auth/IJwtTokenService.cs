using Microsoft.Extensions.Options;
using WetBusinessApp.Domain.Entities;

namespace WetBusinessApp.Application.Abstractions.Auth;

public interface IJwtTokenService
{
    IOptions<IAuthSettings> AuthOptions { get;}
    string Generate(User user);
}