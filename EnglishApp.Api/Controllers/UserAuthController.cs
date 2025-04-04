using EnglishApp.Api.Services;
using EnglishApp.Application.Dtos.Requests;
using EnglishApp.Application.Dtos.Responses;
using EnglishApp.Domain.Entities;
using EnglishApp.Domain.Exceptions;
using EnglishApp.Domain.Logics;
using EnglishApp.Domain.Repositories;
using EnglishApp.Domain.ValueObjects;
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
        try
        {
            int userId = await this._userRepository.CreateUser();

            PasswordHash passwordHash = PasswordHash.CreateFromBase64(base64Hash: request.PasswordHash,
                                                                      base64Salt: request.Salt);

            UserAuthEntity entity = new(id: userId,
                                        email: request.Email,
                                        passwordHash: passwordHash.Hash,
                                        salt: passwordHash.Salt);

            await this._userAuthRepository.SignUp(entity);

            string accessToken = this._jwtService.GenerateToken(userId);

            UserAuthSignUpResponse response = new(message: "登録完了",
                                                  userId: userId,
                                                  accessToken: accessToken);

            return this.Ok(response);
        }
        catch
        {
            // loggingの追加
            return this.StatusCode(500, new ErrorResponse("サーバー側でエラーが発生しました。"));
        }
    }

    [HttpPost("signin")]
    public async Task<IActionResult> SingIn([FromBody] UserAuthSignInRequest request)
    {
        try
        {
            byte[] passwordHash = PasswordHasher.ConvertFromBase64String(request.PasswordHash);

            UserSignInEntity? entity = await this._userAuthRepository.SignIn(email: request.Email,
                                                                             passwordHash: passwordHash);

            if(entity is UserSignInEntity userSignInEntity)
            {
                string accessToken = this._jwtService.GenerateToken(userSignInEntity.UserId);

                UserAuthSignInResponse response = new(message: "ログイン完了",
                                                      userId: userSignInEntity.UserId,
                                                      nickName: userSignInEntity.NickName,
                                                      isEmailVerified: userSignInEntity.IsEmailVerified,
                                                      accessToken: accessToken);

                return this.Ok(response);
            }
            else
            {
                return this.Unauthorized(new ErrorResponse("パスワードが間違っています。"));
            }   
        }
        catch
        {
            // loggingの追加
            return this.StatusCode(500, new ErrorResponse("サーバー側でエラーが発生しました。"));
        }
    }

    [HttpPost("signin/salt")]
    public async Task<IActionResult> GetSalt([FromBody] UserAuthSaltRequest request)
    {
        try
        {
            byte[] salt = await this._userAuthRepository.GetSaltByEmail(request.Email);

            string saltBase64 = PasswordHasher.ConvertToBase64String(salt);

            UserAuthSaltResponse response = new(message: "データベースからSaltを取得",
                                                saltBase64: saltBase64);

            return this.Ok(response);
        }
        catch (EmailNotFoundException ex)
        {
            return this.Unauthorized(new ErrorResponse(ex.Message));
        }
        catch
        {
            // loggingの追加
            return this.StatusCode(500, new ErrorResponse("サーバー側でエラーが発生しました。"));
        }
    }

    [HttpGet("validate")]
    public async Task<IActionResult> ValidateToken()
    {
        try
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

            UserAuthSignInResponse response = new(
                message: "自動ログイン成功",
                userId: user.UserId,
                nickName: user.NickName,
                isEmailVerified: user.IsEmailVerified,
                String.Empty
            );

            return this.Ok(response);
        }
        catch
        {
            return this.StatusCode(500, new ErrorResponse("サーバー側でエラーが発生しました。"));
        }
    }

}
