using EnglishApp.Application.Dtos.Requests;
using EnglishApp.Application.Dtos.Responses;
using EnglishApp.Application.Factories;
using EnglishApp.Domain.Entities;
using EnglishApp.Domain.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace EnglishApp.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UserProfilesController(IUserProfileRepository userProfileRepository) : ControllerBase
{
    private readonly IUserProfileRepository _userProfileRepository = userProfileRepository;

    [HttpPost]
    public async Task<IActionResult> Create(UserProfileSetupRequest request)
    {
        try
        {
            UserProfileInsertEntity userProfileInsertEntity = new(userId: request.UserId,
                                                                  nickName: request.NickName,
                                                                  gender: request.Gender,
                                                                  gradeId: request.GradeId,
                                                                  learningPurposeId: request.LearningPurposeId,
                                                                  prefectureId: request.PrefectureId,
                                                                  birthDate: request.BirthDate,
                                                                  profileText: request.ProfileText);

            UserProfileEntity? entity = await this._userProfileRepository.Create(userProfileInsertEntity);

            if(entity is UserProfileEntity userProfileEntity)
            {
                UserProfileSetupResponse response = ResponseFactory.CreateUserProfileSetupResponse(message: "ユーザー情報の登録が完了しました。",
                                                                                                   entity: userProfileEntity);

                return this.Ok(response);
            }
            else
            {
                return this.Unauthorized(new ErrorResponse("ユーザー情報の取得に失敗しました。"));
            }
        }
        catch
        {
            // loggingの追加
            return this.StatusCode(500, new ErrorResponse("サーバー側でエラーが発生しました。"));
        }
    }
}
