using WetBusinessApp.Domain.Entities;
using WetBusinessApp.Domain.ValueObjects;

namespace WetBusinessApp.Application.Abstractions.Storage;

public interface IUserRepository:IRepository<User>
{
     Task<Result<User>> GetByUserName(string userName);

    Task<List<User>> GetAllUser();
}
