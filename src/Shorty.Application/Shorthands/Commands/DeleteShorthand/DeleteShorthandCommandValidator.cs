namespace Shorty.Application.Shorthands.Commands.UpdateShorthand;

using FluentValidation;
using Shorty.Application.Shorthands.Commands.DeleteShorthand;

public class DeleteShorthandCommandValidator : AbstractValidator<DeleteShorthandCommand>
{
    public DeleteShorthandCommandValidator()
    {
        this.RuleFor(o => o.Url)
            .NotEmpty()
            .NotNull()
            .Must(o => Uri.IsWellFormedUriString(o, UriKind.RelativeOrAbsolute))
            .WithMessage("Must be a valid Uri.");
    }
}
