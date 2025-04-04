using EnglishApp.Application.Apis;
using EnglishApp.Application.Dtos.Requests;
using EnglishApp.Domain.Entities;

namespace EnglishApp.Application.Services;

public sealed class UserProfileApiService(ApiRequestHandler handlePostRequestAsync) : IUserProfileApiService
{
    private readonly ApiRequestHandler _handlePostRequestAsync = handlePostRequestAsync;

    public async Task<ApiResult<UserProfileEntity>> CreateAsync(UserProfileSetupRequest request)
    {
        return await this._handlePostRequestAsync.PostAsync<UserProfileSetupRequest, UserProfileEntity>("api/userprofile", request);
    }

    public async Task<ApiResult<UserProfileEntity>> GetAsync(int userId)
    {
        return await this._handlePostRequestAsync.GetAsync<object, UserProfileEntity>($"api/userprofile/{userId}");
    }

    public async Task<ApiResult<IconUri[]>> GetProfileImageUris()
    {
        return await this._handlePostRequestAsync.GetAsync<object, IconUri[]>("api/userprofile/icons");
    }
}
