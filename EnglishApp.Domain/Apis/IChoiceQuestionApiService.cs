using EnglishApp.Domain.Entities;
using System.Collections.Immutable;

namespace EnglishApp.Domain.Apis;

public interface IChoiceQuestionApiService
{
    Task<ImmutableList<EnglishChoiceQuestionEntity>?> GetChoiceQuestionsAsync(int englishTextId);
}
