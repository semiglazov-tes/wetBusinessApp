using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WetBusinessApp.Application.Services;
using WetBusinessApp.Domain;
using WetBusinessApp.Domain.Entities;
using WetBusinessApp.Presentation.Contracts;

namespace WetBusinessApp.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly UserService _userService;

        public UserController(UserService userService)
        {
            _userService = userService;
        }

        [HttpGet("getAllUsers")]
        [Authorize]
        public async Task<IEnumerable<User>> GetAllUsers()
        {
            var users = await  _userService.GetAllUsers();
            return users;
        }

    }
}
