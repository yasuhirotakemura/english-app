using EnglishApp.Application.Dtos;

namespace EnglishApp.Application.Apis;

public interface IUserAuthApiService
{
    Task<bool> SignUpAsync(UserAuthSignUpRequest request);
}