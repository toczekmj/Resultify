using System.Net;
using FluentAssertions;
using Resultify.Enums;
using Resultify.Handlers;

namespace Resultify.Tests;

public class ResultifyValueReturnCodesTests
{
    [Theory]
    [InlineData("Test value", HttpStatusCode.OK, "Test message")]
    [InlineData("Test value", HttpStatusCode.OK, null)]
    [InlineData("Test value", null, "Test message")]
    [InlineData("Test value", null, null)]
    public void Information_ShouldReturn_ResultifyHandler_WithCorrectValues(object value, HttpStatusCode? statusCode,
        string? errorMessage)
    {
        // Act
        var result = Resultify.Information(value, statusCode, errorMessage);

        // Assert
        result.Should().BeEquivalentTo(new ResultifyHandler<object>(value, ResponseCategory.Information,
            errorMessage ?? string.Empty, statusCode));
    }

    [Theory]
    [InlineData("Test value", HttpStatusCode.OK, "Test message")]
    [InlineData("Test value", HttpStatusCode.OK, null)]
    [InlineData("Test value", null, "Test message")]
    [InlineData("Test value", null, null)]
    public void Success_ShouldReturn_ResultifyHandler_WithCorrectValues(object value, HttpStatusCode? statusCode,
        string? errorMessage)
    {
        // Act
        var result = Resultify.Success(value, statusCode, errorMessage);

        // Assert
        result.Should().BeEquivalentTo(new ResultifyHandler<object>(value, ResponseCategory.Success,
            errorMessage ?? string.Empty, statusCode));
    }

    [Theory]
    [InlineData("Test value", HttpStatusCode.OK, "Test message")]
    [InlineData("Test value", HttpStatusCode.OK, null)]
    [InlineData("Test value", null, "Test message")]
    [InlineData("Test value", null, null)]
    public void Redirection_ShouldReturn_ResultifyHandler_WithCorrectValues(object value, HttpStatusCode? statusCode,
        string? errorMessage)
    {
        // Act
        var result = Resultify.Redirection(value, statusCode, errorMessage);

        // Assert
        result.Should().BeEquivalentTo(new ResultifyHandler<object>(value, ResponseCategory.Redirection,
            errorMessage ?? string.Empty, statusCode));
    }

    [Theory]
    [InlineData("Test value", HttpStatusCode.OK, "Test message")]
    [InlineData("Test value", HttpStatusCode.OK, null)]
    [InlineData("Test value", null, "Test message")]
    [InlineData("Test value", null, null)]
    public void ClientError_ShouldReturn_ResultifyHandler_WithCorrectValues(object value, HttpStatusCode? statusCode,
        string errorMessage)
    {
        // Act
        var result = Resultify.ClientError(errorMessage, statusCode, value);

        // Assert
        result.Should().BeEquivalentTo(new ResultifyHandler<object>(value, ResponseCategory.ClientError,
            errorMessage, statusCode));
    }

    [Theory]
    [InlineData("Test value", HttpStatusCode.OK, "Test message")]
    [InlineData("Test value", HttpStatusCode.OK, null)]
    [InlineData("Test value", null, "Test message")]
    [InlineData("Test value", null, null)]
    public void ServerError_ShouldReturn_ResultifyHandler_WithCorrectValues(object value, HttpStatusCode? statusCode,
        string errorMessage)
    {
        // Act
        var result = Resultify.ServerError(errorMessage, statusCode, value);

        // Assert
        result.Should().BeEquivalentTo(new ResultifyHandler<object>(value, ResponseCategory.ServerError,
            errorMessage, statusCode));
    }

    [Theory]
    [InlineData("Test value", HttpStatusCode.OK, "Test message")]
    [InlineData("Test value", HttpStatusCode.OK, null)]
    [InlineData("Test value", null, "Test message")]
    [InlineData("Test value", null, null)]
    public void GenericError_ShouldReturn_ResultifyHandler_WithCorrectValues(object value, HttpStatusCode? statusCode,
        string errorMessage)
    {
        // Act
        var result = Resultify.GenericError(errorMessage, statusCode, value);

        // Assert
        result.Should().BeEquivalentTo(new ResultifyHandler<object>(value, ResponseCategory.GenericError,
            errorMessage, statusCode));
    }
}