using EnglishApp.Domain.Entities;
using EnglishApp.Domain.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Immutable;

namespace EnglishApp.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public sealed class ChoiceQuestionController(IRepositoryService repositoryService) : ControllerBase
{
    private readonly IRepositoryService _repositoryService = repositoryService;

    [HttpGet]
    public async Task<ActionResult<ImmutableList<EnglishChoiceQuestionEntity>>> GetChoiceQuestionByEnglishId(
            [FromQuery] int englishTextId) // クエリパラメータとして受け取る
    {
        ImmutableList<EnglishChoiceQuestionEntity> questions =
            await this._repositoryService.EnglishChoiceQuestionRepository()
            .GetChoiceQuestionByEnglishTextId(englishTextId);

        return this.Ok(questions);
    }
}
