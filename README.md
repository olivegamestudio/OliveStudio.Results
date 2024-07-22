# Result (Utility Library)

A utility library with Result and Result<T> type. This type provides a means to return success or failure and a value. Great for avoiding throwing exceptions which are expensive.

## Usage Examples

### Returning a successful result from a function.

```
Result Method()
{
    return Result.Ok();
}
```

### Returning a successful result and value from a function.

```
Result<int> Method()
{
    return Result.Ok(100);
}
```

### Returns a successful result from a task.

```
Task Method()
{
  return Task.FromResult(Result.Ok());
}
```

### Returns a failure from a function

```
Result Method()
{
    return Result.Fail("This function has failed because of...");
}
```
