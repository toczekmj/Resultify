# Resultify

Resultify is a C# library designed to handle and map responses with various categories and HTTP status codes. It provides a structured way to manage responses in your application, making it easier to handle success, error, and informational messages.

## Features

- **Response Handling**: Manage responses with different categories such as Success, Information, Redirection, ClientError, ServerError, and GenericError.
- **Response Mapping**: Map responses to different types or values using custom mapping functions.
- **Fluent Assertions**: Easily test your response handling and mapping logic with FluentAssertions.

## Installation

To install Resultify, you can use the NuGet package manager:

```sh
dotnet add package Resultify
```

## Usage
Response Handling
You can create a ResultifyHandler to handle different types of responses:

```csharp
var handler = new ResultifyHandler<string>("Test Value", ResponseCategory.Success, "Success message", HttpStatusCode.OK);
Console.WriteLine(handler.Message); // Output: Success message
```

## Response Mapping
Map responses to different types or values using the MapResponse method:

```csharp
var handler = new ResultifyHandler<string>("Test Value", ResponseCategory.Success, "Success message", HttpStatusCode.OK);
var result = handler.MapResponse(value => value.Length);
Console.WriteLine(result.Value); // Output: 10
```


## Error Handling
Handle different categories of responses:
    
```csharp
// Sample method that returns a ResultifyHandler
public async Task<ResultifyHandler<int?>> Producer()
{
    // Some work is done here
    int? result = await AnotherComputedValue();
    
    // Produce a response based on the result
    if (result is null)
    {
        return Resultify.NotFound<int?>(HttpStatusCode.NotFound, "Value not found");
    }
    return Resultify.Success(i, HttpStatusCode.OK, "Optional message");
    
}

// MapResponse method can be used to map the response to a different type
public async Task<ResultifyHandler<ObjectDTO>> Producer2()
{
    // Some work is done here
    DbObject? result = await AnotherComputedValue();
    
    return result.MapResponse(r => r.AsDTO());
}

// Sample method that consumes the ResultifyHandler
public async Task<int> Consumer()
{
    var result = await Producer();
    
    // Handle the response based on the category
    if (result.Category == ResponseCategory.Success)
    {
        Console.WriteLine(result.Value);
    }
    else
    {
        Console.WriteLine(result.Message);
    }
    
    // Check multiple values 
    var objectDto = await Producer2();
    
    if(Resultify.AnyFail(result, objectDto))
    {
        Console.WriteLine("At least one response is an error");
    }
    
    return 
}

```