using Musts;

namespace Utility;

public class ResultTests
{
    [Test]
    public void OperatorAnd_Result_Returns_Success()
    {
        Result result = Result.Ok() && Result.Ok();
        result.MustBeSuccess();

        result = Result.Fail("Failed") && Result.Ok();
        result.MustBeFailure();

        result = Result.Ok() && Result.Fail("Failed");
        result.MustBeFailure();
    }

    [Test]
    public void Ok_Result_Returns_Success()
    {
        Result result = Result.Ok();

        result.MustBeSuccess();
        result.Error.MustBeNullOrEmpty();
        result.ErrorCode.MustBeZero();
    }

    [Test]
    public void Ok_Result_WithValue_Returns_Success()
    {
        Result<int> result = Result.Ok(99);

        result.Value.MustBeEqual(99);
        result.MustBeSuccess();
        result.Error.MustBeNullOrEmpty();
        result.ErrorCode.MustBeZero();
    }

    [Test]
    public void Fail_Result_Returns_Failure()
    {
        Result result = Result.Fail("The operation failed because of ...");

        result.MustBeFailure();
        result.ErrorCode.MustBeZero();
    }

    [Test]
    public void Fail_Result_WithErrorCode_Returns_Failure()
    {
        Result result = Result.Fail("The operation failed because of ...", -1);

        result.MustBeFailure();
        result.ErrorCode.MustBeEqual(-1);
    }
}
