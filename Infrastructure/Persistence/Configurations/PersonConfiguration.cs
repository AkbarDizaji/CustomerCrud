using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Configurations;

public class PersonConfiguration : IEntityTypeConfiguration<Person>
{
    public void Configure(EntityTypeBuilder<Person> builder)
    {
        builder.Property(t => t.FirstName)
            .HasMaxLength(200)
            .IsRequired();
        builder.Property(t => t.LastModified)
            .HasMaxLength(200)
            .IsRequired();
    }
}
