namespace OliveStudio.Results;

/// <summary>
/// Represents an errorMessage result with an associated errorMessage message and errorMessage code.
/// </summary>
public record FailedResult : Result
{
    /// <summary>
    /// Initializes a new instance of the <see cref="FailedResult"/> class.
    /// </summary>
    /// <param name="errorMessage">The errorMessage message associated with the result.</param>
    /// <param name="errorCode">The errorMessage code associated with the result (optional).</param>
    internal FailedResult(string errorMessage, int errorCode = -1) : base(false, errorMessage, errorCode)
    {
    }

    /// <summary>
    /// Creates a failure result with the specified errorMessage message and errorMessage code.
    /// </summary>
    /// <param name="errorMessage">The errorMessage message.</param>
    /// <param name="errorCode">The errorMessage code (optional).</param>
    /// <returns>An errorMessage result.</returns>
    public static FailedResult Fail(string errorMessage, int errorCode = -1) => new(errorMessage, errorCode);
}
