using EnglishApp.Application.Apis;
using EnglishApp.Application.Dtos.Requests;
using EnglishApp.Application.Dtos.Responses;
using System.Net.Http.Json;
using System.Text.Json;

namespace EnglishApp.Application.Services;

public sealed class UserAuthApiService(HttpClient httpClient) : IUserAuthApiService
{
    private readonly HttpClient _httpClient = httpClient;
    private readonly JsonSerializerOptions _serializerOptions = new()
    {
        PropertyNameCaseInsensitive = true
    };

    public async Task<UserAuthSignUpResponse?> SignUpAsync(UserAuthSignUpRequest request)
    {
        try
        {
            HttpResponseMessage response = await this._httpClient.PostAsJsonAsync("api/user/signup", request);

            string jsonString = await response.Content.ReadAsStringAsync();

            if (response.IsSuccessStatusCode)
            {
                UserAuthSignUpResponse? res = JsonSerializer.Deserialize<UserAuthSignUpResponse>(jsonString, this._serializerOptions);

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

    public async Task<UserAuthSignInResponse?> SignInAsync(UserAuthSignInRequest request)
    {
        try
        {
            HttpResponseMessage response = await this._httpClient.PostAsJsonAsync("api/user/signin", request);

            string jsonString = await response.Content.ReadAsStringAsync();

            if (response.IsSuccessStatusCode)
            {
                UserAuthSignInResponse? res = JsonSerializer.Deserialize<UserAuthSignInResponse>(jsonString, this._serializerOptions);

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

    public async Task<UserAuthSaltResponse?> GetSaltAsync(UserAuthSaltRequest request)
    {
        try
        {
            HttpResponseMessage response = await this._httpClient.PostAsJsonAsync("api/user/signin/salt", request);

            string jsonString = await response.Content.ReadAsStringAsync();

            if (response.IsSuccessStatusCode)
            {
                UserAuthSaltResponse? res = JsonSerializer.Deserialize<UserAuthSaltResponse>(jsonString, this._serializerOptions);

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
