using WetBusinessApp.Domain;
using WetBusinessApp.Application.Abstractions;
using WetBusinessApp.Application.Utils.Auth;
using WetBusinessApp.Domain.Entities;

namespace WetBusinessApp.Application.Services;

public class UserService
{
    private readonly IUserRepository _userRepository;
    private readonly JwtTokenService _jwtTokenService;
    public UserService(IUserRepository userRepository, JwtTokenService jwtTokenService)
    {
        _userRepository = userRepository;
        _jwtTokenService = jwtTokenService;
    }

    public async Task<string> Login(string userName, string password)
    {
        var user = await _userRepository.GetByUserName(userName);
        var passwordIsValid = PasswordHasher.Verify(password, user.PasswordHash);
        if (passwordIsValid) 
        {
            var jwtTokenString = _jwtTokenService.Generate(user);
            return jwtTokenString;
        }
        else
        {
            throw new Exception("Пароль неверен");
        }

    }

    public async Task Register(string userName, string userEmail, string password )
    {
        var passworHash = PasswordHasher.Generate(password);
        var user = User.Create(Guid.NewGuid(), userName, userEmail, passworHash);
        await _userRepository.Create(user);
    }

    public async Task<List<User>> GetAllUsers()
    {
        var users = await _userRepository.GetAllUser();
        return users;
    }

}
