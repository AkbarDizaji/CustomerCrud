using Application.Commons.Interfaces;
using Domain.Entities;
using Domain.Events;
using MediatR;

namespace Application.Commands.CreatePerson;

public record CreatePersonCommand : IRequest<List<Person>>
{
    public string FirstName { get; init; }

    public string LastName { get; init; }
}

public class CreatePersonCommandHandler : IRequestHandler<CreatePersonCommand, List<Person>>
{
    private readonly IApplicationDbContext _context;

    public CreatePersonCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<List<Person>> Handle(CreatePersonCommand request, CancellationToken cancellationToken)
    {
        var entity = new Person
        {
            FirstName = request.FirstName,
            LastName = request.LastName
        };

        entity.AddDomainEvent(new PersonCreatedEvent(entity));

        _context.Persons.Add(entity);

        await _context.SaveChangesAsync(cancellationToken);

        return _context.Persons.ToList();
    }
}
