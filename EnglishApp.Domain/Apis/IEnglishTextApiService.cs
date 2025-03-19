using EnglishApp.Domain.Entities;
using System.Collections.Immutable;

namespace EnglishApp.Domain.Apis;

public interface IEnglishTextApiService
{
    Task<ImmutableList<EnglishTextEntity>?> GetEnglishTextsAsync();
}