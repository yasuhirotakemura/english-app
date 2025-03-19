using EnglishApp.Domain.Entities;
using System.Collections.Immutable;

namespace EnglishApp.Application.Apis;

public interface IEnglishTextApiService
{
    Task<ImmutableList<EnglishTextEntity>?> GetEnglishTextsAsync();
}