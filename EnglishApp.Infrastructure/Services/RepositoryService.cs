using EnglishApp.Domain.Repositories;
using EnglishApp.Domain.Services;
using EnglishApp.Infrastructure.Repositories;

namespace EnglishApp.Infrastructure.Services;

public sealed class RepositoryService(SqlServerService sqlServer) : IRepositoryService
{
    private readonly SqlServerService _sqlServer = sqlServer;

    private IEnglishTextRepository? _englishTextRepository;
    public IEnglishTextRepository EnglishTextRepository()
    {
        return this._englishTextRepository ??= new EnglishTextRepository(this._sqlServer);
    }

    private IEnglishQuestionRepository? _englishQuestionRepository;
    public IEnglishQuestionRepository EnglishQuestionRepository()
    {
        return this._englishQuestionRepository ??= new EnglishQuestionRepository(this._sqlServer);
    }
}
