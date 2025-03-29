using EnglishApp.Api.Services;
using EnglishApp.Application.Dtos.Requests;
using EnglishApp.Application.Dtos.Responses;
using EnglishApp.Domain.Entities;
using EnglishApp.Domain.Logics;
using EnglishApp.Domain.Repositories;
using EnglishApp.Domain.ValueObjects;
using Microsoft.AspNetCore.Mvc;

namespace EnglishApp.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UserController(JwtService jwtService, IUserRepository userRepository, IUserAuthRepository userAuthRepository) : ControllerBase
{
    private readonly JwtService _jwtService = jwtService;
    private readonly IUserRepository _userRepository = userRepository;
    private readonly IUserAuthRepository _userAuthRepository = userAuthRepository;

    [HttpPost("signup")]
    public async Task<IActionResult> SignUp([FromBody] UserAuthSignUpRequest request)
    {
        try
        {
            int userId = await this._userRepository.CreateUser();

            PasswordHash passwordHash = PasswordHash.CreateFromBase64(request.PasswordHash, request.Salt);

            UserAuthEntity entity = new(userId, request.Email, passwordHash.Hash, passwordHash.Salt);

            await this._userAuthRepository.SignUp(entity);

            string token = this._jwtService.GenerateToken(userId);

            UserAuthSignUpResponse response = new(userId, token, "登録完了");

            return this.Ok(response);
        }
        catch (Exception ex)
        {
            ErrorResponse errorResponse = new(ex.Message, "エラー");

            return this.StatusCode(500, errorResponse);
        }
    }

    [HttpPost("signin")]
    public async Task<IActionResult> SingIn([FromBody] UserAuthSignInRequest request)
    {
        try
        {
            byte[] passwordHash = PasswordHasher.ConvertFromBase64String(request.PasswordHash);

            UserSignInEntity? entity = await this._userAuthRepository.SignIn(request.Email, passwordHash);

            if(entity is UserSignInEntity userSignInEntity)
            {
                UserAuthSignInResponse response = new("ログイン完了！", userSignInEntity.UserId, userSignInEntity.NickName, userSignInEntity.IsEmailVerified);

                return this.Ok(response);
            }
            else
            {
                ErrorResponse errorResponse = new("メールアドレスとパスワードが一致しません。", "エラー");

                return this.StatusCode(500, errorResponse);
            }
        }
        catch (Exception ex)
        {
            ErrorResponse errorResponse = new(ex.Message, "エラー");

            return this.StatusCode(500, errorResponse);
        }
    }

    [HttpPost("signin/salt")]
    public async Task<IActionResult> GetSalt([FromBody] UserAuthSaltRequest request)
    {
        try
        {
            byte[] salt = await this._userAuthRepository.GetSaltByEmail(request.Email);

            string saltString = PasswordHasher.ConvertToBase64String(salt);

            UserAuthSaltResponse response = new(saltString, "文字列Salt返却");

            return this.Ok(response);
        }
        catch (Exception ex)
        {
            ErrorResponse errorResponse = new(ex.Message, "エラー");

            return this.StatusCode(500, errorResponse);
        }
    }
}
