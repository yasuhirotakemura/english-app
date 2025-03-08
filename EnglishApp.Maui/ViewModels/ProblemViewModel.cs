using EnglishApp.Application.Interfaces;
using EnglishApp.Domain.Entities;
using EnglishApp.Maui.ViewModels.Bases;
using System.Collections.Immutable;
using System.Collections.ObjectModel;

namespace EnglishApp.Maui.ViewModels;

public class ProblemViewModel : ViewModelBase, IQueryAttributable
{
    private readonly IChoiceQuestionApiService _choiceQuestionApiService;

    public ProblemViewModel(IChoiceQuestionApiService choiceQuestionApiService)
    {
        this._choiceQuestionApiService = choiceQuestionApiService;
    }

    public ObservableCollection<EnglishChoiceQuestionEntity> Choices { get; } = [];

    public async void ApplyQueryAttributes(IDictionary<string, object> query)
    {
        if (query[nameof(EnglishTextEntity)] is not EnglishTextEntity englishTextEntity)
        {
            return;
        }

        this.Title = englishTextEntity.Title;
        this.Content = englishTextEntity.Content;

        ImmutableList<EnglishChoiceQuestionEntity>? entities = await this._choiceQuestionApiService.GetChoiceQuestionsAsync(englishTextEntity.Id);

        if (entities is not null)
        {
            foreach (EnglishChoiceQuestionEntity e in entities)
            {
                this.Choices.Add(e);
            }
        }
    }

    private string _title = String.Empty;
    public string Title
    {
        get => this._title;
        set => this.SetProperty(ref this._title, value);
    }

    private string _content = String.Empty;
    public string Content
    {
        get => this._content;
        set => this.SetProperty(ref this._content, value);
    }
}