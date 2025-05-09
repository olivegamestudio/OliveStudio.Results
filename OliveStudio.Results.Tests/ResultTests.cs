using Xunit;

namespace OliveStudio.Results.Tests;

public class ResultTests
{
    [Fact]
    public void OperatorAnd_Result_Returns_Success()
    {
        Result result = ErrorResult.Fail("Failed") && OkResult.Ok();
        Assert.True(result.IsFailure);

        result = OkResult.Ok() && ErrorResult.Fail("Failed");
        Assert.True(result.IsFailure);
    }

    [Fact]
    public void Ok_Result_Returns_Success()
    {
        Result result = OkResult.Ok();

        Assert.True(result.Success);
        Assert.Equal(string.Empty, result.Error);
        Assert.Equal(0, result.ErrorCode);
    }

    [Fact]
    public void Fail_Result_Returns_Failure()
    {
        Result result = ErrorResult.Fail("The operation failed because of ...");

        Assert.True(result.IsFailure);
        Assert.Equal(-1, result.ErrorCode);
    }

    [Fact]
    public void Fail_Result_WithErrorCode_Returns_Failure()
    {
        Result result = ErrorResult.Fail("The operation failed because of ...", -1);

        Assert.True(result.IsFailure);
        Assert.Equal(-1, result.ErrorCode);
    }
}
