namespace WetBusinessApp.Domain.ValueObjects;

public class Result
{
    public bool IsSuccess { get;}
    public string Error { get; }

    protected Result(bool isSuccess, string error)
    {
        IsSuccess = isSuccess;
        Error = error;
    }
    
    public static Result Ok() => new Result(true, string.Empty);
    
    public static Result Fail(string error) => new Result(false, error);
    
}

public class Result<T>:Result
{
    public T Value { get; }
    private Result(bool isSuccess, T value, string error): base(isSuccess, error)
    {
        Value = value;
    }
    public static Result<T> Ok(T value) => new Result<T>(true, value, null);
    public static Result<T> Fail(string error) => new Result<T>(false, default, error);
}