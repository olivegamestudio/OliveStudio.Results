namespace OliveStudio.Results.Tests;

public class ResultTests
{
    [Test]
    public void OperatorAnd_Result_Returns_Success()
    {
        Result result = ErrorResult.Fail("Failed") && OkResult.Ok();
        Assert.IsTrue(result.IsFailure);

        result = OkResult.Ok() && ErrorResult.Fail("Failed");
        Assert.IsTrue(result.IsFailure);
    }

    [Test]
    public void Ok_Result_Returns_Success()
    {
        Result result = OkResult.Ok();

        Assert.IsTrue(result.Success);
        Assert.AreEqual(string.Empty, result.Error);
        Assert.AreEqual(0, result.ErrorCode);
    }

    [Test]
    public void Fail_Result_Returns_Failure()
    {
        Result result = ErrorResult.Fail("The operation failed because of ...");

        Assert.IsTrue(result.IsFailure);
        Assert.AreEqual(-1, result.ErrorCode);
    }

    [Test]
    public void Fail_Result_WithErrorCode_Returns_Failure()
    {
        Result result = ErrorResult.Fail("The operation failed because of ...", -1);

        Assert.IsTrue(result.IsFailure);
        Assert.AreEqual(-1, result.ErrorCode);
    }
}
