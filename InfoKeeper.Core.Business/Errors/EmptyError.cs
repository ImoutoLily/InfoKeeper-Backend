using InfoKeeper.Core.Business.Abstract.Models;

namespace InfoKeeper.Core.Business.Errors;

public class EmptyError : IError
{
    public EmptyError(string className, string propertyName)
    {
        Message = $"the {className.ToLower()}'s {propertyName.ToLower()} must not be empty.";
    }

    public int Code => 100;
    public string Message { get; }
}