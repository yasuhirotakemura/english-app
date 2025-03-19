namespace EnglishApp.Application.Dtos;

public sealed class UserAuthSignUpRequest(string email,
                                          byte[] passwordHash,
                                          byte[] salt)
{
    public string Email { get; } = email;
    public byte[] PasswordHash { get; } = passwordHash;
    public byte[] Salt { get; } = salt;
}