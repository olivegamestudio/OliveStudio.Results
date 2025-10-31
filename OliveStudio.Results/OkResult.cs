namespace OliveStudio.Results;

/// <summary>
/// Represents a successful result with no associated value.
/// </summary>
public record OkResult : Result
{
    /// <summary>
    /// Initializes a new instance of the <see cref="OkResult"/> class.
    /// </summary>
    internal OkResult() : base(true)
    {
    }

    /// <summary>
    /// Creates a success result.
    /// </summary>
    /// <returns>A success result.</returns>
    public static OkResult Ok() => new();
}
