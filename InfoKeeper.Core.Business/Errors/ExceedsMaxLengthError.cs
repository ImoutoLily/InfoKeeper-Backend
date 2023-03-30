using InfoKeeper.Core.Business.Abstract.Models;

namespace InfoKeeper.Core.Business.Errors;

public class ExceedsMaxLengthError : IError
{
    public ExceedsMaxLengthError(string className, string propertyName, int maxLength)
    {
        this.Message = $"The {className.ToLower()}'s {propertyName.ToLower()} may " +
                       $"not be longer than {maxLength} characters.";
    }
    
    public int Code => 101;
    public string Message { get; }
}