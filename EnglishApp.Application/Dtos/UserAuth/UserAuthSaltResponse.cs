using EnglishApp.Application.Dtos.Bases;

namespace EnglishApp.Application.Dtos.UserAuth;

public sealed class UserAuthSaltResponse(string saltBase64) : ResponseBase
{
    public string SaltBase64 { get; } = saltBase64;
}
