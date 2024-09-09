using System.Net;
using FluentAssertions;
using Resultify.Enums;
using Resultify.Handlers;

namespace Resultify.Tests;

public class ResultifyVoidReturnCodesTests
{
    //for non <T> methods in Resultify class
    [Theory]
    [InlineData(HttpStatusCode.OK, "Test message")]
    [InlineData(HttpStatusCode.OK, null)]
    [InlineData(null, "Test message")]
    [InlineData(null, null)]
    public void Information_ShouldReturn_ResultifyHandler_WithCorrectValues(HttpStatusCode? statusCode,
        string? errorMessage)
    {
        // Act
        var result = Resultify.Information(errorMessage, statusCode);

        // Assert
        result.Should().BeEquivalentTo(new ResultifyHandler(ResponseCategory.Information,
            errorMessage ?? string.Empty, statusCode));
    }

    [Theory]
    [InlineData(HttpStatusCode.OK, "Test message")]
    [InlineData(HttpStatusCode.OK, null)]
    [InlineData(null, "Test message")]
    [InlineData(null, null)]
    public void Success_ShouldReturn_ResultifyHandler_WithCorrectValues(HttpStatusCode? statusCode,
        string? errorMessage)
    {
        // Act
        var result = Resultify.Success(errorMessage, statusCode);

        // Assert
        result.Should().BeEquivalentTo(new ResultifyHandler(ResponseCategory.Success,
            errorMessage ?? string.Empty, statusCode));
    }

    [Theory]
    [InlineData(HttpStatusCode.OK, "Test message")]
    [InlineData(HttpStatusCode.OK, null)]
    [InlineData(null, "Test message")]
    [InlineData(null, null)]
    public void Redirection_ShouldReturn_ResultifyHandler_WithCorrectValues(HttpStatusCode? statusCode,
        string? errorMessage)
    {
        // Act
        var result = Resultify.Redirection(errorMessage, statusCode);

        // Assert
        result.Should().BeEquivalentTo(new ResultifyHandler(ResponseCategory.Redirection,
            errorMessage ?? string.Empty, statusCode));
    }

    [Theory]
    [InlineData(HttpStatusCode.BadRequest, "Client error message")]
    [InlineData(HttpStatusCode.BadRequest, null)]
    public void ClientError_ShouldReturn_ResultifyHandler_WithCorrectValues(HttpStatusCode statusCode,
        string errorMessage)
    {
        // Act
        var result = Resultify.ClientError(errorMessage, statusCode);

        // Assert
        result.Should().BeEquivalentTo(new ResultifyHandler(ResponseCategory.ClientError,
            errorMessage, statusCode));
    }

    [Theory]
    [InlineData(HttpStatusCode.InternalServerError, "Server error message")]
    [InlineData(HttpStatusCode.InternalServerError, null)]
    public void ServerError_ShouldReturn_ResultifyHandler_WithCorrectValues(HttpStatusCode statusCode,
        string errorMessage)
    {
        // Act
        var result = Resultify.ServerError(errorMessage, statusCode);

        // Assert
        result.Should().BeEquivalentTo(new ResultifyHandler(ResponseCategory.ServerError,
            errorMessage, statusCode));
    }

    [Theory]
    [InlineData(HttpStatusCode.InternalServerError, "Generic error message")]
    [InlineData(HttpStatusCode.InternalServerError, null)]
    public void GenericError_ShouldReturn_ResultifyHandler_WithCorrectValues(HttpStatusCode statusCode,
        string errorMessage)
    {
        // Act
        var result = Resultify.GenericError(errorMessage, statusCode);

        // Assert
        result.Should().BeEquivalentTo(new ResultifyHandler(ResponseCategory.GenericError,
            errorMessage, statusCode));
    }
}