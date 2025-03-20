using EnglishApp.Application.Dtos.Bases;

namespace EnglishApp.Application.Dtos;

public sealed class ErrorResponse(string content, string message) : ResponseBase(message)
{
    public string Content { get; } = content;
}
