using WetBusinessApp.Domain;
using WetBusinessApp.Application.Abstractions;
using WetBusinessApp.Application.Utils;

namespace WetBusinessApp.Application.Services;

public class UserService
{
    private readonly IUserRepository _userRepository;
    public UserService(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task Register(string userName, string userEmail, string password )
    {
        var passworHash = PasswordHasher.Generate(password);
        var user = User.Create(Guid.NewGuid(), userName, userEmail, passworHash);
        await _userRepository.Create(user);
    }
}
