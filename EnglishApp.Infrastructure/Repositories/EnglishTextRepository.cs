using EnglishApp.Domain.Entities;
using EnglishApp.Domain.Repositories;
using EnglishApp.Infrastructure.Factories;
using EnglishApp.Infrastructure.Services;
using System.Collections.Immutable;

namespace EnglishApp.Infrastructure.Repositories;

public sealed class EnglishTextRepository(SqlServerService sqlServer) : IEnglishTextRepository
{
    private readonly SqlServerService _sqlServer = sqlServer;

    public Task<ImmutableList<EnglishTextEntity>> GetAll()
    {
        const string query = "SELECT Id, Title, Content, CreatedAt, UpdatedAt FROM EnglishText";

        return this._sqlServer.QueryAsync(query, EntityFactory.CreateEnglishText);
    }
}
