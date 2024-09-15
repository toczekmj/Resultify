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
var errorHandler = new ResultifyHandler<string>(null, ResponseCategory.ClientError, "Client error occurred", HttpStatusCode.BadRequest);
if (errorHandler.Category == ResponseCategory.ClientError)
{
    Console.WriteLine(errorHandler.Message); // Output: Client error occurred
}
```