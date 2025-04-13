using EnglishApp.Domain.ValueObjects;

namespace EnglishApp.Domain.Entities;

public sealed class UserAuthEntity(int userId,
                                   string email,
                                   byte[] passwordHash,
                                   byte[] salt)
{
    public int UserId { get; } = userId;
    public string Email { get; } = email;
    public byte[] PasswordHash { get; } = passwordHash;
    public byte[] Salt { get; } = salt;

    public static UserAuthEntity Create(int id, string email, PasswordHash passwordHash)
    {
        return new UserAuthEntity(id, email, passwordHash.Hash, passwordHash.Salt);
    }
}
