using EnglishApp.Application.Dtos.UserAuth;

namespace EnglishApp.Application.Interfaces;

public interface IUserAuthApiClient
{
    void SetAuthenticationHeaderValue(string token);
    Task<ApiResult<UserAuthSignInResponse>> AutoSignInAsync();
    Task<ApiResult<UserAuthSignInResponse>> SignInAsync(UserAuthSignInRequest request);
    Task<ApiResult<UserAuthSignUpResponse>> SignUpAsync(UserAuthSignUpRequest request);
    Task<ApiResult<UserAuthSaltResponse>> GetSaltAsync(string email);
}