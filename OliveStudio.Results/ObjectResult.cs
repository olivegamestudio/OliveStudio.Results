namespace OliveStudio.Results;

public record ObjectResult<T> : Result
{
    /// <summary>
    /// Gets the value of the current instance. This property is immutable and can only be set during initialization.
    /// </summary>
    public T Value { get; init; }

    protected internal ObjectResult(T value, bool success, string error, int errorCode) : base(success, error, errorCode)
    {
        Value = value;
    }
}
