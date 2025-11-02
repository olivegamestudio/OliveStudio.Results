using FluentAssertions;
using Xunit;

namespace OliveStudio.Results.Tests;

public class ResultTests
{
    [Fact]
    public void OperatorAnd_Result_Returns_Success()
    {
        Result result = FailedResult.Fail("Failed") && OkResult.Ok();
        result.IsFailure.Should().BeTrue();

        result = OkResult.Ok() && FailedResult.Fail("Failed");
        result.IsFailure.Should().BeTrue();
    }

    [Fact]
    public void Ok_Result_Returns_Success()
    {
        Result result = OkResult.Ok();

        result.Success.Should().BeTrue();
        result.ErrorMessage.Should().BeEmpty();
        result.ErrorCode.Should().Be(0);
    }

    [Fact]
    public void Fail_Result_Returns_Failure()
    {
        Result result = FailedResult.Fail("The operation failed because of ...");

        result.IsFailure.Should().BeTrue();
        result.ErrorCode.Should().Be(-1);
    }

    [Fact]
    public void Fail_Result_WithErrorCode_Returns_Failure()
    {
        Result result = FailedResult.Fail("The operation failed because of ...", -1);

        result.IsFailure.Should().BeTrue();
        result.ErrorCode.Should().Be(-1);
    }
}
