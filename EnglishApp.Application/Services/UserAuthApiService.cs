using EnglishApp.Application.Apis;
using EnglishApp.Application.Dtos;
using System.Diagnostics;
using System.Net.Http.Json;
using System.Text.Json;

namespace EnglishApp.Application.Services;

public sealed class UserAuthApiService(HttpClient httpClient) : IUserAuthApiService
{
    private readonly HttpClient _httpClient = httpClient;

    public async Task<UserAuthSignUpResponse?> SignUpAsync(UserAuthSignUpRequest request)
    {
        try
        {
            HttpResponseMessage response = await this._httpClient.PostAsJsonAsync("api/user/signup", request);

            string jsonString = await response.Content.ReadAsStringAsync();

            if (response.IsSuccessStatusCode)
            {
                return JsonSerializer.Deserialize<UserAuthSignUpResponse>(jsonString);
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
