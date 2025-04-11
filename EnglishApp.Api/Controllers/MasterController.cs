using EnglishApp.Application.Dtos.Master;
using EnglishApp.Domain.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace EnglishApp.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class MasterController(IPrefectureRepository prefectureRepository,
                              IUserGenderRepository userGenderRepository,
                              IUserGradeRepository userGradeRepository,
                              IUserLearningPurposeRepository userLearningPurposeRepository) : ControllerBase
{
    private readonly IPrefectureRepository _prefectureRepository = prefectureRepository;
    private readonly IUserGenderRepository _userGenderRepository = userGenderRepository;
    private readonly IUserGradeRepository _userGradeRepository = userGradeRepository;
    private readonly IUserLearningPurposeRepository _userLearningPurposeRepository = userLearningPurposeRepository;

    [HttpGet]
    public async Task<IActionResult> GetAllMasters()
    {
        MasterDataResponse result = new(prefectures: await this._prefectureRepository.GetAll(),
                                        userGenders: await this._userGenderRepository.GetAll(),
                                        userGrades: await this._userGradeRepository.GetAll(),
                                        userLearningPurposes: await this._userLearningPurposeRepository.GetAll());

        return this.Ok(result);
    }
}