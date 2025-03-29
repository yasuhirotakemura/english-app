using EnglishApp.Application.Dtos.Responses.Bases;

namespace EnglishApp.Application.Dtos.Responses;

public sealed class UserAuthSaltResponse(string saltBase64,
                                         string message) : ResponseBase(message)
{
    public string SaltBase64 { get; } = saltBase64;
}
