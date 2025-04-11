using EnglishApp.Domain.Entities;
using System.Collections.Immutable;

namespace EnglishApp.Domain.Repositories;

public interface IUserGradeRepository
{
    Task<ImmutableList<GradeEntity>> GetAll();
}
