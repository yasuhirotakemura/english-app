using EnglishApp.Domain.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace EnglishApp.Api.Controllers;

[Route("api/master")]
[ApiController]
public class MasterController(IPrefectureRepository prefectureRepository, IUserGradeRepository userGradeRepository, IUserLearningPurposeRepository userLearningPurposeRepository) : ControllerBase
{
    private readonly IPrefectureRepository _prefectureRepository = prefectureRepository;
    private readonly IUserGradeRepository _userGradeRepository = userGradeRepository;
    private readonly IUserLearningPurposeRepository _userLearningPurposeRepository = userLearningPurposeRepository;

    [HttpGet]
    public async Task<IActionResult> GetAllMasters()
    {
        var result = new
        {
            Prefectures = await this._prefectureRepository.GetAll(),
            UserGrades = await this._userGradeRepository.GetAll(),
            UserLearningPurposes = await this._userLearningPurposeRepository.GetAll(),
        };

        return this.Ok(result);
    }
}