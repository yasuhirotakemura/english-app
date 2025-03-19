using EnglishApp.Domain.Services;
using Microsoft.AspNetCore.Mvc;

namespace EnglishApp.Api.Controllers;

[Route("api/master")]
[ApiController]
public class MasterController(IRepositoryService repositoryService) : ControllerBase
{
    private readonly IRepositoryService _repositoryService = repositoryService;

    [HttpGet]
    public async Task<IActionResult> GetAllMasters()
    {
        var result = new
        {
            Prefectures = await this._repositoryService.PrefectureRepository().GetAll(),
            UserGrades = await this._repositoryService.UserGradeRepository().GetAll(),
            UserLearningPurposes = await this._repositoryService.UserLearningPurposeRepository().GetAll(),
        };

        return Ok(result);
    }
}