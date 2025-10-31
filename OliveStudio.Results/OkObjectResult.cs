namespace OliveStudio.Results;

public record OkObjectResult<T> : ObjectResult<T>
{
    protected internal OkObjectResult(T value) : base(value, true, string.Empty, 0)
    {
        Value = value;
    }

    /// <summary>
    /// Creates an <see cref="OkObjectResult{T}"/> object that represents a successful response with the
    /// specified value.
    /// </summary>
    /// <param name="value">The value to include in the response body.</param>
    /// <returns>An <see cref="OkObjectResult{T}"/> containing the specified value.</returns>
    public static OkObjectResult<T> Ok(T value) => new(value);
}
