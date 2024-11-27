using Musts;

namespace Utility;

public class ObjectResultTests
{
    [Test]
    public void Ok_Result_WithValue_Returns_Success()
    {
        ObjectResult<int> result = OkObjectResult<int>.Ok(99);

        result.Value.MustBeEqual(99);
        result.MustBeSuccess();
        result.Error.MustBeNullOrEmpty();
        result.ErrorCode.MustBeZero();
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
