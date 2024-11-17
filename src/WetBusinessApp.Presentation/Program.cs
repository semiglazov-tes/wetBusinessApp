using Microsoft.AspNetCore.CookiePolicy;
using WetBusinessApp.Application.Abstractions.Storage;
using WetBusinessApp.Application.Services;
using WetBusinessApp.Application.UseCases.AuthenticationUseCase;
using WetBusinessApp.Infrastructure.Auth;
using WetBusinessApp.Infrastructure.DB;
using WetBusinessApp.Infrastructure.Storage.Repositories;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors();
builder.Services.AddControllers();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<WetBusinessDContext>();
builder.Services.AddScoped<UserService>();
builder.Services.AddScoped<RegistrationUseCase>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddAuth(builder.Configuration);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCookiePolicy(new CookiePolicyOptions
{
    MinimumSameSitePolicy = SameSiteMode.Strict,
    HttpOnly = HttpOnlyPolicy.Always,
    Secure = CookieSecurePolicy.Always
});

app.UseCors(policyBuilder => policyBuilder.WithOrigins("http://localhost:4200")
    .AllowAnyMethod()
    .AllowAnyHeader()
    .AllowCredentials());

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
