namespace Utility;

/// <summary>
/// Represents an error result with an associated error message and error code.
/// </summary>
public record ErrorResult : Result
{
    /// <summary>
    /// Initializes a new instance of the <see cref="ErrorResult"/> class.
    /// </summary>
    /// <param name="error">The error message associated with the result.</param>
    /// <param name="errorCode">The error code associated with the result (optional).</param>
    internal ErrorResult(string error, int errorCode = -1) : base(false, error, errorCode)
    {
    }

    /// <summary>
    /// Creates a failure result with the specified error message and error code.
    /// </summary>
    /// <param name="message">The error message.</param>
    /// <param name="errorCode">The error code (optional).</param>
    /// <returns>An error result.</returns>
    public static ErrorResult Fail(string message, int errorCode = -1)
    {
        return new ErrorResult(message, errorCode);
    }
}
