using EnglishApp.Application.Dtos.Requests;
using EnglishApp.Application.Dtos.Responses;
using EnglishApp.Application.Factories;
using EnglishApp.Domain.Entities;
using EnglishApp.Domain.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace EnglishApp.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UserProfileController(IUserProfileRepository userProfileRepository) : ControllerBase
{
    private readonly IUserProfileRepository _userProfileRepository = userProfileRepository;

    [HttpPost]
    public async Task<IActionResult> Create(UserProfileSetupRequest request)
    {
        try
        {
            UserProfileInsertEntity userProfileInsertEntity = new(request.UserId,
                                     request.NickName,
                                     request.Gender,
                                     request.GradeId,
                                     request.LearningPurposeId,
                                     request.PrefectureId,
                                     request.BirthDate,
                                     request.ProfileText);

            UserProfileEntity? entity = await this._userProfileRepository.Create(userProfileInsertEntity);

            if(entity is UserProfileEntity userProfileEntity)
            {
                UserProfileSetupResponse response = ResponseFactory.CreateUserProfileSetupResponse("ユーザー情報の登録が完了しました。", userProfileEntity);

                return this.Ok(response);
            }
            else
            {
                ErrorResponse errorResponse = new("ユーザー情報作成後の取得に失敗しました。", "エラー");

                return this.StatusCode(500, errorResponse);
            }
        }
        catch (Exception ex)
        {
            ErrorResponse errorResponse = new(ex.Message, "エラー");

            return this.StatusCode(500, errorResponse);
        }
    }
}
