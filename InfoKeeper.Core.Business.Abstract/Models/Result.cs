namespace InfoKeeper.Core.Business.Abstract.Models;

public class Result
{
    public IList<IError> Errors { get; }

    protected Result(IList<IError>? errors = null)
    {
        Errors = errors ?? new List<IError>();
    }
    
    public static Result Ok()
    {
        return new Result();
    }

    public static Result<T> Ok<T>(T value)
    {
        return new Result<T>(value);
    }
    
    public static Result Fail(IList<IError> errors)
    {
        return new Result(errors);
    }
    
    public static Result<T> Fail<T>(IList<IError> errors)
    {
        return new Result<T>(errors);
    }

    public static Result Fail(IError error)
    {
        return new Result(new List<IError>() { error });
    }

    public static Result<T> Fail<T>(IError error)
    {
        return new Result<T>(new List<IError>() { error });
    }
}

public class Result<T> : Result
{
    public T? Value { get; }

    protected internal Result(IList<IError> errors) : base(errors)
    {
    }

    protected internal Result(T value)
    {
        Value = value;
    }
}