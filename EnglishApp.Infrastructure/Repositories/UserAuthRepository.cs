using EnglishApp.Domain.Entities;
using EnglishApp.Domain.Repositories;
using EnglishApp.Infrastructure.Factories;
using EnglishApp.Infrastructure.Services;
using Microsoft.Data.SqlClient;

namespace EnglishApp.Infrastructure.Repositories;

public sealed class UserAuthRepository(SqlServerService sqlServerService) : IUserAuthRepository
{
    private readonly SqlServerService _sqlServerService = sqlServerService;

    public async Task SignUp(UserAuthEntity entity)
    {
        const string query = @"
            INSERT INTO UserAuth (UserId, Email, PasswordHash, Salt) 
            VALUES (@UserId, @Email, @PasswordHash, @Salt);";

        SqlParameter[] parameters =
            [
                new("@UserId", entity.Id),
                new("@Email", entity.Email),
                new("@PasswordHash", entity.PasswordHash),
                new("@Salt", entity.Salt)
            ];

        await this._sqlServerService.ExecuteAsync(query, parameters);
    }

    public async Task<UserSignInEntity?> SignIn(string email, byte[] passwordHash)
    {
        const string query = @"SELECT 
    UserAuth.UserId, 
    UserProfile.NickName,
    UserAuth.IsEmailVerified
FROM 
    UserAuth
INNER JOIN 
    UserProfile ON UserAuth.UserId = UserProfile.UserId
WHERE 
    UserAuth.Email = @Email AND UserAuth.PasswordHash = @PasswordHash;";

        SqlParameter[] parameters =
            [
                new("@Email", email),
                new("@PasswordHash", passwordHash)
            ];

        return await this._sqlServerService.QuerySingleAsync(query, parameters, EntityFactory.CreateUserSignInEntity);
    }

    public async Task<byte[]> GetSaltByEmail(string email)
    {
        const string query = @"SELECT Salt FROM UserAuth WHERE Email = @Email";

        SqlParameter[] parameters =
            [
                new("@Email", email)
            ];

        return
            await this._sqlServerService.ExecuteScalarAsync(query, parameters) is byte[] salt
            ? salt
            : throw new Exception("メールアドレスが存在しません。");
    }
}
