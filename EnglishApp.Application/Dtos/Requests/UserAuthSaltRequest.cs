namespace EnglishApp.Application.Dtos.Requests;

public sealed class UserAuthSaltRequest(string email)
{
    public string Email { get; } = email;
}