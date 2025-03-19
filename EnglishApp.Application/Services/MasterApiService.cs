using EnglishApp.Application.Apis;
using EnglishApp.Application.Dtos;
using EnglishApp.Domain.StaticValues;
using System.Text.Json;

namespace EnglishApp.Application.Services;

public sealed class MasterApiService(HttpClient httpClient) : IMasterApiService
{
    private readonly HttpClient _httpClient = httpClient;
    private static readonly JsonSerializerOptions s_jsonOptions = new()
    {
        PropertyNameCaseInsensitive = true // JSONのキーを大小文字区別しない
    };

    public async Task LoadAllMasterData()
    {
        HttpResponseMessage response = await this._httpClient.GetAsync("http://10.0.2.2:5249/api/master");

        if (!response.IsSuccessStatusCode)
        {
            throw new HttpRequestException($"API Error: {response.StatusCode}");
        }

        string jsonString = await response.Content.ReadAsStringAsync();

        MasterDataDto masterData = JsonSerializer.Deserialize<MasterDataDto>(jsonString, s_jsonOptions)
                         ?? throw new InvalidOperationException("Failed to deserialize master data");

        MasterData.Update(masterData.Prefectures, masterData.UserGrades, masterData.UserLearningPurposes);
    }
}

