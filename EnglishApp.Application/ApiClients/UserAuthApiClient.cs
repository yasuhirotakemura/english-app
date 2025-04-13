using EnglishApp.Application.Dtos.UserAuth;
using EnglishApp.Application.Interfaces;
using System.Net.Http.Headers;
using System.Web;

namespace EnglishApp.Application.ApiClients;

public sealed class UserAuthApiClient(ApiRequestHandler apiRequestHandler) : IUserAuthApiClient
{
    private readonly ApiRequestHandler _apiRequestHandler = apiRequestHandler;

    public void SetAuthenticationHeaderValue(string token)
    {
        AuthenticationHeaderValue header = new("Bearer", token);

        this._apiRequestHandler.SetAuthenticationHeaderValue(header);
    }

    public async Task<ApiResult<UserAuthSignInResponse>> AutoSignInAsync()
    {
        return await this._apiRequestHandler.GetAsync<UserAuthSignInResponse>("userauth/validate");
    }

    public async Task<ApiResult<UserAuthSignInResponse>> SignInAsync(UserAuthSignInRequest request)
    {
        return await this._apiRequestHandler.PostAsync<UserAuthSignInRequest, UserAuthSignInResponse>("userauth/signin", request);
    }

    public async Task<ApiResult<UserAuthSignUpResponse>> SignUpAsync(UserAuthSignUpRequest request)
    {
        return await this._apiRequestHandler.PostAsync<UserAuthSignUpRequest, UserAuthSignUpResponse>("userauth/signup", request);
    }

    public async Task<ApiResult<UserAuthSaltResponse>> GetSaltAsync(string email)
    {
        string url = $"userauth/signin/salt?email={HttpUtility.UrlEncode(email)}";

        return await this._apiRequestHandler.GetAsync<UserAuthSaltResponse>(url);
    }
}
