
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace WetBusinessApp.Application.Utils.Auth
{
    public static class AuthExtensions
    {
        public static IServiceCollection AddAuth(this IServiceCollection servicesCollection, IConfiguration configuration)
        {

            servicesCollection.Configure<AuthSettings>(configuration.GetSection("AuthSettings"));
            servicesCollection.AddScoped<JwtTokenService>();

            var auttSettings = configuration.GetSection(nameof(AuthSettings)).Get<AuthSettings>();

            servicesCollection.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                              .AddJwtBearer(o =>
                              {
                                  o.TokenValidationParameters = new TokenValidationParameters
                                  {
                                      ValidateIssuer = false,
                                      ValidateAudience = false,
                                      ValidateLifetime = true,
                                      ValidateIssuerSigningKey = true,
                                      IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(auttSettings.SecretKey))
                                  };

                                  o.Events = new JwtBearerEvents
                                  {
                                      OnMessageReceived = context =>
                                      {
                                          context.Token = context.Request.Cookies["token"];
                                          return Task.CompletedTask;
                                      }
                                  };

                              });
            return servicesCollection;
        }
    }
}
