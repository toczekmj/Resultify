using Resultify.Enums;
using Resultify.Handlers;

namespace Resultify.ResultifyExtensions;

public static class ResponseVoidMapper
{
    public static ResultifyHandler MapResponse<TArgument>(this ResultifyHandler<TArgument> handler)
    {
        return handler.ResponseCategory switch
        {
            ResponseCategory.Information => Resultify.Information(handler.ErrorMessage, handler.StatusCode),
            ResponseCategory.Success => Resultify.Success(handler.ErrorMessage, handler.StatusCode),
            ResponseCategory.Redirection => Resultify.Redirection(handler.ErrorMessage, handler.StatusCode),

            ResponseCategory.ClientError => Resultify.ClientError(handler.ErrorMessage, handler.StatusCode),
            ResponseCategory.ServerError => Resultify.ServerError(handler.ErrorMessage, handler.StatusCode),
            _ => Resultify.GenericError(handler.ErrorMessage, handler.StatusCode)
        };
    }
}