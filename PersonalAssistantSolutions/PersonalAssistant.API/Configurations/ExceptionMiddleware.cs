using PersonalAssistant.Models.GenericModels;
using PersonalAssistant.Utilities.Helpers;

namespace PersonalAssistant.API.Configurations;

public class ExceptionMiddleware
{
    private readonly RequestDelegate _next;
    private readonly ILogger<ExceptionMiddleware> _logger;

    public ExceptionMiddleware(RequestDelegate next, ILogger<ExceptionMiddleware> logger)
    {
        _next = next;
        _logger = logger;
    }

    public async Task Invoke(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (Exception ex)
        {
            await HandleExceptionAsync(context, ex);
        }
    }

    private Task HandleExceptionAsync(HttpContext httpContext, Exception ex)
    {
        var controllerName = httpContext?.GetRouteData()?.Values["controller"];
        var actionName = httpContext?.GetRouteData()?.Values["action"];

        var response = httpContext.Response;
        response.ContentType = "application/json";

        var message = AppConstants.Failed;

#if DEBUG
        message = ex.Message ?? string.Empty;
#endif

        var responseModel = APIResponse<string>.Failed(message);

        httpContext.Response.ContentType = AppConstants.ContentType;
        httpContext.Response.StatusCode = (int)response.StatusCode;

        _logger.LogError(ex, $"{controllerName}: {actionName}-> Error occured. Message: {ex.Message}");

        return httpContext.Response.WriteAsJsonAsync(JsonConvert.SerializeObject(responseModel));
    }
}
