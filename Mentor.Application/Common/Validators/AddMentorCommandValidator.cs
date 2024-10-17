using FluentValidation;
using Mentor.Application.Commands;

namespace Mentor.Application.Common.Validators;

public class AddMentorCommandValidator : AbstractValidator<AddMentorCommand>
{
    public AddMentorCommandValidator()
    {
        RuleFor(command => command.FirstName)
            .NotEmpty()
            .MinimumLength(3)
            .MaximumLength(15)
            .Matches(@"^[a-zA-Z]+$");

        RuleFor(command => command.LastName)
            .NotEmpty()
            .MinimumLength(3)
            .MaximumLength(15)
            .Matches(@"^[a-zA-Z]+$");
    }
}