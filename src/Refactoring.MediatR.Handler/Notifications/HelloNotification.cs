using MediatR;

namespace Refactoring.MediatR.Handler.Notifications;

public record HelloNotification(string Name) : INotification;