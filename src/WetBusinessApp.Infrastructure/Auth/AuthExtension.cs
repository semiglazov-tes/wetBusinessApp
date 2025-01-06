using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using WetBusinessApp.Application.Abstractions.Auth;

namespace WetBusinessApp.Infrastructure.Auth;

public static class AuthExtension
{
    public static void AddAuth(this IServiceCollection servicesCollection, IConfiguration configuration)
    {
        servicesCollection.Configure<AuthSettings>(configuration.GetSection("AuthSettings"));
        servicesCollection.AddScoped<IJwtTokenService,JwtTokenService>(); 
        servicesCollection.AddScoped<IPasswordHasher,PasswordHasher>(); 

        var authSettings = configuration.GetSection(nameof(AuthSettings)).Get<AuthSettings>();
        var issuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(authSettings.SecretKey));

        servicesCollection.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(o =>
            {
                o.TokenValidationParameters = new TokenValidationParameters().Generate(issuerSigningKey);
                o.Events = new JwtBearerEvents
                {
                    OnMessageReceived = context =>
                    {
                        context.Token = context.Request.Cookies["accessToken"];
                        return Task.CompletedTask;
                    }
                };

            });
    }
}