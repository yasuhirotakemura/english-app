using EnglishApp.Domain.Entities;
using EnglishApp.Domain.ValueObjects;

namespace EnglishApp.Application.Dtos.UserAuth;

public sealed class UserAuthSignUpRequest(string email,
                                          string base64HashedPassword,
                                          string base64Salt)
{
    public string Email { get; } = email;
    public string Base64HashedPassword { get; } = base64HashedPassword;
    public string Base64Salt { get; } = base64Salt;

    public static UserAuthSignUpRequest Create(string email, PasswordHash passwordHash)
    {
        return new UserAuthSignUpRequest(email, passwordHash.GetBase64Hash(), passwordHash.GetBase64Salt());
    }

    public UserAuthEntity ToEntity(int userId)
    {
        PasswordHash paswordHash = PasswordHash.CreateFromBase64(this.Base64HashedPassword, this.Base64Salt);

        return new(userId: userId, email: this.Email, passwordHash: paswordHash.Hash, salt: paswordHash.Salt);
    }
}