using EnglishApp.Domain.Entities;
using EnglishApp.Domain.Repositories;
using EnglishApp.Infrastructure.Factories;
using EnglishApp.Infrastructure.Services;
using Microsoft.Data.SqlClient;

namespace EnglishApp.Infrastructure.Repositories;

public sealed class UserProfileRepository(SqlServerService sqlServerService) : IUserProfileRepository
{
    private readonly SqlServerService _sqlServerService = sqlServerService;

    public async Task<UserProfileEntity?> Create(UserProfileInsertEntity entity)
    {
        const string query = @"
    INSERT INTO UserProfile (
        UserId,
        NickName,
        Gender,
        GradeId,
        LearningPurposeId,
        PrefectureId,
        BirthDate,
        ProfileText,
        IconUri
    )
    VALUES (
        @UserId,
        @NickName,
        @Gender,
        @GradeId,
        @LearningPurposeId,
        @PrefectureId,
        @BirthDate,
        @ProfileText,
        @IconUri
    );";

        SqlParameter[] parameters =
            [
                new("@UserId", entity.UserId),
                new("@NickName", entity.NickName),
                new("@Gender", entity.Gender),
                new("@GradeId", entity.GradeId),
                new("@LearningPurposeId", entity.LearningPurposeId),
                new("@PrefectureId", entity.PrefectureId),
                new("@BirthDate", entity.BirthDate),
                new("@ProfileText", entity.ProfileText),
                new("@IconUri", entity.IconUri)
            ];

        await this._sqlServerService.ExecuteAsync(query, parameters);

        return await this.GetByUserId(entity.UserId);
    }

    public async Task<UserProfileEntity?> GetByUserId(int id)
    {
        const string query = @"
SELECT 
    UserId,
    NickName,
    Gender,
    GradeId,
    LearningPurposeId,
    PrefectureId,
    Grade,
    LearningPurpose,
    Prefecture,
    BirthDate,
    ProfileText,
    IsDeleted,
    AccountCreatedAt,
    ProfileUpdatedAt,
    LastLoginAt,
    IconUri
FROM 
    UserProfileView
WHERE 
    UserId = @UserId";

        SqlParameter[] parameters =
        [
            new( "@UserId", id),
        ];

        return await this._sqlServerService.QuerySingleAsync(query, parameters, EntityFactory.CreateUserProfileEntity);
    }
}
