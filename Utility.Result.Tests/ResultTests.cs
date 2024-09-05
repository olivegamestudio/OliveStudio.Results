using Musts;

namespace Utility;

public class ResultTests
{
    [Test]
    public void OperatorAnd_Result_Returns_Success()
    {
        Result result = ErrorResult.Fail("Failed") && OkResult.Ok();
        result.MustBeFailure();

        result = OkResult.Ok() && ErrorResult.Fail("Failed");
        result.MustBeFailure();
    }

    [Test]
    public void Ok_Result_Returns_Success()
    {
        Result result = OkResult.Ok();

        result.MustBeSuccess();
        result.Error.MustBeNullOrEmpty();
        result.ErrorCode.MustBeZero();
    }

    [Test]
    public void Fail_Result_Returns_Failure()
    {
        Result result = ErrorResult.Fail("The operation failed because of ...");

        result.MustBeFailure();
        result.ErrorCode.MustBeEqual(-1);
    }

    [Test]
    public void Fail_Result_WithErrorCode_Returns_Failure()
    {
        Result result = ErrorResult.Fail("The operation failed because of ...", -1);

        result.MustBeFailure();
        result.ErrorCode.MustBeEqual(-1);
    }
}
