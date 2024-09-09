using Resultify.Enums;
using Resultify.Handlers;

namespace Resultify.ResultifyExtensions;

public static class ResponseValueMapper
{
    public static ResultifyHandler<TReturn> MapResponse<TValue, TReturn>(this ResultifyHandler<TValue> handler,
        Func<TValue, TReturn> mapper)
    {
        return handler.ResponseCategory switch
        {
            ResponseCategory.Information => Resultify.Information(mapper(handler.Value!), handler.StatusCode,
                handler.ErrorMessage),
            ResponseCategory.Success => Resultify.Success(mapper(handler.Value!), handler.StatusCode,
                handler.ErrorMessage),
            ResponseCategory.Redirection => Resultify.Redirection(mapper(handler.Value!), handler.StatusCode,
                handler.ErrorMessage),

            ResponseCategory.ClientError => Resultify.ClientError(handler.ErrorMessage, handler.StatusCode,
                mapper(handler.Value!)),
            ResponseCategory.ServerError => Resultify.ServerError(handler.ErrorMessage, handler.StatusCode,
                mapper(handler.Value!)),
            _ => Resultify.GenericError(handler.ErrorMessage, handler.StatusCode, mapper(handler.Value!))
        };
    }
}