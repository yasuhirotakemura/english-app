using EnglishApp.Domain.Entities;
using System.Collections.Immutable;
using System.Net.Http.Json;

namespace EnglishApp.Maui.Services;

public class EnglishChoiceQuestionService(HttpClient httpClient)
{
    private readonly HttpClient _httpClient = httpClient;

    public async Task<ImmutableList<EnglishChoiceQuestionEntity>?> GetChoiceQuestionsAsync(int englishTextId)
    {
        try
        {
            return await this._httpClient.GetFromJsonAsync<ImmutableList<EnglishChoiceQuestionEntity>>("http://10.0.2.2:5249/api/ChoiceQuestion?englishTextId=" + englishTextId);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error fetching English texts: {ex.Message}");

            return null;
        }
    }
}
