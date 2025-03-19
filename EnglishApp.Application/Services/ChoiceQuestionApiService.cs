using EnglishApp.Application.Apis;
using EnglishApp.Domain.Entities;
using System.Collections.Immutable;
using System.Net.Http.Json;

namespace EnglishApp.Application.Services;

public sealed class ChoiceQuestionApiService(HttpClient httpClient) : IChoiceQuestionApiService
{
    private readonly HttpClient _httpClient = httpClient;

    public async Task<ImmutableList<EnglishChoiceQuestionEntity>?> GetChoiceQuestionsAsync(int englishTextId)
    {
        return await this._httpClient.GetFromJsonAsync<ImmutableList<EnglishChoiceQuestionEntity>>("api/ChoiceQuestion?englishTextId=" + englishTextId);
    }
}
