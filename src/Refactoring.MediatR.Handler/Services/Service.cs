
using Refactoring.MediatR.Handler.Entities;
using Refactoring.MediatR.Handler.Repositories;

namespace Refactoring.MediatR.Handler.Services;

public sealed class Service<T> : IService<T> where T : class
{
    public readonly IRepository<T> _repository;

    public Service(IRepository<T> repository)
    {
        _repository = repository;
    }

    public async Task<T?> AddAsync(T entity, string handlerName, CancellationToken cancellationToken = default)
    {
        if (! await _repository.AddAsync(entity, handlerName, cancellationToken))
            return default;
        
        return entity;
    }

}