using EnglishApp.Application.Dtos.Requests;
using EnglishApp.Application.Dtos.Responses;

namespace EnglishApp.Application.Apis;

public interface IUserAuthApiService
{
    Task<UserAuthSignUpResponse?> SignUpAsync(UserAuthSignUpRequest request);
    Task<UserAuthSaltResponse?> GetSaltAsync(UserAuthSaltRequest request);
    Task<UserAuthSignInResponse?> SignInAsync(UserAuthSignInRequest request);
}