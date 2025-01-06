using WetBusinessApp.Application.Abstractions.Auth;
using WetBusinessApp.Application.Abstractions.Storage;
using WetBusinessApp.Domain;
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
    
    public async Task<Result<User>> GetUserByName(string userName)
    {
        var getUserResult = await _userStorage.GetByUserName(userName);
        return getUserResult;
    }

    public async Task<Result> UpdateRefreshTokenData(Guid userId, string refreshToken, DateTime refreshTokenExpires)
    {
        var getUserRefreshTokenDataResult = await _userStorage.UpdateRefreshTokenData(userId, refreshToken, refreshTokenExpires);
        return getUserRefreshTokenDataResult;
    }
    
}
