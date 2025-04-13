using EnglishApp.Application.Dtos.Bases;

namespace EnglishApp.Application.Dtos.UserAuth;

public sealed class UserAuthSignUpResponse(int userId,
                                           string accessToken) : ResponseBase
{
    public int UserId { get; } = userId;
    public string AccessToken { get; } = accessToken;
}
