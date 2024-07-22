# Result (Utility Library)

A utility library with Result type. This type provides a means of returning success or failure and an optional value. Great for avoiding throwing exceptions which are expensive.

## Installation

You can use the NUGET package named **Utility.Result** that is on nuget.org or adding this line to an **ItemGroup** in your csproj file.

```
<PackageReference Include="Utility.Result" Version="*" />
```

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
