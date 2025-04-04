using EnglishApp.Application.Dtos.Responses.Bases;

namespace EnglishApp.Application.Dtos.Responses;

public sealed class UserAuthSignInResponse(string message,
                                           int userId,
                                           string nickName,
                                           bool isEmailVerified,
                                           string accessToken) : ResponseBase(message)
{
    public int UserId { get; } = userId;
    public string NickName { get; } = nickName;
    public bool IsEmailVerified { get; } = isEmailVerified;
    public string AccessToken { get; } = accessToken;
}
