namespace Utility;

public class ResultTests
{
    [Test]
    public void OperatorAnd_Result_Returns_Success()
    {
        Result result = Result.Ok() && Result.Ok();
        Assert.IsTrue(result.Success);

        result = Result.Fail("Failed") && Result.Ok();
        Assert.IsTrue(result.IsFailure);

        result = Result.Ok() && Result.Fail("Failed");
        Assert.IsTrue(result.IsFailure);
    }

    [Test]
    public void Ok_Result_Returns_Success()
    {
        Result result = Result.Ok();

        Assert.IsTrue(result.Success);
        Assert.IsFalse(result.IsFailure);
        Assert.IsTrue(string.IsNullOrEmpty(result.Error));
        Assert.That(0, Is.EqualTo(result.ErrorCode));
    }

    [Test]
    public void Ok_Result_WithValue_Returns_Success()
    {
        Result<int> result = Result.Ok(99);

        Assert.IsTrue(result.Value == 99);
        Assert.IsTrue(result.Success);
        Assert.IsFalse(result.IsFailure);
        Assert.IsTrue(string.IsNullOrEmpty(result.Error));
        Assert.That(0, Is.EqualTo(result.ErrorCode));
    }

    [Test]
    public void Fail_Result_Returns_Failure()
    {
        Result result = Result.Fail("The operation failed because of ...");

        Assert.IsTrue(result.IsFailure);
        Assert.IsFalse(result.Success);
        Assert.IsFalse(string.IsNullOrEmpty(result.Error));
        Assert.That(0, Is.EqualTo(result.ErrorCode));
    }

    [Test]
    public void Fail_Result_WithErrorCode_Returns_Failure()
    {
        Result result = Result.Fail("The operation failed because of ...", -1);

        Assert.IsTrue(result.IsFailure);
        Assert.IsFalse(result.Success);
        Assert.IsFalse(string.IsNullOrEmpty(result.Error));
        Assert.That(-1, Is.EqualTo(result.ErrorCode));
    }

}
