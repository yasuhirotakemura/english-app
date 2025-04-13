using EnglishApp.Application.Dtos.Error;
using EnglishApp.Application.Dtos.UserProfile;
using EnglishApp.Domain.Entities;
using EnglishApp.Domain.Repositories;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Immutable;

namespace EnglishApp.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UserProfileController(IUserProfileRepository userProfileRepository,
                                   IPrefectureRepository prefectureRepository,
                                   IUserGenderRepository userGenderRepository,
                                   IUserGradeRepository userGradeRepository,
                                   IUserLearningPurposeRepository userLearningPurposeRepository) : ControllerBase
{
    private readonly IUserProfileRepository _userProfileRepository = userProfileRepository;
    private readonly IPrefectureRepository _prefectureRepository = prefectureRepository;
    private readonly IUserGenderRepository _userGenderRepository = userGenderRepository;
    private readonly IUserGradeRepository _userGradeRepository = userGradeRepository;
    private readonly IUserLearningPurposeRepository _userLearningPurposeRepository = userLearningPurposeRepository;

    [HttpPost]
    public async Task<IActionResult> Create(UserProfileSetupRequest request)
    {
        UserProfileInsertEntity userProfileInsertEntity = new(userId: request.UserId,
                                                              nickName: request.NickName,
                                                              genderId: request.Gender,
                                                              gradeId: request.GradeId,
                                                              learningPurposeId: request.LearningPurposeId,
                                                              prefectureId: request.PrefectureId,
                                                              birthDate: request.BirthDate,
                                                              profileText: request.ProfileText,
                                                              iconUri: request.IconUri.Replace($"{this.Request.Scheme}:{this.Request.Host}/", ""));

        UserProfileEntity? entity = await this._userProfileRepository.Create(userProfileInsertEntity);

        if (entity is UserProfileEntity userProfileEntity)
        {
            return this.Ok(userProfileEntity);
        }
        else
        {
            return this.Unauthorized(new ErrorResponse("ユーザー情報の取得に失敗しました。"));
        }
    }

    [HttpGet("{userId:int}")]
    public async Task<IActionResult> GetByUserId([FromRoute] int userId)
    {
        try
        {
            UserProfileEntity? entity = await this._userProfileRepository.GetByUserId(userId);

            if (entity is UserProfileEntity userProfileEntity)
            {
                return this.Ok(userProfileEntity);
            }
            else
            {
                return this.Unauthorized(new ErrorResponse("指定されたユーザーのプロフィールが見つかりません。"));
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);

            return this.StatusCode(500, new ErrorResponse("サーバーエラーが発生しました。"));
        }
    }

    [HttpGet("setup")]
    public async Task<IActionResult> GetUserSetupData()
    {
        UserSetupDataResponse result = new(prefectures: await this._prefectureRepository.GetAll(),
                                           genders: await this._userGenderRepository.GetAll(),
                                           grades: await this._userGradeRepository.GetAll(),
                                           learningPurposes: await this._userLearningPurposeRepository.GetAll(),
                                           iconUris: this.GetAvailableIcons());

        return this.Ok(result);
    }

    private ImmutableList<IconUri> GetAvailableIcons()
    {
        string iconFolder = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "icons");
        string[] iconFiles = Directory.GetFiles(iconFolder);

        List<string> fileNames = [];

        foreach (string iconFile in iconFiles)
        {
            string? s = Path.GetFileName(iconFile);

            if (s is string fileName)
            {
                fileNames.Add(fileName);
            }
        }

        string baseUrl = $"{this.Request.Scheme}://{this.Request.Host}/icons/";

        return [.. fileNames.Select(f => new IconUri(baseUrl + f))];
    }
}
