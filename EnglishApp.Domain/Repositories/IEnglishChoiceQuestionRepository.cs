using EnglishApp.Domain.Entities;
using System.Collections.Immutable;

namespace EnglishApp.Domain.Repositories;

public interface IEnglishChoiceQuestionRepository
{
    public Task<ImmutableList<EnglishChoiceQuestionEntity>> GetChoiceQuestionByEnglishTextId(int englishTextId);
}
