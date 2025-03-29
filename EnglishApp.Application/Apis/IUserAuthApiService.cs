using EnglishApp.Application.Dtos.Requests;
using EnglishApp.Application.Dtos.Responses;

namespace EnglishApp.Application.Apis;

public interface IUserAuthApiService
{
    bool CanAutoLoginAsync(string? token);

    Task<ApiResult<UserAuthSignInResponse>> AutoSignInAsync();
    Task<ApiResult<UserAuthSignInResponse>> SignInAsync(UserAuthSignInRequest request);
    Task<ApiResult<UserAuthSignUpResponse>> SignUpAsync(UserAuthSignUpRequest request);
    Task<ApiResult<UserAuthSaltResponse>> GetSaltAsync(UserAuthSaltRequest request);
}