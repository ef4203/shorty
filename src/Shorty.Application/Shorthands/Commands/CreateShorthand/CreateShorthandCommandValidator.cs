namespace Shorty.Application.Shorthands.Commands.CreateShorthand;

using FluentValidation;

public class CreateShorthandCommandValidator : AbstractValidator<CreateShorthandCommand>
{
    public CreateShorthandCommandValidator()
    {
        this.RuleFor(o => o.Destination)
            .NotEmpty()
            .NotNull()
            .Must(o => Uri.IsWellFormedUriString(o, UriKind.Absolute))
            .WithMessage("Must be a valid Uri.");
    }
}
