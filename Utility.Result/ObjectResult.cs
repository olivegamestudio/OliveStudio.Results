namespace Utility;

public record ObjectResult<T> : Result
{
    public T Value { get; set; }

    protected internal ObjectResult(T value, bool success, string error, int errorCode) : base(success, error, errorCode)
    {
        Value = value;
    }
}
