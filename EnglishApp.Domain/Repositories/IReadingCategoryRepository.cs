using EnglishApp.Domain.Entities;
using System.Collections.Immutable;

namespace EnglishApp.Domain.Repositories;

public interface IReadingCategoryRepository
{
    Task<ImmutableList<ReadingCategoryEntity>> GetAll();
}
