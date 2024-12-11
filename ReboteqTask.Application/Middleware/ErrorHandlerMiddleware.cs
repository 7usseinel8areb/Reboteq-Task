
namespace ReboteqTask.Application.Middleware;

public class ErrorHandlerMiddleware : IMiddleware
{
    private readonly ILogger<ErrorHandlerMiddleware> _logger;

    public ErrorHandlerMiddleware(ILogger<ErrorHandlerMiddleware> logger)
    {
        _logger = logger;
    }

    public async Task InvokeAsync(HttpContext context, RequestDelegate next)
    {
        try
        {
            await next(context);
        }
        catch (Exception error)
        {
            _logger.LogError(error, "Unhandled exception occurred.");
            var result = HandleException(error);
            await result.ExecuteAsync(context);
        }
    }

    private IResult HandleException(Exception error)
    {
        _logger.LogDebug("Handling exception of type {ErrorType}", error.GetType());

        var statusCode = error switch
        {
            UnauthorizedAccessException => (int)HttpStatusCode.Unauthorized,
            ValidationException => (int)HttpStatusCode.UnprocessableEntity,
            KeyNotFoundException => (int)HttpStatusCode.NotFound,
            DbUpdateException => (int)HttpStatusCode.BadRequest,
            _ when error.GetType().ToString() == "ApiException" => (int)HttpStatusCode.BadRequest,
            _ => (int)HttpStatusCode.InternalServerError
        };

        var responseModel = new Response<string> { Succedded = false, StatusCode = (HttpStatusCode)statusCode, Message = "Failed" };

        switch (error)
        {
            case UnauthorizedAccessException:
                responseModel.AddError("Unauthorized", "Unauthorized Access Exception");
                break;
            case ValidationException validationException:
                var message = validationException.Message.Split(":");
                var (key, errorMessage) = (message.First(), message.Last());
                responseModel.AddError(key, errorMessage);
                break;
            case KeyNotFoundException:
                responseModel.AddError("NotFound", "The requested element cannot be found.");
                break;
            case DbUpdateException dbUpdateException:
                responseModel.AddError("DatabaseError", dbUpdateException.Message);
                break;
            default:
                responseModel.AddError("InternalServerError", error.Message);
                if (error.InnerException != null)
                {
                    responseModel.AddError("InnerException", error.InnerException.Message);
                }
                break;
        }

        return Results.Json(responseModel, statusCode: statusCode);
    }
}