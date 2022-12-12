using Application.Commons.DTOs;
using Application.Commons.Interfaces;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Queries;

public record GetPersonByIdQuery : IRequest<PersonDTO>
{
    public int Id { get; init; }

}
public class GetPersonByIdQueryHandler : IRequestHandler<GetPersonByIdQuery, PersonDTO>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetPersonByIdQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<PersonDTO> Handle(GetPersonByIdQuery request, CancellationToken cancellationToken)
    {
        return await _context.Persons
        .Where(t => t.Id == request.Id)
        .ProjectTo<PersonDTO>(_mapper.ConfigurationProvider)
        .FirstAsync(cancellationToken);
    }
}
