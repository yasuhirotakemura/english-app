using EnglishApp.Domain.Entities;
using EnglishApp.Domain.Repositories;
using EnglishApp.Infrastructure.Factories;
using EnglishApp.Infrastructure.Services;
using System.Collections.Immutable;

namespace EnglishApp.Infrastructure.Repositories;

public sealed class UserGradeRepository(SqlServerService sqlServer) : IUserGradeRepository
{
    private readonly SqlServerService _sqlServer = sqlServer;

    public Task<ImmutableList<GradeEntity>> GetAll()
    {
        string query = "SELECT Id, Name, CreatedAt, UpdatedAt FROM UserGrade";

        return this._sqlServer.QueryAsync(query, EntityFactory.CreateUserGradeEntity);
    }
}
