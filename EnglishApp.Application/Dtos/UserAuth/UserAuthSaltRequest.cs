namespace EnglishApp.Application.Dtos.UserAuth;

public sealed class UserAuthSaltRequest(string email)
{
    public string Email { get; } = email;
}