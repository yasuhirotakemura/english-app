using EnglishApp.Domain.Entities;
using System.Collections.Immutable;

namespace EnglishApp.Domain.Repositories;

public interface IEnglishQuestionRepository
{
    public Task<ImmutableList<EnglishQuestionEntity>> GetAll();
}
