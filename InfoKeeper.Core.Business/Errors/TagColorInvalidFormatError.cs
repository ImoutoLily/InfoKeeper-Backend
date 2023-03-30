using InfoKeeper.Core.Business.Abstract.Models;

namespace InfoKeeper.Core.Business.Errors;

public class TagColorInvalidFormatError : IError
{
    public int Code => 102;
    public string Message => "The tag's color has an invalid format and " +
                             "should consist of 6 hexadecimal characters only.";
}