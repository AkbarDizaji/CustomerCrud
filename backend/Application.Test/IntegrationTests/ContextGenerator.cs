using Application.Commons.Interfaces;
using Infrastructure.Persistence;
using Infrastructure.Persistence.Interceptors;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Test.IntegrationTests
{
    public class ContextGenerator
    {
        public static IApplicationDbContext Generate(IMediator mediator, AuditableEntitySaveChangesInterceptor saveInterceptor)
        {
            var optionBuilder = new DbContextOptionsBuilder<ApplicationDbContext>()
                                .UseInMemoryDatabase(Guid.NewGuid().ToString());

            return new ApplicationDbContext(optionBuilder.Options, mediator, saveInterceptor);
        }
    }
}
