using Application.Commons.Exceptions;
using Application.Commons.Interfaces;
using Domain.Entities;
using MediatR;

namespace Application.Commands.UpdatePerson;

public record UpdatePersonCommand : IRequest<List<Person>>
{
    public int Id { get; init; }

    public string FirstName { get; init; }

    public string LastName { get; init; }
}

public class UpdatePersonCommandHandler : IRequestHandler<UpdatePersonCommand,List<Person>>
{
    private readonly IApplicationDbContext _context;

    public UpdatePersonCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<List<Person>> Handle(UpdatePersonCommand request, CancellationToken cancellationToken)
    {
        var entity = await _context.Persons
            .FindAsync(new object[] { request.Id }, cancellationToken);

        if (entity == null)
        {
            throw new NotFoundException(nameof(Person), request.Id);
        }

        entity.FirstName = request.FirstName;
        entity.LastName = request.LastName;

        await _context.SaveChangesAsync(cancellationToken);

        return _context.Persons.ToList();
    }
}
