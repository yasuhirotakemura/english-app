using EnglishApp.Domain.Entities;
using EnglishApp.Maui.Services;
using EnglishApp.Maui.ViewModels.Bases;
using System.Collections.Immutable;
using System.Collections.ObjectModel;

namespace EnglishApp.Maui.ViewModels;

public class ProblemViewModel : ViewModelBase, IQueryAttributable
{
    public async void ApplyQueryAttributes(IDictionary<string, object> query)
    {
        if(query[nameof(EnglishTextEntity)] is not EnglishTextEntity englishTextEntity)
        {
            return;
        }

        this.Title = englishTextEntity.Title;
        this.Content = englishTextEntity.Content;

        ImmutableList<EnglishChoiceQuestionEntity>? entities =  await new EnglishChoiceQuestionService(new()).GetChoiceQuestionsAsync(englishTextEntity.Id);

        if(entities is not null)
        {
            foreach(EnglishChoiceQuestionEntity e in entities)
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

    public ObservableCollection<EnglishChoiceQuestionEntity> Choices { get; } = [];
}