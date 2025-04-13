namespace EnglishApp.Application.Dtos.Error;

public sealed class ErrorResponse(string message)
{
    public string Message { get; } = message;
}
