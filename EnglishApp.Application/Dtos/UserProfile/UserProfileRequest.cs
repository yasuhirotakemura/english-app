namespace EnglishApp.Application.Dtos.UserProfile;

public sealed class UserProfileRequest(int userId)
{
    public int UserId { get; } = userId;
}
