using EnglishApp.Application.Dtos.Requests;
using EnglishApp.Application.Dtos.Responses;

namespace EnglishApp.Application.Apis;

public interface IUserProfileApiService
{
    Task<ApiResult<UserProfileSetupResponse>> CreateAsync(UserProfileSetupRequest request);
}
