namespace BoxFactoryAPI.Middleware;

public sealed class ExceptionMiddleware
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
        } catch (Exception ex)
        {
            _logger.LogError(ex, "An error was caught by the exception middleware");

            context.Response.StatusCode = StatusCodes.Status500InternalServerError;

            await context.Response.WriteAsync("Internal Server Error");
        }
    }
}
