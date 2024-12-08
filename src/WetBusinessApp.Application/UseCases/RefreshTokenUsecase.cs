using WetBusinessApp.Application.Abstractions.Auth;
using WetBusinessApp.Application.Abstractions.Storage;
using WetBusinessApp.Domain;

namespace WetBusinessApp.Application.UseCases;

public class RefreshTokenUsecase:IRefreshTokenUsecase
{
    private readonly IUserStorage _userStorage; 
    private readonly IJwtTokenService _jwtTokenService;
    
    public RefreshTokenUsecase(IUserStorage userStorage, IJwtTokenService jwtTokenService)
    {
        _userStorage = userStorage;
        _jwtTokenService = jwtTokenService;
    }
    
    public Task<Result> ExecuteAsync(string accessToken, string refreshToken)
    {
        throw new NotImplementedException();
    }
}