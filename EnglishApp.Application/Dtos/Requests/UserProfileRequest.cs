namespace EnglishApp.Application.Dtos.Requests;

public sealed class UserProfileRequest(int userId)
{
    public int UserId { get; } = userId;
}
