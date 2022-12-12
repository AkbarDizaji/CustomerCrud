using Application.Commons.DTOs;
using Application.Commons.Interfaces;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Queries;

public record GetPersonsQuery : IRequest<List<PersonDTO>>;
public class GetPersonsQueryHandler : IRequestHandler<GetPersonsQuery, List<PersonDTO>>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetPersonsQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<List<PersonDTO>> Handle(GetPersonsQuery request, CancellationToken cancellationToken)
    {
        return await _context.Persons
            .AsNoTracking()
            .ProjectTo<PersonDTO>(_mapper.ConfigurationProvider)
            .OrderBy(x => x.FirstName)
            .ToListAsync(cancellationToken);
    }
}
