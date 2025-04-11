namespace EnglishApp.Application.Dtos.Bases;

public abstract class ResponseBase(string message)
{
    public string Message { get; } = message;
}
