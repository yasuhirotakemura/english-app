using EnglishApp.Application.Dtos;
using EnglishApp.Domain.Entities;
using EnglishApp.Domain.Repositories;
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

            byte[] passwordHash = Convert.FromBase64String(request.PasswordHash);
            byte[] salt = Convert.FromBase64String(request.Salt);

            UserAuthEntity entity = new(userId, request.Email, passwordHash, salt);

            await this._userAuthRepository.CreateUserAuth(entity);

            return this.Ok(new { Message = "登録完了", UserId = userId });
        }
        catch (Exception ex)
        {
            return this.StatusCode(500, new { Message = "エラーが発生しました", Error = ex.Message });
        }
    }
}
