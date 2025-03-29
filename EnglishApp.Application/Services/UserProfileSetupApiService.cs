using EnglishApp.Application.Apis;
using EnglishApp.Application.Dtos.Requests;
using EnglishApp.Application.Dtos.Responses;

namespace EnglishApp.Application.Services;

public sealed class UserProfileSetupApiService(ApiRequestHandler handlePostRequestAsync) : IUserProfileApiService
{
    private readonly ApiRequestHandler _handlePostRequestAsync = handlePostRequestAsync;

    public async Task<ApiResult<UserProfileSetupResponse>> CreateAsync(UserProfileSetupRequest request)
    {
        return await this._handlePostRequestAsync.PostAsync<UserProfileSetupRequest, UserProfileSetupResponse>("api/userprofiles", request);
    }
}
