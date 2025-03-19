using EnglishApp.Domain.Entities;

namespace EnglishApp.Domain.Repositories;

public interface IUserAuthRepository
{
    public Task CreateUserAuth(UserAuthEntity entity);
}
