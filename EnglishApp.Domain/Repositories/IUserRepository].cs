namespace EnglishApp.Domain.Repositories;

public interface IUserRepository
{
    Task<int> CreateUser();
}