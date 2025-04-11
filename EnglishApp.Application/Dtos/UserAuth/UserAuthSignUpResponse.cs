using EnglishApp.Application.Dtos.Bases;

namespace EnglishApp.Application.Dtos.UserAuth;

public sealed class UserAuthSignUpResponse(string message,
                                           int userId,
                                           string accessToken) : ResponseBase(message)
{
    public int UserId { get; } = userId;
    public string AccessToken { get; } = accessToken;
}
