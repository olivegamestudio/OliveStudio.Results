namespace Utility;

/// <summary>
/// A result from a task which can be a success or failure.
/// Where a failure, a reason can be supplied.
/// </summary>
public record Result
{
    public bool Success { get; }

    public bool IsFailure => !Success;

    public string Error { get; private set; }

    protected Result(bool success, string error)
    {
        Success = success;
        Error = error;
    }

    public static Result Fail(string message)
    {
        return new Result(false, message);
    }

    public static Result<T> Fail<T>(string message)
    {
        return new Result<T>(default(T), false, message);
    }

    public static Result Ok()
    {
        return new Result(true, string.Empty);
    }

    public static Result<T> Ok<T>(T value)
    {
        return new Result<T>(value, true, string.Empty);
    }
}

public record Result<T> : Result
{
    public T Value { get; set; }

    protected internal Result(T value, bool success, string error) : base(success, error)
    {
        Value = value;
    }
}
