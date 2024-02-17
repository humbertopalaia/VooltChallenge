using System.Net;
using VooltChallenge.Infra.Exceptions;

namespace VooltChallenge.API.Middlewares;

public class ExceptionMiddleware(ILogger<ExceptionMiddleware> logger, RequestDelegate next, IConfiguration configuration)
{
    private readonly bool _shouldReturnError = configuration.GetValue<bool>("Properties:WriteDebugOnInternalError");

    public async Task Invoke(HttpContext context)
    {
        try
        {
            await next(context);
        }
        catch (BaseException baseException)
        {
            logger.LogError(baseException.GetBaseException(), "error while executing {Context}",
                context.Request.Path.Value);
            var response = context.Response;
            response.ContentType = "application/json";
            response.StatusCode = baseException.Status;

            var body = new
            {
                Timestamp = DateTime.Now,
                Path = context.Request.Path.Value,
                baseException.Message,
                Code = baseException.ErrorCode
            };

            await response.WriteAsJsonAsync(body);
        }
        catch (Exception exception)
        {
            logger.LogError("server error");
            logger.LogError(exception, "error while executing {Context}", context.Request.Path.Value);
            var response = context.Response;
            response.ContentType = "application/json";
            response.StatusCode = (int)HttpStatusCode.BadRequest;

            var responseBody = new Dictionary<string, object?>
            {
                ["Timestamp"] = DateTime.Now,
                ["Path"] = context.Request.Path.Value
            };

            if (_shouldReturnError)
            {
                responseBody["InternalMessage"] = exception.Message;
            }

            await response.WriteAsJsonAsync(responseBody);
        }
    }
}