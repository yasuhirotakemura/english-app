using EnglishApp.Domain.Entities;
using EnglishApp.Domain.Repositories;
using EnglishApp.Infrastructure.Factories;
using EnglishApp.Infrastructure.Services;
using System.Collections.Immutable;

namespace EnglishApp.Infrastructure.Repositories;

public sealed class ReadingLevelRepository(SqlServerService sqlServer) : IReadingLevelRepository
{
    private readonly SqlServerService _sqlServer = sqlServer;

    public Task<ImmutableList<ReadingLevelEntity>> GetAll()
    {
        string query = "SELECT Id, Name, CreatedAt, UpdatedAt FROM ReadingLevel";

        return this._sqlServer.QueryAsync(query, EntityFactory.CreateReadingLevelEntity);
    }
}
