using MediatR;
using Refactoring.MediatR.Handler.Entities;
using Refactoring.MediatR.Handler.Repositories;

namespace Refactoring.MediatR.Handler.Notifications.Handlers;

public class HelloWrongNotificationHandler : INotificationHandler<HelloNotification>
{
    public readonly IRepository<Hello> _repository;

    public HelloWrongNotificationHandler(IRepository<Hello> repository)
    {
        _repository = repository;
    }

    public async Task Handle(HelloNotification request, CancellationToken cancellationToken)
    {
        await _repository.AddAsync(new Hello{ Name = request.Name }, this.GetType().Name, cancellationToken);
    }
}