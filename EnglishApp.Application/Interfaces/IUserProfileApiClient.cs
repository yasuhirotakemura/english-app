using EnglishApp.Application.Dtos.UserProfile;
using EnglishApp.Domain.Entities;

namespace EnglishApp.Application.Interfaces;

public interface IUserProfileApiClient
{
    Task<ApiResult<UserProfileEntity>> CreateAsync(UserProfileSetupRequest request);
    Task<ApiResult<UserProfileEntity>> GetAsync(int userId);
    Task<ApiResult<IconUri[]>> GetProfileImageUris();
}
