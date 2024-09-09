using System.Net;
using FluentAssertions;
using Resultify.Enums;
using Resultify.Handlers;
using Resultify.Interfaces;

namespace Resultify.Tests;

public class AnyFailTests
{
    // tests for public static bool AnyFail(params IResultifyHandler[] results)
    [Fact]
    public void AnyFail_WithNoResults_ShouldReturnFalse()
    {
        // Arrange
        var results = Array.Empty<IResultifyHandler>();

        // Act
        var actual = Resultify.AnyFail(results);

        // Assert
        actual.Should().BeFalse();
    }

    [Fact]
    public void AnyFail_WithAllSuccessResults_ShouldReturnFalse()
    {
        // Arrange
        var results = new IResultifyHandler[]
        {
            new ResultifyHandler(ResponseCategory.Success, "Success message", HttpStatusCode.OK),
            new ResultifyHandler(ResponseCategory.Success, "Success message", HttpStatusCode.OK),
            new ResultifyHandler(ResponseCategory.Success, "Success message", HttpStatusCode.OK)
        };

        // Act
        var actual = Resultify.AnyFail(results);

        // Assert
        actual.Should().BeFalse();
    }
}