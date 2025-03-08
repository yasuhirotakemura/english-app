using EnglishApp.Domain.Entities;
using System.Collections.Immutable;

namespace EnglishApp.Application.Interfaces;

public interface IEnglishTextApiService
{
    Task<ImmutableList<EnglishTextEntity>?> GetEnglishTextsAsync();
}