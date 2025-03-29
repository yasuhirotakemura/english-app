using EnglishApp.Application.Dtos.Responses;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text.Json;

namespace EnglishApp.Application.Services;

public sealed class ApiRequestHandler(HttpClient httpClient)
{
    private readonly HttpClient _httpClient = httpClient;
    private readonly JsonSerializerOptions _serializerOptions = new()
    {
        PropertyNameCaseInsensitive = true
    };

    public void SetAuthenticationHeaderValue(AuthenticationHeaderValue header)
    {
        this._httpClient.DefaultRequestHeaders.Authorization = header;
    }

    public async Task<ApiResult<TResponse>> PostAsync<TRequest, TResponse>(string url, TRequest request)
    {
        try
        {
            HttpResponseMessage response = await this._httpClient.PostAsJsonAsync(url, request);

            string content = await response.Content.ReadAsStringAsync();

            return this.HandleResponse<TResponse>(response, content);
        }
        catch (Exception ex)
        {
            return ApiResult<TResponse>.Failure("通信エラー: " + ex.Message);
        }
    }

    public async Task<ApiResult<TResponse>> GetAsync<TRequest, TResponse>(string url)
    {
        try
        {
            HttpResponseMessage response = await this._httpClient.GetAsync(url);

            string content = await response.Content.ReadAsStringAsync();

            return this.HandleResponse<TResponse>(response, content);
        }
        catch (Exception ex)
        {
            return ApiResult<TResponse>.Failure("通信エラー: " + ex.Message);
        }
    }

    private ApiResult<TResponse> HandleResponse<TResponse>(HttpResponseMessage response, string jsonString)
    {
        if (response.IsSuccessStatusCode)
        {
            TResponse? result = JsonSerializer.Deserialize<TResponse>(jsonString, this._serializerOptions);

            return result != null
                ? ApiResult<TResponse>.Success(result)
                : ApiResult<TResponse>.Failure("レスポンスの解析に失敗しました。");
        }
        else
        {
            ErrorResponse? error = JsonSerializer.Deserialize<ErrorResponse>(jsonString, this._serializerOptions);

            string message = error?.Message ?? "不明なエラーが発生しました。";

            return ApiResult<TResponse>.Failure(message);
        }
    }
}
