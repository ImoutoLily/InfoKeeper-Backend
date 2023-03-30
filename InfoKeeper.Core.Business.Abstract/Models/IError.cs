namespace InfoKeeper.Core.Business.Abstract.Models;

public interface IError
{
    int Code { get; }
    string Message { get; }
}