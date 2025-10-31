namespace OliveStudio.Results;

public record ErrorObjectResult<T> : ObjectResult<T>
{
    protected internal ErrorObjectResult(T value, string error, int errorCode) : base(value, false, error, errorCode)
    {
        Value = value;
    }

    /// <summary>
    /// Creates a failed result with the specified error message and error code.
    /// </summary>
    /// <param name="message">The error message describing the failure. Cannot be null or empty.</param>
    /// <param name="errorCode">The error code associated with the failure. Defaults to 0 if not specified.</param>
    /// <returns>An <see cref="ErrorObjectResult{T}"/> representing the failure, with a default value for the object, the
    /// specified error message, and error code.</returns>
    public static ErrorObjectResult<T> Fail(string message, int errorCode = 0) 
        => new(default(T), message, errorCode);
}
