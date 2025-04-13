using EnglishApp.Application.Dtos.Bases;

namespace EnglishApp.Application.Dtos.UserAuth;

public sealed class UserAuthSignInResponse(int userId,
                                           string nickName,
                                           bool isEmailVerified,
                                           string accessToken) : ResponseBase
{
    public int UserId { get; } = userId;
    public string NickName { get; } = nickName;
    public bool IsEmailVerified { get; } = isEmailVerified;
    public string AccessToken { get; } = accessToken;
}
