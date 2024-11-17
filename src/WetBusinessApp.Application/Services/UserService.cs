using WetBusinessApp.Application.Abstractions.Auth;
using WetBusinessApp.Application.Abstractions.Storage;

using WetBusinessApp.Domain.Entities;

namespace WetBusinessApp.Application.Services;

public class UserService
{
    private readonly IUserRepository _userRepository;
    private readonly IJwtTokenService _jwtTokenService;
    private readonly IPasswordHasher _passwordHasher;
    
    public UserService(IUserRepository userRepository, IJwtTokenService jwtTokenService, IPasswordHasher passwordHasher)
    {
        _userRepository = userRepository;
        _jwtTokenService = jwtTokenService;
        _passwordHasher = passwordHasher;
    }

   /* public async Task<string> Login(string userName, string password)
    {
        var getUserResult = await _userRepository.GetByUserName(userName);
        if (!getUserResult.IsSuccess)
        {
            
        }
        var passwordIsValid = _passwordHasher.Verify(password, user.PasswordHash);
        if (passwordIsValid) 
        {
            var jwtTokenString = _jwtTokenService.Generate(user);
            return jwtTokenString;
        }
        else
        {
            throw new Exception("Пароль неверен");
        }

    }*/

    public async Task Register(string userName, string userEmail, string password )
    {
        var passworHash = _passwordHasher.Generate(password);
        var user = User.Create(Guid.NewGuid(), userName, userEmail, passworHash);
        await _userRepository.Create(user);
    }

    public async Task<List<User>> GetAllUsers()
    {
        var users = await _userRepository.GetAllUser();
        return users;
    }

}
