using FluentValidation;
using Mentor.Application.Subject.Commands;

namespace Mentor.Application.Common.Validators;

public class AddSubjectCommandValidator : AbstractValidator<AddSubjectCommand>
{
    public AddSubjectCommandValidator()
    {
        RuleFor(command => command.SubjectId)
            .GreaterThan(0);

        RuleFor(command => command.Name)
            .NotEmpty()
            .MinimumLength(3)
            .MaximumLength(50)
            .Matches("^[^0-9]*$");

        RuleFor(command => command.Description)
            .MinimumLength(3)
            .MaximumLength(200);

        RuleFor(command => command.Type)
            .NotEmpty()
            .MinimumLength(3)
            .MaximumLength(20);
        
    }
}