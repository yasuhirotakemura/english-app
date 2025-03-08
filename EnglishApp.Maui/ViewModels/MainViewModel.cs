using CommunityToolkit.Mvvm.Input;
using EnglishApp.Domain.Entities;
using EnglishApp.Maui.Services;
using EnglishApp.Maui.ViewModels.Bases;
using EnglishApp.Maui.Views;
using System.Collections.Immutable;
using System.Collections.ObjectModel;

namespace EnglishApp.Maui.ViewModels;

public sealed class MainViewModel : ViewModelBase
{
    private readonly EnglishTextService _englishTextService;

    public ObservableCollection<EnglishTextEntity> EnglishTexts { get; }

    private EnglishTextEntity? _selectedEnglishText;
    public EnglishTextEntity? SelectedEnglishText
    {
        get => this._selectedEnglishText;
        set
        {
            if(value is not EnglishTextEntity englishTextEntity)
            {
                return;
            }

            this.OnProblemSelected(englishTextEntity);
        }
    }

    private void OnProblemSelected(EnglishTextEntity englishText)
    {
        Dictionary<string, object> navigationParameter = new()
        {
            { nameof(EnglishTextEntity), englishText },
        };

        this.NavigateToAsync(nameof(ProblemView), navigationParameter);
    }

    public MainViewModel()
    {
        this._englishTextService = new(new());

        this.EnglishTexts = [];

        this.LoadTextsCommand = new AsyncRelayCommand(this.LoadEnglishTextsAsync);
    }

    public IAsyncRelayCommand LoadTextsCommand { get; }
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
}