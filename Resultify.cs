using Resultify.Enums;
using Resultify.Interfaces;

namespace Resultify;

/// <summary>
///     Provides static methods for creating and handling Resultify responses.
/// </summary>
public static partial class Resultify
{
    /// <summary>
    ///     Determines if any of the provided Resultify handlers represent a failure.
    /// </summary>
    /// <param name="results">The array of Resultify handlers to check.</param>
    /// <returns>True if any handler represents a failure; otherwise, false.</returns>
    public static bool AnyFail(params IResultifyHandler[] results)
    {
        return results.Any(r => r.ResponseCategory is ResponseCategory.ClientError
            or ResponseCategory.ServerError
            or ResponseCategory.GenericError);
    }
}