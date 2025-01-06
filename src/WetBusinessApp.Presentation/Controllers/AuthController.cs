using Microsoft.AspNetCore.Mvc;
using WetBusinessApp.Application.Abstractions.Auth;
using WetBusinessApp.Presentation.Contracts.Login;
using WetBusinessApp.Presentation.Contracts.Register;

namespace WetBusinessApp.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IRegistrationUseCase _registrationUseCase;
        private readonly ILoginUseCase _loginUseCase;

        public AuthController(IRegistrationUseCase registrationUseCase, ILoginUseCase loginUseCase)
        {
            _registrationUseCase = registrationUseCase;
            _loginUseCase = loginUseCase;
        }
        
        [HttpPost("register")]
        public async Task<IResult> Register([FromBody] RegisterRequest request)
        {
            var registerResult = await _registrationUseCase.ExecuteAsync(request.UserName, request.UserEmail, request.Password);
            if (registerResult.IsSuccess)
            {
                return Results.Ok();
            }
            return Results.BadRequest(registerResult.Error);
        }

        [HttpPost("login")]
        public async Task<IResult> Login([FromBody] LoginRequest request)
        {
            var loginResult = await _loginUseCase.ExecuteAsync(request.UserName, request.Password);
            if (loginResult.IsSuccess)
            {
                var accessToken = loginResult.Value.AccessToken;
                var refreshToken = loginResult.Value.RefreshToken;
                Response.Cookies.Append("accessToken", accessToken);
                Response.Cookies.Append("refreshToken", refreshToken);
                return Results.Ok();
            }
            
            return Results.BadRequest(loginResult.Error);
        }
    }
}
