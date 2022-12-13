using Application.Commands.CreatePerson;
using FluentValidation;

namespace CleanArchitecture.Application.TodoItems.Commands.CreateTodoItem;

public class CreatePersonCommandValidator : AbstractValidator<CreatePersonCommand>
{
    public CreatePersonCommandValidator()
    {
        RuleFor(v => v.FirstName)
            .MaximumLength(100)
            .NotEmpty();
        RuleFor(v => v.LastName)
            .MaximumLength(100)
            .NotEmpty();
    }
}
