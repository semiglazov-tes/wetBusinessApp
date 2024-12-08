using Microsoft.Extensions.Options;
using WetBusinessApp.Domain.Entities;

namespace WetBusinessApp.Application.Abstractions.Auth;

public interface IJwtTokenService
{
    DateTime RefreshTokenExpires{ get; }
    string GenerateAccessToken(User user);
    string GenerateRefreshToken();
}