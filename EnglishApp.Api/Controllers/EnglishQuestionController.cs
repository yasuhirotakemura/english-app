using EnglishApp.Domain.Entities;
using EnglishApp.Domain.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Immutable;

namespace EnglishApp.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public sealed class EnglishQuestionController(IRepositoryService repositoryService) : ControllerBase
{
    private readonly IRepositoryService _repositoryService = repositoryService;

    [HttpGet]
    public async Task<ActionResult<ImmutableList<EnglishQuestionEntity>>> GetAll()
    {
        var questions = await this._repositoryService.EnglishQuestionRepository().GetAll();

        return Ok(questions);
    }
}
