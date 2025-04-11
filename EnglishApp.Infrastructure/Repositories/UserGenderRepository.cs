using EnglishApp.Domain.Entities;
using EnglishApp.Domain.Repositories;
using EnglishApp.Infrastructure.Factories;
using EnglishApp.Infrastructure.Services;
using System.Collections.Immutable;

namespace EnglishApp.Infrastructure.Repositories;

public sealed class UserGenderRepository(SqlServerService sqlServer) : IUserGenderRepository
{
    private readonly SqlServerService _sqlServer = sqlServer;

    public Task<ImmutableList<GenderEntity>> GetAll()
    {
        string query = "SELECT Id, Name, CreatedAt, UpdatedAt FROM UserGender";

        return this._sqlServer.QueryAsync(query, EntityFactory.CreateUserGenderEntity);
    }
}
