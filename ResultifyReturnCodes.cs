using System.Net;
using Resultify.Enums;
using Resultify.Handlers;

namespace Resultify;

public static partial class Resultify
{
    public static ResultifyHandler<T> Information<T>(T value, HttpStatusCode? statusCode = default,
        string? message = default)
    {
        return new ResultifyHandler<T>(value, ResponseCategory.Information, message ?? string.Empty, statusCode);
    }

    public static ResultifyHandler<T> Success<T>(T value, HttpStatusCode? statusCode = default,
        string? message = default)
    {
        return new ResultifyHandler<T>(value, ResponseCategory.Success, message ?? string.Empty, statusCode);
    }

    public static ResultifyHandler<T> Redirection<T>(T value, HttpStatusCode? statusCode = default,
        string? message = default)
    {
        return new ResultifyHandler<T>(value, ResponseCategory.Redirection, message ?? string.Empty, statusCode);
    }

    public static ResultifyHandler<T> ClientError<T>(string message, HttpStatusCode? statusCode = default,
        T? value = default)
    {
        return new ResultifyHandler<T>(value, ResponseCategory.ClientError, message, statusCode);
    }

    public static ResultifyHandler<T> ServerError<T>(string message, HttpStatusCode? statusCode = default,
        T? value = default)
    {
        return new ResultifyHandler<T>(value, ResponseCategory.ServerError, message, statusCode);
    }

    public static ResultifyHandler<T> GenericError<T>(string message, HttpStatusCode? statusCode = default,
        T? value = default)
    {
        return new ResultifyHandler<T>(value, ResponseCategory.GenericError, message, statusCode);
    }

    public static ResultifyHandler Information(string? message, HttpStatusCode? statusCode)
    {
        return new ResultifyHandler(ResponseCategory.Information, message ?? string.Empty, statusCode);
    }

    public static ResultifyHandler Success(string? message, HttpStatusCode? statusCode)
    {
        return new ResultifyHandler(ResponseCategory.Success, message ?? string.Empty, statusCode);
    }

    public static ResultifyHandler Redirection(string? message, HttpStatusCode? statusCode)
    {
        return new ResultifyHandler(ResponseCategory.Redirection, message ?? string.Empty, statusCode);
    }

    public static ResultifyHandler ClientError(string message, HttpStatusCode? statusCode)
    {
        return new ResultifyHandler(ResponseCategory.ClientError, message, statusCode);
    }

    public static ResultifyHandler ServerError(string message, HttpStatusCode? statusCode)
    {
        return new ResultifyHandler(ResponseCategory.ServerError, message, statusCode);
    }

    public static ResultifyHandler GenericError(string message, HttpStatusCode? statusCode)
    {
        return new ResultifyHandler(ResponseCategory.GenericError, message, statusCode);
    }
}