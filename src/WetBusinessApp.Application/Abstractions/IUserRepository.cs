using WetBusinessApp.Domain;
using WetBusinessApp.Domain.Entities;

namespace WetBusinessApp.Application.Abstractions;

public interface IUserRepository:IRepository<User>
{
     Task<User> GetByUserName(string userName);

    Task<List<User>> GetAllUser();
}
