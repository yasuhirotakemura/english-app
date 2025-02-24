using EnglishApp.Domain.Entities;
using EnglishApp.Domain.Repositories;
using EnglishApp.Infrastructure.Factories;
using EnglishApp.Infrastructure.Services;
using System.Collections.Immutable;

namespace EnglishApp.Infrastructure.Repositories;

public sealed class EnglishQuestionRepository(SqlServerService sqlServer) : IEnglishQuestionRepository
{
    private readonly SqlServerService _sqlServer = sqlServer;

    public Task<ImmutableList<EnglishQuestionEntity>> GetAll()
    {
        const string query = "SELECT Id, EnglishTextId, QuestionText, Answer, CreatedAt, UpdatedAt FROM EnglishQuestion";

        return this._sqlServer.QueryAsync(query, EntityFactory.CreateEnglishQuestion);
    }
}
