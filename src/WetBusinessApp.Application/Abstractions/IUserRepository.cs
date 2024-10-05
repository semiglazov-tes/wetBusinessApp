using WetBusinessApp.Domain;

namespace WetBusinessApp.Application.Abstractions;

public interface IUserRepository:IRepository<User>
{
     Task<User> GetByUserEmail(Guid id);
}
