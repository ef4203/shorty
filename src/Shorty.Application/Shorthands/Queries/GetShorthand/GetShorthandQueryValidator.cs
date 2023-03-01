namespace Shorty.Application.Shorthands.Queries.GetShorthand;

using FluentValidation;

[UsedImplicitly]
public class GetShorthandQueryValidator : AbstractValidator<GetShorthandQuery>
{
    public GetShorthandQueryValidator()
    {
        this.RuleFor(o => o.Id)
            .NotEmpty()
            .NotNull()
            .Length(5);
    }
}
