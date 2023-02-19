namespace Shorty.Application.Shorthands.Commands.UpdateShorthand;

using FluentValidation;
using static Shorty.Application.Shorthands.Commands.UpdateShorthand.UpdateShorthandCommandHandler;

public class UpdateShorthandCommandValidator : AbstractValidator<UpdateShorthandCommand>
{
    public UpdateShorthandCommandValidator()
    {
        this.RuleFor(o => o.Destination)
            .NotEmpty()
            .NotNull()
            .Must(o => Uri.IsWellFormedUriString(o, UriKind.RelativeOrAbsolute))
            .WithMessage("Must be a valid Uri.");
    }
}
