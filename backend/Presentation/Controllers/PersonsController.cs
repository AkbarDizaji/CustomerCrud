using Application.Commands.CreatePerson;
using Application.Commands.DeletePerson;
using Application.Commands.UpdatePerson;
using Application.Commons.DTOs;
using Application.Queries;
using Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace Presentation.Controllers;

public class PersonController : ApiControllerBase
{
    [HttpGet]
    public async Task<ActionResult<List<PersonDTO>>> Get()
    {
        return await Mediator.Send(new GetPersonsQuery());
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<PersonDTO>> Get(int id)
    {
        return await Mediator.Send(new GetPersonByIdQuery { Id = id });
    }

    [HttpPost]
    public async Task<ActionResult<List<Person>>> Create(CreatePersonCommand command)
    {
        return Ok(await Mediator.Send(command));
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<List<Person>>> Update(int id, UpdatePersonCommand command)
    {
        if (id != command.Id)
        {
            return BadRequest();
        }
        return Ok(await Mediator.Send(command));
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<List<Person>>> Delete(int id)
    {
        return Ok(await Mediator.Send(new DeletePersonCommand(id)));

    }
}
