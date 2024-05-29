
using MediatR;
using Refactoring.MediatR.Handler.Entities;
using Refactoring.MediatR.Handler.Services;

namespace Refactoring.MediatR.Handler.Notifications.Handlers;

public class HelloNotificationHandler : INotificationHandler<HelloNotification>
{
    public readonly IService<Hello> _service;

    public HelloNotificationHandler(IService<Hello> service)
    {
        _service = service;
    }

    public async Task Handle(HelloNotification request, CancellationToken cancellationToken)
    {
        await _service.AddAsync(new Hello{ Name = request.Name }, this.GetType().Name, cancellationToken);
    }
}