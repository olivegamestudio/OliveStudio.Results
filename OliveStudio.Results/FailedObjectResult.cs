namespace OliveStudio.Results;

public record FailedObjectResult<T> : ObjectResult<T>
{
    protected internal FailedObjectResult(T value, string errorMessage, int errorCode) : base(value, false, errorMessage, errorCode)
    {
        Value = value;
    }

    /// <summary>
    /// Creates a failed result with the specified errorMessage message and errorMessage code.
    /// </summary>
    /// <param name="errorMessage">The errorMessage message describing the failure. Cannot be null or empty.</param>
    /// <param name="errorCode">The errorMessage code associated with the failure. Defaults to 0 if not specified.</param>
    /// <returns>An <see cref="FailedObjectResult{T}"/> representing the failure, with a default value for the object, the
    /// specified errorMessage message, and errorMessage code.</returns>
    public static FailedObjectResult<T> Fail(string errorMessage, int errorCode = 0) 
        => new(default(T), errorMessage, errorCode);
}
