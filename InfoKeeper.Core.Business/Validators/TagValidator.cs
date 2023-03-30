using FluentValidation;
using InfoKeeper.Core.Models;

namespace InfoKeeper.Core.Business.Validators;

internal class TagValidator : AbstractValidator<Tag>
{
    public TagValidator()
    {
        RuleFor(x => x.Name).NotEmpty()
            .MaximumLength(50);

        RuleFor(x => x.Color).NotEmpty()
            .Length(6)
            .Must(x => Int32.TryParse(x, out _));
    }
}