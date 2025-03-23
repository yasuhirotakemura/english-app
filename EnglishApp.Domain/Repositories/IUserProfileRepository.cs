using EnglishApp.Domain.Entities;

namespace EnglishApp.Domain.Repositories;

public interface IUserProfileRepository
{
    Task<UserProfileEntity?> Create(UserProfileInsertEntity entity);
    Task<UserProfileEntity?> GetByUserId(int id);
}
