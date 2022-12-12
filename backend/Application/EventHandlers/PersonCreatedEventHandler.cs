using Domain.Events;
using MediatR;
using Microsoft.Extensions.Logging;

namespace CleanArchitecture.Application.TodoItems.EventHandlers;

public class PersonCreatedEventHandler : INotificationHandler<PersonCreatedEvent>
{
    private readonly ILogger<PersonCreatedEventHandler> _logger;

    public PersonCreatedEventHandler(ILogger<PersonCreatedEventHandler> logger)
    {
        _logger = logger;
    }

    public Task Handle(PersonCreatedEvent notification, CancellationToken cancellationToken)
    {
        _logger.LogInformation("Hahn Domain Event: {DomainEvent}", notification.GetType().Name);

        return Task.CompletedTask;
    }

}
