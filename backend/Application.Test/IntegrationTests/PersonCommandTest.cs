using Application.Commands.CreatePerson;
using Application.Commands.DeletePerson;
using Application.Commands.UpdatePerson;
using Application.Commons.Exceptions;
using Application.Commons.Interfaces;
using Application.Commons.Mappings;
using Application.Test.IntegrationTests;
using AutoMapper;
using Domain.Entities;
using Infrastructure.Persistence;
using Infrastructure.Persistence.Interceptors;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Xunit;

namespace Test.Application.IntegrationTests
{
    public class PersonCommandTest
    {
        private readonly IMapper mapper;
        private readonly IConfigurationProvider _configuration;
        IApplicationDbContext dbContext;
        public PersonCommandTest()
        {
            _configuration = new MapperConfiguration(config =>
                        config.AddProfile<MappingProfile>());
            mapper = _configuration.CreateMapper();
            AuditableEntitySaveChangesInterceptor _auditableEntitySaveChangesInterceptor 
                = new AuditableEntitySaveChangesInterceptor();
            var mediator = new Mock<IMediator>();
            dbContext = ContextGenerator.Generate(mediator.Object,_auditableEntitySaveChangesInterceptor);
        }

        [Fact]
        public void CreatePersonCommand_update_success()
        {
            var command = new CreatePersonCommand() { FirstName="Akbar",LastName="Dizaji"};
            var handler = new CreatePersonCommandHandler(dbContext);
            var result = handler.Handle(command, new CancellationToken()).GetAwaiter().GetResult();
            Assert.IsType<int>(result);
        }

        [Fact]
        public void CreatePersonCommand_throw_exception_in_emptyFields()
        {
            var command = new CreatePersonCommand() { 
                FirstName= "Akbar", LastName=null};
            var handler = new CreatePersonCommandHandler(dbContext);
            Assert.Throws<DbUpdateException>(()=> handler.Handle(command, new CancellationToken()).GetAwaiter().GetResult());
        }

        [Fact]
        public void DeletePersonCommand_delete_success()
        {
            var person = new Person() { FirstName = "Akbar", LastName = "Dizaji" };
            dbContext.Persons.Add(person);
            dbContext.SaveChangesAsync(new CancellationToken()).GetAwaiter().GetResult();
            var command = new DeletePersonCommand(person.Id);
            var handler = new DeletePersonCommandHandler(dbContext);
            var result = handler.Handle(command, new CancellationToken()).GetAwaiter().GetResult();
            Assert.IsType<Unit>(result);
        }

        [Fact]
        public void DeletePersonCommand_throw_exception_in_notFound()
        {
            var person = new Person() { FirstName = "Akbar", LastName = "Dizaji" };
            dbContext.Persons.Add(person);
            dbContext.SaveChangesAsync(new CancellationToken()).GetAwaiter().GetResult();
            var command = new UpdatePersonCommand() { Id=-1,FirstName="a",LastName="b"};
            var handler = new UpdatePersonCommandHandler(dbContext);
            Assert.Throws<NotFoundException>(() => handler.Handle(command, new CancellationToken()).GetAwaiter().GetResult());
        }
        [Fact]
        public void UpdatePersonCommand_add_success()
        {
            var person = new Person() { FirstName = "Akbar", LastName = "Dizaji" };
            dbContext.Persons.Add(person);
            dbContext.SaveChangesAsync(new CancellationToken()).GetAwaiter().GetResult();
            var command = new UpdatePersonCommand() { Id = person.Id, FirstName = "editedName", LastName = "Dizaji" };
            var handler = new UpdatePersonCommandHandler(dbContext);
            var result = handler.Handle(command, new CancellationToken()).GetAwaiter().GetResult();
            Assert.IsType<Unit>(result);
        }

        [Fact]
        public void UpdatePersonCommand_throw_exception_in_notFound()
        {
            var person = new Person() { FirstName = "Akbar", LastName = "Dizaji" };
            dbContext.Persons.Add(person);
            dbContext.SaveChangesAsync(new CancellationToken()).GetAwaiter().GetResult();
            var command = new UpdatePersonCommand() { Id=-1,FirstName="a",LastName="b"};
            var handler = new UpdatePersonCommandHandler(dbContext);
            Assert.Throws<NotFoundException>(() => handler.Handle(command, new CancellationToken()).GetAwaiter().GetResult());
        }
    }
}
