namespace EnglishApp.Application.Dtos.Responses.Bases;

public abstract class ResponseBase(string message)
{
    public string Message { get; } = message;
}
