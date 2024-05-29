namespace Refactoring.MediatR.Handler.Services;

public interface IService<T> where T : class
{
    Task<T?> AddAsync(T entity, string handlerName, CancellationToken cancellationToken = default);
}