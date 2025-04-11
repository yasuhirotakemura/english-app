using EnglishApp.Application.Dtos.UserProfile;
using EnglishApp.Application.Interfaces;
using EnglishApp.Domain.Entities;

namespace EnglishApp.Application.ApiClients;

public sealed class UserProfileApiClient(ApiRequestHandler apiRequestHandler) : IUserProfileApiClient
{
    private readonly ApiRequestHandler _apiRequestHandler = apiRequestHandler;

    public async Task<ApiResult<UserProfileEntity>> CreateAsync(UserProfileSetupRequest request)
    {
        return await this._apiRequestHandler.PostAsync<UserProfileSetupRequest, UserProfileEntity>("api/userprofile", request);
    }

    public async Task<ApiResult<UserProfileEntity>> GetAsync(int userId)
    {
        return await this._apiRequestHandler.GetAsync<UserProfileEntity>($"api/userprofile/{userId}");
    }

    public async Task<ApiResult<IconUri[]>> GetProfileImageUris()
    {
        return await this._apiRequestHandler.GetAsync<IconUri[]>("api/userprofile/icons");
    }
}
