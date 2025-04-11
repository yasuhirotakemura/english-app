using EnglishApp.Domain.Entities;
using EnglishApp.Domain.Repositories;
using EnglishApp.Infrastructure.Factories;
using EnglishApp.Infrastructure.Services;
using System.Collections.Immutable;

namespace EnglishApp.Infrastructure.Repositories;

public sealed class UserLearningPurposeRepository(SqlServerService sqlServer) : IUserLearningPurposeRepository
{
    private readonly SqlServerService _sqlServer = sqlServer;

    public Task<ImmutableList<UserLearningPurposeEntity>> GetAll()
    {
        string query = "SELECT Id, Name, CreatedAt, UpdatedAt FROM UserLearningPurpose";

        return this._sqlServer.QueryAsync(query, EntityFactory.CreateUserLearningPurposeEntity);
    }
}
