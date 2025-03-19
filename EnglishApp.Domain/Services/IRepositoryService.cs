using EnglishApp.Domain.Repositories;

namespace EnglishApp.Domain.Services;

public interface IRepositoryService
{
    public IEnglishTextRepository EnglishTextRepository();
    public IEnglishChoiceQuestionRepository EnglishChoiceQuestionRepository();
    public IPrefectureRepository PrefectureRepository();
    public IUserGradeRepository UserGradeRepository();
    public IUserLearningPurposeRepository UserLearningPurposeRepository();
}
