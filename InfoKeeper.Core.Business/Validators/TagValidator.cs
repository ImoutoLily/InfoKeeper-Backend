using FluentValidation;
using InfoKeeper.Core.Business.Errors;
using InfoKeeper.Core.Models;

namespace InfoKeeper.Core.Business.Validators;

public class TagValidator : AbstractValidator<Tag>
{
    public TagValidator()
    {
        RuleFor(x => x.Name).NotEmpty()
            .WithState(_ => new EmptyError(nameof(Tag), nameof(Tag.Name)))
            .MaximumLength(50)
            .WithState(_ => new ExceedsMaxLengthError(nameof(Tag), 
                nameof(Tag.Name), 50));

        RuleFor(x => x.Color).NotEmpty()
            .WithState(_ => new EmptyError(nameof(Tag), nameof(Tag.Color)))
            .Length(6)
            .Must(x => int.TryParse(x, out _))
            .WithState(_ => new TagColorInvalidFormatError());
    }
}