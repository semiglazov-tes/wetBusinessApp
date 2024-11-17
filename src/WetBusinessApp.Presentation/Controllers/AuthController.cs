using Microsoft.AspNetCore.Mvc;
using WetBusinessApp.Application.Services;
using WetBusinessApp.Application.UseCases.AuthenticationUseCase;
using WetBusinessApp.Presentation.Contracts;
using WetBusinessApp.Presentation.Contracts.Login;
using WetBusinessApp.Presentation.Contracts.Register;

namespace WetBusinessApp.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly RegistrationUseCase _registrationUseCase;

        public AuthController(RegistrationUseCase registrationUseCase)
        {
            _registrationUseCase = registrationUseCase;
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
            var token = await _userService.Login(request.UserName, request.Password);
            Response.Cookies.Append("token", token);
            return Results.Ok();
        }
    }
}
