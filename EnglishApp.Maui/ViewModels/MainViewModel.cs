using EnglishApp.Domain.Entities;
using EnglishApp.Maui.Services;
using System.Collections.Immutable;
using System.Collections.ObjectModel;
using System.Diagnostics;

namespace EnglishApp.Maui.ViewModels;

public sealed class MainViewModel : BindableBase
{
    private readonly EnglishTextService _englishTextService;

    public ObservableCollection<EnglishTextEntity> EnglishTexts { get; }

    public MainViewModel()
    {
        this._englishTextService = new(new());

        this.EnglishTexts = [];

        this.LoadTextsCommand = new(async () => await this.LoadEnglishTextsAsync());
        this.QuestionItemTappedCommand = new(this.OnQuestionItemTappedCommand);
    }

    public DelegateCommand LoadTextsCommand { get; }
    private async Task LoadEnglishTextsAsync()
    {
        ImmutableList<EnglishTextEntity>? texts = await this._englishTextService.GetEnglishTextsAsync();

        if (texts is not null)
        {
            this.EnglishTexts.Clear();

            foreach (EnglishTextEntity text in texts)
            {
                this.EnglishTexts.Add(text);
            }
        }
    }

    public DelegateCommand<EnglishTextEntity> QuestionItemTappedCommand { get; }
    private void OnQuestionItemTappedCommand(EnglishTextEntity entity)
    {
        Debug.WriteLine("HELLO MAUI");
    }
}