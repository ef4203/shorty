namespace Shorty.Application.Shorthands.Commands.UpdateShorthand;

using FluentValidation;

[UsedImplicitly]
public sealed class UpdateShorthandCommandValidator : AbstractValidator<UpdateShorthandCommand>
{
    public UpdateShorthandCommandValidator()
    {
        this.RuleFor(x => x.Id)
            .NotEmpty()
            .NotNull()
            .Length(5);

        this.RuleFor(x => x.Destination)
            .NotEmpty()
            .NotNull()
            .Must(o => Uri.IsWellFormedUriString(o, UriKind.Absolute))
            .WithMessage("Must be a valid Uri.");

        this.RuleFor(x => x.ExpiresAfterDays)
            .GreaterThanOrEqualTo(-1)
            .LessThanOrEqualTo(365 * 10);
    }
}
