namespace EnglishApp.Domain.Entities;

public sealed class UserAuthEntity(int id,
                                   string email,
                                   byte[] passwordHash,
                                   byte[] salt)
{
    public int Id { get; } = id;
    public string Email { get; } = email;
    public byte[] PasswordHash { get; } = passwordHash;
    public byte[] Salt { get; } = salt;
}
