using EnglishApp.Domain.Entities;
using EnglishApp.Domain.Repositories;
using EnglishApp.Infrastructure.Factories;
using EnglishApp.Infrastructure.Services;
using System.Collections.Immutable;

namespace EnglishApp.Infrastructure.Repositories;

public sealed class ReadingCategoryRepository(SqlServerService sqlServer) : IReadingCategoryRepository
{
    private readonly SqlServerService _sqlServer = sqlServer;

    public Task<ImmutableList<ReadingCategoryEntity>> GetAll()
    {
        string query = "SELECT Id, Name, CreatedAt, UpdatedAt FROM ReadingCategory";

        return this._sqlServer.QueryAsync(query, EntityFactory.CreateReadingCategoryEntity);
    }
}
