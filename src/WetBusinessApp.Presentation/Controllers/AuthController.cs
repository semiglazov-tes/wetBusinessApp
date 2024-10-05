using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WetBusinessApp.Application.Services;
using WetBusinessApp.Presentation.Contracts;

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
        public async Task<IResult>  Register([FromBody] RegisterUserRequest request)
        {
            await _userService.Register(request.UserName, request.UserEmail, request.Password);
            return Results.Ok();
        }
    }
}
