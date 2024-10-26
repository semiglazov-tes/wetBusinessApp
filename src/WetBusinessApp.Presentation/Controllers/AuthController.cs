using Microsoft.AspNetCore.Mvc;
using WetBusinessApp.Application.Services;
using WetBusinessApp.Presentation.Contracts;
using WetBusinessApp.Presentation.Contracts.Login;
using WetBusinessApp.Presentation.Contracts.Register;

namespace WetBusinessApp.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly UserService _userService;

        public AuthController(UserService userService)
        {
            _userService = userService;
        }
        
        [HttpPost("register")]
        public async Task<IResult> Register([FromBody] RegisterRequest request)
        {
            await _userService.Register(request.UserName, request.UserEmail, request.Password);
            return Results.Ok();
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
