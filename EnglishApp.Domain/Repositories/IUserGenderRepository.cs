using EnglishApp.Domain.Entities;
using System.Collections.Immutable;

namespace EnglishApp.Domain.Repositories;

public interface IUserGenderRepository
{
    Task<ImmutableList<UserGenderEntity>> GetAll();
}
