using System.Linq.Expressions;

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

    public int ErrorCode { get; private set; }

    public static bool operator true(Result x)
    {
        return x.Success;
    }

    public static bool operator false(Result x)
    {
        return x.IsFailure;
    }

    public static Result operator &(Result lhs, Result rhs)
    {
        if (lhs.Success && rhs.Success)
        {
            return Result.Ok();
        }

        if (lhs.IsFailure)
        {
            return lhs;
        }

        if (rhs.IsFailure)
        {
            return rhs;
        }

        return Result.Ok();
    }

    protected Result(bool success, string error, int errorCode)
    {
        Success = success;
        Error = error;
        ErrorCode = errorCode;
    }

    public static Result Fail(string message, int errorCode = 0)
    {
        return new Result(false, message, errorCode);
    }

    public static Result<T> Fail<T>(string message, int errorCode = 0)
    {
        return new Result<T>(default(T), false, message, errorCode);
    }

    public static Result Ok()
    {
        return new Result(true, string.Empty, 0);
    }

    public static Result<T> Ok<T>(T value)
    {
        return new Result<T>(value, true, string.Empty, 0);
    }
}

public record Result<T> : Result
{
    public T Value { get; set; }

    protected internal Result(T value, bool success, string error, int errorCode) : base(success, error, errorCode)
    {
        Value = value;
    }
}
