using EnglishApp.Api.Services;
using EnglishApp.Application.Dtos.Error;
using EnglishApp.Application.Dtos.UserAuth;
using EnglishApp.Domain.Entities;
using EnglishApp.Domain.Logics;
using EnglishApp.Domain.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace EnglishApp.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UserAuthController(JwtService jwtService, IUserRepository userRepository, IUserAuthRepository userAuthRepository) : ControllerBase
{
    private readonly JwtService _jwtService = jwtService;
    private readonly IUserRepository _userRepository = userRepository;
    private readonly IUserAuthRepository _userAuthRepository = userAuthRepository;

    [HttpPost("signup")]
    public async Task<IActionResult> SignUp([FromBody] UserAuthSignUpRequest request)
    {

        int userId = await this._userRepository.CreateUser();

        UserAuthEntity entity = request.ToEntity(userId);

        await this._userAuthRepository.SignUp(entity);

        string accessToken = this._jwtService.GenerateToken(userId);

        UserAuthSignUpResponse response = new(userId: userId,
                                              accessToken: accessToken);

        return this.Ok(response);
    }

    [HttpPost("signin")]
    public async Task<IActionResult> SingIn([FromBody] UserAuthSignInRequest request)
    {

        byte[] passwordHash = PasswordHasher.ConvertFromBase64String(request.PasswordHash);

        UserSignInEntity entity = await this._userAuthRepository.SignIn(email: request.Email,
                                                                         passwordHash: passwordHash);

        string accessToken = this._jwtService.GenerateToken(entity.UserId);

        UserAuthSignInResponse response = new(userId: entity.UserId,
                                              nickName: entity.NickName,
                                              isEmailVerified: entity.IsEmailVerified,
                                              accessToken: accessToken);

        return this.Ok(response);
    }

    [HttpPost("signin/salt")]
    public async Task<IActionResult> GetSalt([FromBody] string email)
    {

        byte[] salt = await this._userAuthRepository.GetSaltByEmail(email);

        string saltBase64 = PasswordHasher.ConvertToBase64String(salt);

        UserAuthSaltResponse response = new(saltBase64);

        return this.Ok(response);
    }

    [HttpGet("validate")]
    public async Task<IActionResult> ValidateToken()
    {

        string? token = this.HttpContext.Request.Headers.Authorization.ToString().Replace("Bearer ", "");

        if (String.IsNullOrWhiteSpace(token))
        {
            return this.Unauthorized(new ErrorResponse("トークンが指定されていません。"));
        }

        int? value = this._jwtService.ValidateToken(token);

        if (value is not int userId)
        {
            return this.Unauthorized(new ErrorResponse("トークンが無効または期限切れです。"));
        }

        UserSignInEntity? user = await this._userAuthRepository.AutoSignIn(userId);

        if (user == null)
        {
            return this.Unauthorized(new ErrorResponse("ユーザーが存在しません。"));
        }

        UserAuthSignInResponse response = new(userId: user.UserId,
                                              nickName: user.NickName,
                                              isEmailVerified: user.IsEmailVerified,
                                              String.Empty);

        return this.Ok(response);
    }
}
