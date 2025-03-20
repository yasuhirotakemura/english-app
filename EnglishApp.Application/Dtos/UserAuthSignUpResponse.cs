using EnglishApp.Application.Dtos.Bases;

namespace EnglishApp.Application.Dtos;

public sealed class UserAuthSignUpResponse(int userId, string message) : ResponseBase(message)
{
    public int UserId { get; } = userId;
}
