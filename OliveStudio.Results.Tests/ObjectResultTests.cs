using FluentAssertions;
using FsCheck.Xunit;

namespace OliveStudio.Results.Tests;

public class ObjectResultTests
{
    [Property]
    public void Ok_Result_WithValue_Returns_Success(int resultValue)
    {
        ObjectResult<int> result = OkObjectResult<int>.Ok(resultValue);

        result.Value.Should().Be(resultValue);
        result.Success.Should().BeTrue();
        result.ErrorMessage.Should().BeEmpty();
        result.ErrorCode.Should().Be(0);
    }

    public Result ReturnOkResult() => OkResult.Ok();

    public ObjectResult<int> ReturnIntegerResult()
    {
        ObjectResult<int> result = OkObjectResult<int>.Ok(100);
        return result;
    }

    public Task<Result> ReturnResultForTask() => Task.FromResult<Result>(OkResult.Ok());

    public Result ReturnFailure()
    {
        return FailedResult.Fail("This function has failed because of...");
    }
}
