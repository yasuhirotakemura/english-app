using EnglishApp.Application.Dtos.Responses.Bases;

namespace EnglishApp.Application.Dtos.Responses;

public sealed class UserAuthSignUpResponse(int userId, string accessToken, string message) : ResponseBase(message)
{
    public int UserId { get; } = userId;
    public string AccessToken { get; } = accessToken;
}
