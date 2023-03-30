using FluentValidation.Results;
using InfoKeeper.Core.Business.Abstract.Models;

namespace InfoKeeper.Core.Business.Extensions;

public static class ValidationResultExtensions
{
    public static IList<IError> GetCustomErrors(this ValidationResult result)
    {
        return result.Errors
            .Select(x => (IError)x.CustomState)
            .ToList();
    }
}