using FluentValidation;
using InfoKeeper.Core.Models;

namespace InfoKeeper.Core.Business.Validators;

public class ItemValidator : AbstractValidator<Item>
{
    public ItemValidator()
    {
        RuleFor(x => x.Title).NotEmpty()
            .MaximumLength(100);

        RuleFor(x => x.Content).NotEmpty()
            .MaximumLength(10_000);
    }
}