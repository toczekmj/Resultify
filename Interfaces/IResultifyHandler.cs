using System.Net;
using Resultify.Enums;

namespace Resultify.Interfaces;

public interface IResultifyHandler
{
    ResponseCategory ResponseCategory { get; }
    string ErrorMessage { get; init; }
    HttpStatusCode? StatusCode { get; }
}