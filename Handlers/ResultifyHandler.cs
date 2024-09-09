using System.Net;
using Resultify.Enums;
using Resultify.Interfaces;

namespace Resultify.Handlers;

public record ResultifyHandler(ResponseCategory ResponseCategory, string ErrorMessage, HttpStatusCode? StatusCode)
    : IResultifyHandler;

public record ResultifyHandler<T>(
    T? Value,
    ResponseCategory ResponseCategory,
    string ErrorMessage,
    HttpStatusCode? StatusCode)
    : IResultifyHandler;