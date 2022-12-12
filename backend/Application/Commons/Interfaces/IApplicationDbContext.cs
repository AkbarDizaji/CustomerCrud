using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Application.Commons.Interfaces;

public interface IApplicationDbContext
{
    DbSet<Person> Persons { get; }

    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}
