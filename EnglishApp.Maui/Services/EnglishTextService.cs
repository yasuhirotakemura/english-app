using EnglishApp.Domain.Entities;
using System.Collections.Immutable;
using System.Net.Http.Json;

namespace EnglishApp.Maui.Services;

public class EnglishTextService(HttpClient httpClient)
{
    private readonly HttpClient _httpClient = httpClient;

    public async Task<ImmutableList<EnglishTextEntity>?> GetEnglishTextsAsync()
    {
        try
        {
            return await this._httpClient.GetFromJsonAsync<ImmutableList<EnglishTextEntity>>("http://10.0.2.2:5249/api/EnglishText");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error fetching English texts: {ex.Message}");

            return null;
        }
    }
}
