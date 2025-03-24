namespace EnglishApp.Domain.Entities;

public sealed class UserSignInEntity(int userId, string nickName, bool isEmailVerified)
{
    public int UserId { get; } = userId;
    public string NickName { get; } = nickName;
    public bool IsEmailVerified { get; } = isEmailVerified;
}
