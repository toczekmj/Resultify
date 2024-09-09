using System.Net;
using FluentAssertions;
using Resultify.Enums;
using Resultify.Handlers;

namespace Resultify.Tests.Handlers;

public class ResultifyHandlerTests
{
    [Fact]
    public void ResultifyHandler_ShouldInitializeCorrectly()
    {
        // Arrange
        var responseCategory = ResponseCategory.Success;
        var errorMessage = "Success message";
        var statusCode = HttpStatusCode.OK;

        // Act
        var result = new ResultifyHandler(responseCategory, errorMessage, statusCode);

        // Assert
        result.ResponseCategory.Should().Be(responseCategory);
        result.ErrorMessage.Should().Be(errorMessage);
        result.StatusCode.Should().Be(statusCode);
    }

    [Fact]
    public void ResultifyHandlerT_ShouldInitializeCorrectly()
    {
        // Arrange
        var value = "Test Value";
        var responseCategory = ResponseCategory.Success;
        var errorMessage = "Success message";
        var statusCode = HttpStatusCode.OK;

        // Act
        var result = new ResultifyHandler<string>(value, responseCategory, errorMessage, statusCode);

        // Assert
        result.Value.Should().Be(value);
        result.ResponseCategory.Should().Be(responseCategory);
        result.ErrorMessage.Should().Be(errorMessage);
        result.StatusCode.Should().Be(statusCode);
    }

    [Fact]
    public void ResultifyHandlerT_ShouldHandleNullValue()
    {
        // Arrange
        string? value = null;
        var responseCategory = ResponseCategory.ClientError;
        var errorMessage = "Client error message";
        var statusCode = HttpStatusCode.BadRequest;

        // Act
        var result = new ResultifyHandler<string>(value, responseCategory, errorMessage, statusCode);

        // Assert
        result.Value.Should().BeNull();
        result.ResponseCategory.Should().Be(responseCategory);
        result.ErrorMessage.Should().Be(errorMessage);
        result.StatusCode.Should().Be(statusCode);
    }
}