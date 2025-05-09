using Xunit;

namespace OliveStudio.Results.Tests;

public class ObjectResultTests
{
    [Fact]
    public void Ok_Result_WithValue_Returns_Success()
    {
        ObjectResult<int> result = OkObjectResult<int>.Ok(99);

        Assert.Equal(99, result.Value);
        Assert.True(result.Success);
        Assert.Equal(string.Empty, result.Error);
        Assert.Equal(0, result.ErrorCode);
    }

    public Result ReturnOkResult()
    {
        return OkResult.Ok();
    }

    public ObjectResult<int> ReturnIntegerResult()
    {
        ObjectResult<int> result = OkObjectResult<int>.Ok(100);
        return result;
    }

    public Task<Result> ReturnResultForTask()
    {
        return Task.FromResult<Result>(OkResult.Ok());
    }

    public Result ReturnFailure()
    {
        return ErrorResult.Fail("This function has failed because of...");
    }
}
