using EnglishApp.Application.Apis;
using EnglishApp.Domain.Entities;
using System.Collections.Immutable;
using System.Net.Http.Json;

namespace EnglishApp.Application.Services;

public sealed class EnglishTextApiService(HttpClient httpClient) : IEnglishTextApiService
{
    private readonly HttpClient _httpClient = httpClient;

    public async Task<ImmutableList<EnglishTextEntity>?> GetEnglishTextsAsync()
    {
        return await this._httpClient.GetFromJsonAsync<ImmutableList<EnglishTextEntity>>("http://10.0.2.2:5249/api/EnglishText");
    }
}
