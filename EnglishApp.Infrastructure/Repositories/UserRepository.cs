using EnglishApp.Domain.Repositories;
using EnglishApp.Infrastructure.Services;

namespace EnglishApp.Infrastructure.Repositories;

public sealed class UserRepository(SqlServerService sqlServerService) : IUserRepository
{
    private readonly SqlServerService _sqlServerService = sqlServerService;

    public async Task<int> CreateUser()
    {
        const string query =
            "INSERT INTO [User] DEFAULT VALUES;" +
            "SELECT SCOPE_IDENTITY();";

        object? result = await this._sqlServerService.ExecuteScalarAsync(query);

        return result is not null
            ?  Convert.ToInt32(result)
            :  throw new Exception("UserIdの取得に失敗しました。");
    }
}
