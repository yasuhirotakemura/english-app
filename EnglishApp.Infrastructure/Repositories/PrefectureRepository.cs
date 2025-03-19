using EnglishApp.Domain.Entities;
using EnglishApp.Domain.Repositories;
using EnglishApp.Infrastructure.Factories;
using EnglishApp.Infrastructure.Services;
using System.Collections.Immutable;

namespace EnglishApp.Infrastructure.Repositories;

public sealed class PrefectureRepository(SqlServerService sqlServer) : IPrefectureRepository
{
    private readonly SqlServerService _sqlServer = sqlServer;

    public Task<ImmutableList<PrefectureEntity>> GetAll()
    {
        string query = "SELECT Id, Name FROM Prefecture";

        return this._sqlServer.QueryAsync(query, EntityFactory.CreateMasterEntity<PrefectureEntity>);
    }
}
