using Application.Commons.Exceptions;
using Application.Commons.Interfaces;
using Domain.Entities;
using Domain.Events;
using MediatR;

namespace Application.Commands.DeletePerson;

public record DeletePersonCommand(int Id) : IRequest<List<Person>>;

public class DeletePersonCommandHandler : IRequestHandler<DeletePersonCommand,List<Person>>
{
    private readonly IApplicationDbContext _context;

    public DeletePersonCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<List<Person>> Handle(DeletePersonCommand request, CancellationToken cancellationToken)
    {
        var entity = await _context.Persons
            .FindAsync(new object[] { request.Id }, cancellationToken);

        if (entity == null)
        {
            throw new NotFoundException(nameof(Person), request.Id);
        }

        _context.Persons.Remove(entity);

        entity.AddDomainEvent(new PersonDeletedEvent(entity));

        await _context.SaveChangesAsync(cancellationToken);

        return _context.Persons.ToList();
    }
}
