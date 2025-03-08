using EnglishApp.Domain.Repositories;

namespace EnglishApp.Domain.Services;

public interface IRepositoryService
{
    public IEnglishTextRepository EnglishTextRepository();
    public IEnglishChoiceQuestionRepository EnglishChoiceQuestionRepository();
}
