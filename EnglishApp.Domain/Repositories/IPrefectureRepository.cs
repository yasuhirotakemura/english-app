using EnglishApp.Domain.Entities;
using System.Collections.Immutable;

namespace EnglishApp.Domain.Repositories;

public interface IPrefectureRepository
{
    Task<ImmutableList<PrefectureEntity>> GetAll();
}
