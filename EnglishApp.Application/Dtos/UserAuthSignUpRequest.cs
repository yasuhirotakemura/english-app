using EnglishApp.Domain.ValueObjects;

namespace EnglishApp.Application.Dtos;

public class UserAuthSignUpRequest(string email,
                                   string passwordHash,
                                   string salt)
{
    public string Email { get; } = email;
    public string PasswordHash { get; } = passwordHash;
    public string Salt { get; } = salt;

    public static UserAuthSignUpRequest Create(string email, PasswordHash passwordHash)
    {
        return new UserAuthSignUpRequest(email, passwordHash.GetBase64Hash(), passwordHash.GetBase64Salt());
    }
}