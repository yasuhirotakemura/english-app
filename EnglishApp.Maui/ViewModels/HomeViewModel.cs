using CommunityToolkit.Mvvm.Input;
using EnglishApp.Application.Interfaces;
using EnglishApp.Domain.Entities;
using EnglishApp.Maui.ViewModels.Bases;
using EnglishApp.Maui.Views;
using System.Collections.Immutable;
using System.Collections.ObjectModel;

namespace EnglishApp.Maui.ViewModels;

public sealed class HomeViewModel : ViewModelBase
{
    private readonly IEnglishTextApiService _englishTextApiService;

    public ObservableCollection<EnglishTextEntity> EnglishTexts { get; } = [];

    public HomeViewModel(IEnglishTextApiService englishTextApiService)
    {
        this._englishTextApiService = englishTextApiService;

        this.LoadTextsCommand = new AsyncRelayCommand(this.LoadEnglishTextsAsync);
    }

    public IAsyncRelayCommand LoadTextsCommand { get; }
    private async Task LoadEnglishTextsAsync()
    {
        ImmutableList<EnglishTextEntity>? texts = await this._englishTextApiService.GetEnglishTextsAsync();

        if (texts is not null)
        {
            this.EnglishTexts.Clear();

            foreach (EnglishTextEntity text in texts)
            {
                this.EnglishTexts.Add(text);
            }
        }
    }

    private EnglishTextEntity? _selectedEnglishText;
    public EnglishTextEntity? SelectedEnglishText
    {
        get => this._selectedEnglishText;
        set
        {
            if (value is not EnglishTextEntity englishTextEntity)
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
}