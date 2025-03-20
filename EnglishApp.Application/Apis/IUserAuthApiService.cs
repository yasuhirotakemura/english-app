using EnglishApp.Application.Dtos;

namespace EnglishApp.Application.Apis;

public interface IUserAuthApiService
{
    Task<UserAuthSignUpResponse?> SignUpAsync(UserAuthSignUpRequest request);
}