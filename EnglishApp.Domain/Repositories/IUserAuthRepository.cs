using EnglishApp.Domain.Entities;

namespace EnglishApp.Domain.Repositories;

public interface IUserAuthRepository
{
    Task SignUp(UserAuthEntity entity);
    Task<byte[]> GetSaltByEmail(string email);
    Task<UserSignInEntity?> SignIn(string email, byte[] passwordHash);
}
