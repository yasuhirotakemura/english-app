namespace EnglishApp.Application.Dtos.Responses;

public sealed class ErrorResponse(string message)
{
    public string Message { get; } = message;
}
