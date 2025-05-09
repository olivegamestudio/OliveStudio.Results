namespace OliveStudio.Results;

public record ErrorObjectResult<T> : ObjectResult<T>
{
    protected internal ErrorObjectResult(T value, string error, int errorCode) : base(value, false, error, errorCode)
    {
        Value = value;
    }

    public static ErrorObjectResult<T> Fail(string message, int errorCode = 0)
    {
        return new ErrorObjectResult<T>(default(T), message, errorCode);
    }
}
