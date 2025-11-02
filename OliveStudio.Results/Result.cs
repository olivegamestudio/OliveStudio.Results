namespace OliveStudio.Results;

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
    /// Gets the errorMessage message associated with the result.
    /// </summary>
    public string ErrorMessage { get; init; }

    /// <summary>
    /// Gets the errorMessage code associated with the result.
    /// </summary>
    public int ErrorCode { get; init; }

    /// <summary>
    /// Defines an implicit conversion to a boolean value.
    /// </summary>
    /// <param name="x">The result to convert.</param>
    /// <returns>True if the result is a success; otherwise, false.</returns>
    public static bool operator true(Result x) => x.Success;

    /// <summary>
    /// Defines an implicit conversion to a boolean value.
    /// </summary>
    /// <param name="x">The result to convert.</param>
    /// <returns>True if the result is a failure; otherwise, false.</returns>
    public static bool operator false(Result x) => x.IsFailure;

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

    static Result Ok() => new OkResult();

    /// <summary>
    /// Initializes a new instance of the <see cref="Result"/> class.
    /// </summary>
    /// <param name="success">A value indicating whether the result is a success.</param>
    /// <param name="errorMessage">The errorMessage message associated with the result.</param>
    /// <param name="errorCode">The errorMessage code associated with the result.</param>
    protected Result(bool success, string errorMessage, int errorCode)
    {
        Success = success;
        ErrorMessage = errorMessage;
        ErrorCode = errorCode;
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="Result"/> class.
    /// </summary>
    /// <param name="success">A value indicating whether the result is a success.</param>
    protected Result(bool success)
    {
        Success = success;
        ErrorMessage = string.Empty;
        ErrorCode = 0;
    }

}
