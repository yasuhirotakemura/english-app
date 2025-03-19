using EnglishApp.Domain.Entities;
using System.Collections.Immutable;

namespace EnglishApp.Domain.Repositories;

public interface IUserLearningPurposeRepository
{
    Task<ImmutableList<UserLearningPurposeEntity>> GetAll();
}
