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

    private IEnglishChoiceQuestionRepository? _englishChoiceQuestionRepository;
    public IEnglishChoiceQuestionRepository EnglishChoiceQuestionRepository()
    {
        return this._englishChoiceQuestionRepository ??= new EnglishChoiceQuestionRepository(this._sqlServer);
    }

    private IPrefectureRepository? _prefectureRepository;
    public IPrefectureRepository PrefectureRepository()
    {
        return this._prefectureRepository ??= new PrefectureRepository(this._sqlServer);
    }

    private IUserGradeRepository? _userGradeRepository;
    public IUserGradeRepository UserGradeRepository()
    {
        return this._userGradeRepository ??= new UserGradeRepository(this._sqlServer);
    }

    private IUserLearningPurposeRepository? _userLearningPurposeRepository;
    public IUserLearningPurposeRepository UserLearningPurposeRepository()
    {
        return this._userLearningPurposeRepository ??= new UserLearningPurposeRepository(this._sqlServer);
    }
}
