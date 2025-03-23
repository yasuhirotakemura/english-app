using EnglishApp.Application.Dtos.Requests;
using EnglishApp.Application.Dtos.Responses;
using EnglishApp.Domain.Entities;
using EnglishApp.Domain.Repositories;
using EnglishApp.Domain.ValueObjects;
using Microsoft.AspNetCore.Mvc;

namespace EnglishApp.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UserController(IUserRepository userRepository, IUserAuthRepository userAuthRepository) : ControllerBase
{
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

            await this._userAuthRepository.CreateUserAuth(entity);

            UserAuthSignUpResponse response = new(userId, "登録完了");

            return this.Ok(response);
        }
        catch (Exception ex)
        {
            ErrorResponse errorResponse = new(ex.Message, "エラー");

            return this.StatusCode(500, errorResponse);
        }
    }
}
