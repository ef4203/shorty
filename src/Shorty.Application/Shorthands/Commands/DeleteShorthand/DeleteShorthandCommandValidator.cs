namespace Shorty.Application.Shorthands.Commands.DeleteShorthand;

using FluentValidation;

[UsedImplicitly]
public sealed class DeleteShorthandCommandValidator : AbstractValidator<DeleteShorthandCommand>
{
    public DeleteShorthandCommandValidator()
    {
        this.RuleFor(x => x.Id)
            .NotEmpty()
            .NotNull()
            .Length(5);
    }
}
