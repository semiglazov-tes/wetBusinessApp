using Microsoft.IdentityModel.Tokens;

namespace WetBusinessApp.Infrastructure.Auth;

public static class JwtTokenValidationParametersExtension
{
    public static TokenValidationParameters Generate(this TokenValidationParameters parameters, SecurityKey securityKey)
    {
        parameters.ValidateIssuer = false;
        parameters.ValidateAudience = false;
        parameters.ValidateLifetime = true;
        parameters.ValidateIssuerSigningKey = true;
        parameters.IssuerSigningKey = securityKey;
        return parameters;
    }
}