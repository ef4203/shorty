namespace Shorty.Application.Shorthands.Queries.GetShorthand;

using FluentValidation;

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
