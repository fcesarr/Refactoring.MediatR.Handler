using Microsoft.Extensions.Logging;
using Refactoring.MediatR.Handler.Entities;

namespace Refactoring.MediatR.Handler.Repositories;

public sealed class Repository<T> : IRepository<T> where T : class
{
    private readonly ILogger<Repository<T>> _logger;

    public Repository(ILogger<Repository<T>> logger)
    {
        _logger = logger;
    }

    public async Task<bool> AddAsync(T entity, string handlerName, CancellationToken cancellationToken = default)
    {
        return await Task.Run<bool>(()=> {
            _logger.LogInformation("Hello {name}, from {handlerName}", entity.ToString(), handlerName);

            return true;
        }, cancellationToken);
    }
}