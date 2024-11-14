
namespace WetBusinessApp.Application.Abstractions.Storage;

public interface IRepository<T> : IDisposable where T : class
{
    Task Create(T item); // создание объекта
    Task Update(T item); // обновление объекта
    Task Delete(Guid id); // удаление объекта по id
}
