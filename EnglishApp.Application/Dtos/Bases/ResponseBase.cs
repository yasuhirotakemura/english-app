namespace EnglishApp.Application.Dtos.Bases;

public abstract class ResponseBase
{
    public string? Message { get; init; }
    public List<WarningMessage>? Warnings { get; init; }
}
