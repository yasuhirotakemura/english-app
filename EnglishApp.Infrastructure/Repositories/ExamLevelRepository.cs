using EnglishApp.Domain.Entities;
using EnglishApp.Domain.Repositories;
using EnglishApp.Infrastructure.Factories;
using EnglishApp.Infrastructure.Services;
using System.Collections.Immutable;

namespace EnglishApp.Infrastructure.Repositories;

public sealed class ExamLevelRepository(SqlServerService sqlServer) : IExamLevelRepository
{
    private readonly SqlServerService _sqlServer = sqlServer;

    public Task<ImmutableList<ExamLevelEntity>> GetAll()
    {
        string query = "SELECT Id, Name, CreatedAt, UpdatedAt FROM ExamLevel";

        return this._sqlServer.QueryAsync(query, EntityFactory.CreateExamLevelEntity);
    }
}
