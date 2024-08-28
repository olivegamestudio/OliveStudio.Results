using System.Linq.Expressions;

namespace Utility;

/// <summary>
/// A result from a task which can be a success or failure.
/// Where a failure, a reason can be supplied.
/// </summary>
public record Result
{
    /// <summary>
    /// Gets a value indicating whether the result is a success.
    /// </summary>
    public bool Success { get; }

    /// <summary>
    /// Gets a value indicating whether the result is a failure.
    /// </summary>
    public bool IsFailure => !Success;

    /// <summary>
    /// Gets the error message associated with the result.
    /// </summary>
    public string Error { get; private set; }

    /// <summary>
    /// Gets the error code associated with the result.
    /// </summary>
    public int ErrorCode { get; private set; }

    /// <summary>
    /// Defines an implicit conversion to a boolean value.
    /// </summary>
    /// <param name="x">The result to convert.</param>
    /// <returns>True if the result is a success; otherwise, false.</returns>
    public static bool operator true(Result x)
    {
        return x.Success;
    }

    /// <summary>
    /// Defines an implicit conversion to a boolean value.
    /// </summary>
    /// <param name="x">The result to convert.</param>
    /// <returns>True if the result is a failure; otherwise, false.</returns>
    public static bool operator false(Result x)
    {
        return x.IsFailure;
    }

    /// <summary>
    /// Combines two results using a logical AND operation.
    /// </summary>
    /// <param name="lhs">The left-hand side result.</param>
    /// <param name="rhs">The right-hand side result.</param>
    /// <returns>The combined result.</returns>
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

    /// <summary>
    /// Initializes a new instance of the <see cref="Result"/> class.
    /// </summary>
    /// <param name="success">A value indicating whether the result is a success.</param>
    /// <param name="error">The error message associated with the result.</param>
    /// <param name="errorCode">The error code associated with the result.</param>
    protected Result(bool success, string error, int errorCode)
    {
        Success = success;
        Error = error;
        ErrorCode = errorCode;
    }

    /// <summary>
    /// Creates a failure result with the specified error message and error code.
    /// </summary>
    /// <param name="message">The error message.</param>
    /// <param name="errorCode">The error code (optional).</param>
    /// <returns>A failure result.</returns>
    public static Result Fail(string message, int errorCode = 0)
    {
        return new Result(false, message, errorCode);
    }

    /// <summary>
    /// Creates a failure result with the specified error message and error code.
    /// </summary>
    /// <typeparam name="T">The type of the value associated with the result.</typeparam>
    /// <param name="message">The error message.</param>
    /// <param name="errorCode">The error code (optional).</param>
    /// <returns>A failure result.</returns>
    public static Result<T> Fail<T>(string message, int errorCode = 0)
    {
        return new Result<T>(default(T), false, message, errorCode);
    }

    /// <summary>
    /// Creates a success result.
    /// </summary>
    /// <returns>A success result.</returns>
    public static Result Ok()
    {
        return new Result(true, string.Empty, 0);
    }

    /// <summary>
    /// Creates a success result with the specified value.
    /// </summary>
    /// <typeparam name="T">The type of the value associated with the result.</typeparam>
    /// <param name="value">The value associated with the result.</param>
    /// <returns>A success result.</returns>
    public static Result<T> Ok<T>(T value)
    {
        return new Result<T>(value, true, string.Empty, 0);
    }
}

/// <summary>
/// A result from a task which can be a success or failure, with an associated value.
/// </summary>
/// <typeparam name="T">The type of the value associated with the result.</typeparam>
public record Result<T> : Result
{
    /// <summary>
    /// Gets or sets the value associated with the result.
    /// </summary>
    public T Value { get; set; }

    /// <summary>
    /// Initializes a new instance of the <see cref="Result{T}"/> class.
    /// </summary>
    /// <param name="value">The value associated with the result.</param>
    /// <param name="success">A value indicating whether the result is a success.</param>
    /// <param name="error">The error message associated with the result.</param>
    /// <param name="errorCode">The error code associated with the result.</param>
    protected internal Result(T value, bool success, string error, int errorCode) : base(success, error, errorCode)
    {
        Value = value;
    }
}
