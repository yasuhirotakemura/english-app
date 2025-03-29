using EnglishApp.Application.Dtos.Responses.Bases;

namespace EnglishApp.Application.Dtos.Responses;

public sealed class UserAuthSignUpResponse(string message,
                                           int userId,
                                           string accessToken) : ResponseBase(message)
{
    public int UserId { get; } = userId;
    public string AccessToken { get; } = accessToken;
}
