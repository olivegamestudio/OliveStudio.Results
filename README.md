# OliveStudio.Results

A C# library for clean, functional error handling. This library provides a robust alternative to exception-based error handling, making your code more predictable and easier to reason about.

## Installation

```bash
# Package manager
Install-Package OliveStudio.Results

# .NET CLI
dotnet add package OliveStudio.Results
```

## Core Types

### Result Types Without Values

#### `OkResult`
Represents a successful operation with no return value.

```csharp
var result = OkResult.Ok();
if (result.Success)
{
    Console.WriteLine("Operation completed successfully!");
}
```

#### `ErrorResult`
Represents a failed operation with error details.

```csharp
var result = FailedResult.Fail("User not found", 404);
if (result.IsFailure)
{
    Console.WriteLine($"Error: {result.Error} (Code: {result.ErrorCode})");
}
```

### Result Types With Values

#### `OkObjectResult<T>`
Represents a successful operation that returns a value.

```csharp
var result = OkObjectResult<string>.Ok("Hello, World!");
if (result.Success)
{
    Console.WriteLine(result.Value); // Output: Hello, World!
}
```

#### `FailedObjectResult<T>`
Represents a failed operation for a specific type.

```csharp
var result = FailedObjectResult<User>.Fail("Invalid user data", 400);
if (result.IsFailure)
{
    Console.WriteLine($"Failed to create user: {result.Error}");
    // result.Value will be default(User)
}
```

## Basic Usage Examples

### Simple Validation

```csharp
public Result ValidateEmail(string email)
{
    if (string.IsNullOrWhiteSpace(email))
        return FailedResult.Fail("Email is required");
    
    if (!email.Contains("@"))
        return FailedResult.Fail("Invalid email format");
    
    return OkResult.Ok();
}

// Usage
var validationResult = ValidateEmail("user@example.com");
if (validationResult.Success)
{
    Console.WriteLine("Email is valid!");
}
```

### Operations with Return Values

```csharp
public ObjectResult<User> CreateUser(string name, string email)
{
    if (string.IsNullOrWhiteSpace(name))
        return FailedObjectResult<User>.Fail("Name is required");
    
    if (string.IsNullOrWhiteSpace(email))
        return FailedObjectResult<User>.Fail("Email is required");
    
    var user = new User { Name = name, Email = email };
    return OkObjectResult<User>.Ok(user);
}

// Usage
var userResult = CreateUser("John Doe", "john@example.com");
if (userResult.Success)
{
    Console.WriteLine($"Created user: {userResult.Value.Name}");
}
else
{
    Console.WriteLine($"Failed to create user: {userResult.Error}");
}
```

### Combining Results

The library supports combining multiple results using the `&` operator:

```csharp
public Result ValidateUserData(string name, string email, int age)
{
    var nameValidation = ValidateName(name);
    var emailValidation = ValidateEmail(email);
    var ageValidation = ValidateAge(age);
    
    // All validations must succeed for the combined result to succeed
    return nameValidation & emailValidation & ageValidation;
}
```

### Boolean Conversion

Results can be used directly in conditional statements:

```csharp
var result = ValidateEmail("test@example.com");

// Direct boolean usage
if (result)
{
    Console.WriteLine("Validation passed");
}
```

## Service Layer Example

```csharp
public class UserService
{
    public ObjectResult<User> RegisterUser(string name, string email, string password)
    {
        // Validate input
        var validation = ValidateUserInput(name, email, password);
        if (validation.IsFailure)
            return FailedObjectResult<User>.Fail(validation.Error, validation.ErrorCode);
        
        // Check if user exists
        var existingUser = FindUserByEmail(email);
        if (existingUser.Success)
            return FailedObjectResult<User>.Fail("User already exists", 409);
        
        // Create and save user
        var user = new User { Name = name, Email = email };
        var saveResult = SaveUser(user);
        if (saveResult.IsFailure)
            return FailedObjectResult<User>.Fail("Failed to save user", 500);
        
        return OkObjectResult<User>.Ok(user);
    }
    
    private Result ValidateUserInput(string name, string email, string password)
    {
        var nameValidation = ValidateName(name);
        var emailValidation = ValidateEmail(email);
        var passwordValidation = ValidatePassword(password);
        
        return nameValidation & emailValidation & passwordValidation;
    }
}
```

## API Controller Example

```csharp
[ApiController]
[Route("api/[controller]")]
public class UsersController : ControllerBase
{
    private readonly UserService _userService;
    
    [HttpPost]
    public IActionResult CreateUser([FromBody] CreateUserRequest request)
    {
        var result = _userService.RegisterUser(
            request.Name, 
            request.Email, 
            request.Password);
        
        if (result.Success)
        {
            return Ok(result.Value);
        }
        
        return result.ErrorCode switch
        {
            409 => Conflict(result.Error),
            500 => StatusCode(500, result.Error),
            _ => BadRequest(result.Error)
        };
    }
}
```

## Best Practices

### Use Specific Error Codes
```csharp
public static class ErrorCodes
{
    public const int ValidationError = 400;
    public const int NotFound = 404;
    public const int Conflict = 409;
    public const int InternalError = 500;
}

// Usage
return FailedResult.Fail("User not found", ErrorCodes.NotFound);
```

### Create Domain-Specific Factory Methods
```csharp
public static class UserErrors
{
    public static FailedObjectResult<User> UserNotFound(int userId) =>
        FailedObjectResult<User>.Fail($"User with ID {userId} not found", 404);
    
    public static FailedObjectResult<User> EmailAlreadyExists(string email) =>
        FailedObjectResult<User>.Fail($"User with email {email} already exists", 409);
}
```
