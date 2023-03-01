namespace Shorty.Application.Shorthands.Commands.CreateShorthand;

using FluentValidation;

[UsedImplicitly]
public sealed class CreateShorthandCommandValidator : AbstractValidator<CreateShorthandCommand>
{
    public CreateShorthandCommandValidator()
    {
        this.RuleFor(o => o.Destination)
            .NotEmpty()
            .NotNull()
            .Must(o => Uri.IsWellFormedUriString(o, UriKind.Absolute))
            .WithMessage("Must be a valid Uri.");

        this.RuleFor(x => x.ExpiresAfterDays)
            .GreaterThanOrEqualTo(-1)
            .LessThanOrEqualTo(365 * 10);
    }
}
