using System.Reflection;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Refactoring.MediatR.Handler.Notifications;
using Refactoring.MediatR.Handler.Entities;
using Refactoring.MediatR.Handler.Notifications.Handlers;
using Refactoring.MediatR.Handler.Repositories;
using Refactoring.MediatR.Handler.Services;

var serviceProvider = new ServiceCollection()
    .AddLogging(loggingBuilder =>
    {
        loggingBuilder.AddConsole();
        loggingBuilder.SetMinimumLevel(LogLevel.Information);
    })
    .AddTransient<IRepository<Hello>, Repository<Hello>>()
    .AddTransient<IService<Hello>, Service<Hello>>()
    .AddMediatR(cfg => {
        cfg.RegisterServicesFromAssembly(typeof(HelloNotificationHandler).Assembly)
            .RegisterServicesFromAssembly(typeof(HelloWrongNotificationHandler).Assembly);
        
    })
    .BuildServiceProvider();

 var logger = serviceProvider.GetRequiredService<ILogger<Program>>();

logger.LogInformation("Application started");

var mediator = serviceProvider.GetRequiredService<IMediator>();

var notification = new HelloNotification("Fernando");

await mediator.Publish(notification);

logger.LogInformation("Application finished");
    