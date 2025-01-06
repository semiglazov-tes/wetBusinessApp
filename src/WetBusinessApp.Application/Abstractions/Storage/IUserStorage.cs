using WetBusinessApp.Domain.Entities;
using WetBusinessApp.Domain;

namespace WetBusinessApp.Application.Abstractions.Storage;

public interface IUserStorage
{
     Task<Result> Create(User user);
     
     Task<Result<User>> GetByUserName(string userName);

     Task<Result> UpdateRefreshTokenData(Guid userId, string refreshToken, DateTime refreshTokenExpiryTime);

     Task<List<User>> GetAllUser();
}
