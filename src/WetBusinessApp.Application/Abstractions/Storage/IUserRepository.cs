using WetBusinessApp.Domain.Entities;

namespace WetBusinessApp.Application.Abstractions.Storage;

public interface IUserRepository:IRepository<User>
{
     Task<User> GetByUserName(string userName);

    Task<List<User>> GetAllUser();
}
