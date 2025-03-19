namespace EnglishApp.Application.Dtos;

public class UserAuthSignUpRequest(string email,
                                          string passwordHash,
                                          string salt)
{
    public string Email { get; } = email;
    public string PasswordHash { get; } = passwordHash;
    public string Salt { get; } = salt;
}