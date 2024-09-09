using System.Net;
using FluentAssertions;
using Resultify.Enums;
using Resultify.Handlers;
using Resultify.ResultifyExtensions;

namespace Resultify.Tests.Extensions;

public class ResponseValueMapperTests
{
    [Fact]
    public void MapResponse_ShouldMapInformationCorrectly()
    {
        // Arrange
        var handler = new ResultifyHandler<string>("Test Value", ResponseCategory.Information, "Information message",
            HttpStatusCode.Continue);

        // Act
        var result = handler.MapResponse(value => value.Length);

        // Assert
        result.Should().BeEquivalentTo(new ResultifyHandler<int>(10, ResponseCategory.Information,
            "Information message", HttpStatusCode.Continue));
    }

    [Fact]
    public void MapResponse_ShouldMapSuccessCorrectly()
    {
        // Arrange
        var handler = new ResultifyHandler<string>("Test Value", ResponseCategory.Success, "Success message",
            HttpStatusCode.OK);

        // Act
        var result = handler.MapResponse(value => value.Length);

        // Assert
        result.Should()
            .BeEquivalentTo(new ResultifyHandler<int>(10, ResponseCategory.Success, "Success message",
                HttpStatusCode.OK));
    }

    [Fact]
    public void MapResponse_ShouldMapRedirectionCorrectly()
    {
        // Arrange
        var handler = new ResultifyHandler<string>("Test Value", ResponseCategory.Redirection, "Redirection message",
            HttpStatusCode.Found);

        // Act
        var result = handler.MapResponse(value => value.Length);

        // Assert
        result.Should().BeEquivalentTo(new ResultifyHandler<int>(10, ResponseCategory.Redirection,
            "Redirection message", HttpStatusCode.Found));
    }

    [Fact]
    public void MapResponse_ShouldMapClientErrorCorrectly()
    {
        // Arrange
        var handler = new ResultifyHandler<string>("Test Value", ResponseCategory.ClientError, "Client error message",
            HttpStatusCode.BadRequest);

        // Act
        var result = handler.MapResponse(value => value.Length);

        // Assert
        result.Should().BeEquivalentTo(new ResultifyHandler<int>(10, ResponseCategory.ClientError,
            "Client error message", HttpStatusCode.BadRequest));
    }

    [Fact]
    public void MapResponse_ShouldMapServerErrorCorrectly()
    {
        // Arrange
        var handler = new ResultifyHandler<string>("Test Value", ResponseCategory.ServerError, "Server error message",
            HttpStatusCode.InternalServerError);

        // Act
        var result = handler.MapResponse(value => value.Length);

        // Assert
        result.Should().BeEquivalentTo(new ResultifyHandler<int>(10, ResponseCategory.ServerError,
            "Server error message", HttpStatusCode.InternalServerError));
    }

    [Fact]
    public void MapResponse_ShouldMapGenericErrorCorrectly()
    {
        // Arrange
        var handler = new ResultifyHandler<string>("Test Value", ResponseCategory.GenericError, "Generic error message",
            HttpStatusCode.ServiceUnavailable);

        // Act
        var result = handler.MapResponse(value => value.Length);

        // Assert
        result.Should().BeEquivalentTo(new ResultifyHandler<int>(10, ResponseCategory.GenericError,
            "Generic error message", HttpStatusCode.ServiceUnavailable));
    }
}