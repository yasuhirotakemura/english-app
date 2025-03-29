using EnglishApp.Application.Apis;
using EnglishApp.Application.Dtos.Requests;
using EnglishApp.Application.Dtos.Responses;
using System.Net.Http.Headers;

namespace EnglishApp.Application.Services;

public sealed class UserAuthApiService(ApiRequestHandler handlePostRequestAsync) : IUserAuthApiService
{
    private readonly ApiRequestHandler _handlePostRequestAsync = handlePostRequestAsync;

    public bool CanAutoLoginAsync(string? token)
    {
        if (!String.IsNullOrWhiteSpace(token))
        {
            AuthenticationHeaderValue header = new("Bearer", token);

            this._handlePostRequestAsync.SetAuthenticationHeaderValue(header);

            return true;
        }

        return false;
    }

    public async Task<ApiResult<UserAuthSignInResponse>> AutoSignInAsync()
    {
        return await this._handlePostRequestAsync.GetAsync<UserAuthSignInRequest, UserAuthSignInResponse>("api/userauth/validate");
    }

    public async Task<ApiResult<UserAuthSignInResponse>> SignInAsync(UserAuthSignInRequest request)
    {
        return await this._handlePostRequestAsync.PostAsync<UserAuthSignInRequest, UserAuthSignInResponse>("api/userauth/signin", request);
    }

    public async Task<ApiResult<UserAuthSignUpResponse>> SignUpAsync(UserAuthSignUpRequest request)
    {
        return await this._handlePostRequestAsync.PostAsync<UserAuthSignUpRequest, UserAuthSignUpResponse>("api/userauth/signup", request);
    }

    public async Task<ApiResult<UserAuthSaltResponse>> GetSaltAsync(UserAuthSaltRequest request)
    {
        return await this._handlePostRequestAsync.PostAsync<UserAuthSaltRequest, UserAuthSaltResponse>("api/userauth/signin/salt", request);
    }
}
