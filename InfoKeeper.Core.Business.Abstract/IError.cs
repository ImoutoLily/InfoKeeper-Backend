namespace InfoKeeper.Core.Business.Abstract;

public interface IError
{
    int Code { get; }
    string Message { get; }
}