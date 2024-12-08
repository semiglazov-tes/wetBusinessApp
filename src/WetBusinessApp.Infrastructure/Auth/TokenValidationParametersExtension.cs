using Microsoft.IdentityModel.Tokens;

namespace WetBusinessApp.Infrastructure.Auth;

public static class TokenValidationParametersExtension
{
    public static TokenValidationParameters Generate(this TokenValidationParameters parameters, SecurityKey securityKey)
    {
        parameters.ValidateIssuer = false;
        parameters.ValidateAudience = false;
        parameters.ValidateLifetime = true;
        parameters.ValidateIssuerSigningKey = true;
        parameters.ClockSkew = TimeSpan.Zero;
        parameters.IssuerSigningKey = securityKey;
        return parameters;
    }
}