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
}
