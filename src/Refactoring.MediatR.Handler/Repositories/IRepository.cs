namespace Refactoring.MediatR.Handler.Repositories;

public interface IRepository<T> where T : class
{
    Task<bool> AddAsync(T entity, string handlerName, CancellationToken cancellationToken = default);
}