using CommunityToolkit.Mvvm.Input;
using EnglishApp.Domain.Entities;
using EnglishApp.Maui.Services;
using EnglishApp.Maui.ViewModels.Bases;
using System.Collections.Immutable;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Windows.Input;

namespace EnglishApp.Maui.ViewModels;

public sealed class MainViewModel : ViewModelBase
{
    private readonly EnglishTextService _englishTextService;

    public ObservableCollection<EnglishTextEntity> EnglishTexts { get; }

    public MainViewModel()
    {
        this._englishTextService = new(new());

        this.EnglishTexts = [];

        this.LoadTextsCommand = new AsyncRelayCommand(this.LoadEnglishTextsAsync);
        this.QuestionItemTappedCommand = new AsyncRelayCommand(this.OnQuestionItemTappedCommand);
    }

    public ICommand LoadTextsCommand { get; }
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

    public ICommand QuestionItemTappedCommand { get; }
    private async Task OnQuestionItemTappedCommand()
    {
        Debug.WriteLine("HELLO MAUI");
    }
}