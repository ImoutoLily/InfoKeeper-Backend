using FluentValidation;
using InfoKeeper.Core.Business.Errors;
using InfoKeeper.Core.Models;

namespace InfoKeeper.Core.Business.Validators;

public class ItemValidator : AbstractValidator<Item>
{
    public ItemValidator()
    {
        RuleFor(x => x.Title).NotEmpty()
            .WithState(_ => new EmptyError(nameof(Item), nameof(Item.Title)))
            .MaximumLength(100)
            .WithState(_ => new ExceedsMaxLengthError(nameof(Item), 
                nameof(Item.Title), 100));

        RuleFor(x => x.Content).NotEmpty()
            .WithState(_ => new EmptyError(nameof(Item), nameof(Item.Content)))
            .MaximumLength(10_000)
            .WithState(_ => new ExceedsMaxLengthError(nameof(Item), 
                nameof(Item.Content), 10_000));
    }
}