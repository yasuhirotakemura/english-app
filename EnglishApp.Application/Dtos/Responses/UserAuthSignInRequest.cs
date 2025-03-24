using EnglishApp.Domain.ValueObjects;

namespace EnglishApp.Application.Dtos.Responses;

public sealed class UserAuthSignInRequest(string email, string passwordHash)
{
    public string Email { get; } = email;
    public string PasswordHash { get; } = passwordHash;

    public static UserAuthSignInRequest Create(string email, PasswordHash passwordHash)
    {
        return new UserAuthSignInRequest(email, passwordHash.GetBase64Hash());
    }
}
