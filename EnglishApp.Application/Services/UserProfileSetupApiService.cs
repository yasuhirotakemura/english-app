using EnglishApp.Application.Apis;
using EnglishApp.Application.Dtos.Requests;
using EnglishApp.Application.Dtos.Responses;
using System.Net.Http.Json;
using System.Text.Json;

namespace EnglishApp.Application.Services;

public sealed class UserProfileSetupApiService(HttpClient httpClient) : IUserProfileApiService
{
    private readonly HttpClient _httpClient = httpClient;
    private readonly JsonSerializerOptions _serializerOptions = new()
    {
        PropertyNameCaseInsensitive = true
    };

    public async Task<UserProfileSetupResponse?> CreateAsync(UserProfileSetupRequest request)
    {
        try
        {
            HttpResponseMessage response = await this._httpClient.PostAsJsonAsync("api/userprofile", request);

            string jsonString = await response.Content.ReadAsStringAsync();

            if (response.IsSuccessStatusCode)
            {
                UserProfileSetupResponse? res = JsonSerializer.Deserialize<UserProfileSetupResponse>(jsonString, this._serializerOptions);

                return res;
            }
            else
            {
                ErrorResponse? errorResponse = JsonSerializer.Deserialize<ErrorResponse>(jsonString);

                return null;
            }
        }
        catch (Exception)
        {
            return null;
        }
    }
}
