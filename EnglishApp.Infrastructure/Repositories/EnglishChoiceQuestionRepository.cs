using EnglishApp.Domain.Entities;
using EnglishApp.Domain.Repositories;
using EnglishApp.Infrastructure.Factories;
using EnglishApp.Infrastructure.Services;
using System.Collections.Immutable;

namespace EnglishApp.Infrastructure.Repositories;

public sealed class EnglishChoiceQuestionRepository(SqlServerService sqlServer) : IEnglishChoiceQuestionRepository
{
    private readonly SqlServerService _sqlServer = sqlServer;

    public Task<ImmutableList<EnglishChoiceQuestionEntity>> GetChoiceQuestionByEnglishTextId(int englishTextId)
    {
        string query = "SELECT Id, EnglishTextId, QuestionText, CreatedAt, UpdatedAt FROM ChoiceQuestion WHERE EnglishTextId = " + englishTextId.ToString();

        return this._sqlServer.QueryAsync(query, EntityFactory.CreateEnglishChoiceQuestionEntity);
    }
}
