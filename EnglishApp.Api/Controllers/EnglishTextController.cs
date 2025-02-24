using EnglishApp.Domain.Entities;
using EnglishApp.Domain.Repositories;
using EnglishApp.Domain.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Immutable;

namespace EnglishApp.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public sealed class EnglishTextController(IRepositoryService repositoryService) : ControllerBase
{
    private readonly IRepositoryService _repositoryService = repositoryService;

    [HttpGet]
    public async Task<ActionResult<ImmutableList<EnglishTextEntity>>> GetAll()
    {
        var texts = await this._repositoryService.EnglishTextRepository().GetAll();

        return Ok(texts);
    }
}
