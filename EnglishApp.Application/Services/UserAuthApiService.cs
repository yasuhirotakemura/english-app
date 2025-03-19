using EnglishApp.Application.Apis;
using EnglishApp.Application.Dtos;
using System.Net.Http.Json;

namespace EnglishApp.Application.Services;

public sealed class UserAuthApiService(HttpClient httpClient) : IUserAuthApiService
{
    private readonly HttpClient _httpClient = httpClient;

    public async Task<bool> SignUpAsync(UserAuthSignUpRequest request)
    {
        HttpResponseMessage response = await this._httpClient.PostAsJsonAsync("http://10.0.2.2:5249/api/user/signup", request);

        string jsonString = await response.Content.ReadAsStringAsync();
        Console.WriteLine($"📌 API Response JSON: {jsonString}");

        return response.IsSuccessStatusCode;
    }
}
