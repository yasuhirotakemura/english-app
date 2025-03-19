using EnglishApp.Domain.Entities;
using EnglishApp.Domain.Repositories;
using EnglishApp.Infrastructure.Services;
using Microsoft.Data.SqlClient;

namespace EnglishApp.Infrastructure.Repositories;

public sealed class UserAuthRepository(SqlServerService sqlServerService) : IUserAuthRepository
{
    private readonly SqlServerService _sqlServerService = sqlServerService;

    public async Task<int> CreateUserAuth(UserAuthEntity entity)
    {
        const string sql = @"
            INSERT INTO UserAuth (UserId, Email, PasswordHash, Salt) 
            VALUES (@UserId, @Email, @PasswordHash, @Salt);";

        SqlParameter[] parameters =
            [
                new("@UserId", entity.Id),
                new("@Email", entity.Email),
                new("@PasswordHash", entity.PasswordHash),
                new("@Salt", entity.Salt)
            ];

        return await this._sqlServerService.ExecuteAsync(sql, parameters);
    }
}
