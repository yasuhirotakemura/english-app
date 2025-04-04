using EnglishApp.Application.Dtos.Requests;
using EnglishApp.Domain.Entities;

namespace EnglishApp.Application.Apis;

public interface IUserProfileApiService
{
    Task<ApiResult<UserProfileEntity>> CreateAsync(UserProfileSetupRequest request);
    Task<ApiResult<UserProfileEntity>> GetAsync(int userId);
    Task<ApiResult<IconUri[]>> GetProfileImageUris();
}
