using EnglishApp.Domain.Entities;
using System.Collections.Immutable;

namespace EnglishApp.Application.Interfaces;

public interface IChoiceQuestionApiService
{
    Task<ImmutableList<EnglishChoiceQuestionEntity>?> GetChoiceQuestionsAsync(int englishTextId);
}
