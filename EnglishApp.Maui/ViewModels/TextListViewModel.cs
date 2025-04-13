using CommunityToolkit.Mvvm.Input;
using EnglishApp.Domain.Interfaces;
using EnglishApp.Maui.ViewModels.Bases;

namespace EnglishApp.Maui.ViewModels;

public sealed class TextListViewModel : ViewModelBase
{
    public TextListViewModel(IMessageService messageService, INavigationService navigationService) : base(messageService, navigationService)
    {

        this.NavigateToJuniorYear1Command = new AsyncRelayCommand(() => this.NavigationService.NavigateToAsync("JuniorYear1"));
        this.NavigateToJuniorYear2Command = new AsyncRelayCommand(() => this.NavigationService.NavigateToAsync("JuniorYear2"));
        this.NavigateToJuniorYear3Command = new AsyncRelayCommand(() => this.NavigationService.NavigateToAsync("JuniorYear3"));

        this.NavigateToSeniorYear1Command = new AsyncRelayCommand(() => this.NavigationService.NavigateToAsync("SeniorYear1"));
        this.NavigateToSeniorYear2Command = new AsyncRelayCommand(() => this.NavigationService.NavigateToAsync("SeniorYear2"));
        this.NavigateToSeniorYear3Command = new AsyncRelayCommand(() => this.NavigationService.NavigateToAsync("SeniorYear3"));
    }

    public IAsyncRelayCommand NavigateToJuniorYear1Command { get; }
    public IAsyncRelayCommand NavigateToJuniorYear2Command { get; }
    public IAsyncRelayCommand NavigateToJuniorYear3Command { get; }

    public IAsyncRelayCommand NavigateToSeniorYear1Command { get; }
    public IAsyncRelayCommand NavigateToSeniorYear2Command { get; }
    public IAsyncRelayCommand NavigateToSeniorYear3Command { get; }

    private async Task OnNavigateToJuniorYear1Command()
    {
        await this.NavigationService.NavigateToAsync("");
    }
}
