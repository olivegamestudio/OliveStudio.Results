namespace OliveStudio.Results;

public record OkObjectResult<T> : ObjectResult<T>
{
    protected internal OkObjectResult(T value) : base(value, true, string.Empty, 0)
    {
        Value = value;
    }

    public static OkObjectResult<T> Ok(T value)
    {
        return new OkObjectResult<T>(value);
    }
}
