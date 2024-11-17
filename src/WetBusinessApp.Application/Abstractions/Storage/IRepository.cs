using WetBusinessApp.Domain.ValueObjects;

namespace WetBusinessApp.Application.Abstractions.Storage;

public interface IRepository<T> : IDisposable where T : class
{
    Task<Result> Create(T item); // создание объекта
    Task<Result> Update(T item); // обновление объекта
    Task<Result> Delete(Guid id); // удаление объекта по id
}
