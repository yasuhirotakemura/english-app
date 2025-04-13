using EnglishApp.Application.Dtos.Error;
using EnglishApp.Domain.Exceptions;
using EnglishApp.Domain.Exceptions.Bases;

namespace EnglishApp.Api.Middlewares;

public sealed class ExceptionHandlingMiddleware(RequestDelegate next,
                                                ILogger<ExceptionHandlingMiddleware> logger)
{
    private readonly RequestDelegate _next = next;
    private readonly ILogger<ExceptionHandlingMiddleware> _logger = logger;

    public async Task Invoke(HttpContext context)
    {
        try
        {
            await this._next(context);
        }
        catch (ExceptionBase ex)
        {
            context.Response.StatusCode = ex switch
            {
                EmailNotFoundException => StatusCodes.Status401Unauthorized,
                PasswordIncorrectException => StatusCodes.Status401Unauthorized,
                _ => StatusCodes.Status400BadRequest
            };

            ErrorResponse response = new(ex.Message);

            await context.Response.WriteAsJsonAsync(response);
        }
        catch (Exception ex)
        {
            this._logger.LogError(ex, "Unhandled exception occurred");

            context.Response.ContentType = "application/json";
            context.Response.StatusCode = 500;

            ErrorResponse response = new("サーバー側でエラーが発生しました。");

            await context.Response.WriteAsJsonAsync(response);
        }
    }
}

