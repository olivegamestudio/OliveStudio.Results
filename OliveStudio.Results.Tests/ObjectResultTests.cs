namespace OliveStudio.Results.Tests;

public class ObjectResultTests
{
    [Test]
    public void Ok_Result_WithValue_Returns_Success()
    {
        ObjectResult<int> result = OkObjectResult<int>.Ok(99);

        Assert.AreEqual(99, result.Value);
        Assert.IsTrue(result.Success);
        Assert.AreEqual(string.Empty, result.Error);
        Assert.AreEqual(0, result.ErrorCode);
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
