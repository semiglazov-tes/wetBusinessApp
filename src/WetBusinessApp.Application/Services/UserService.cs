using WetBusinessApp.Application.Abstractions.Auth;
using WetBusinessApp.Application.Abstractions.Storage;

using WetBusinessApp.Domain.Entities;

namespace WetBusinessApp.Application.Services;

public class UserService
{
    private readonly IUserStorage _userStorage;

    public UserService(IUserStorage userStorage)
    {
        _userStorage = userStorage;
    }
    public async Task<List<User>> GetAllUsers()
    {
        var users = await _userStorage.GetAllUser();
        return users;
    }

}
