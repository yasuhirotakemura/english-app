using EnglishApp.Application.Dtos.Responses.Bases;

namespace EnglishApp.Application.Dtos.Responses;

public sealed class ErrorResponse(string content, string message) : ResponseBase(message)
{
    public string Content { get; } = content;
}
