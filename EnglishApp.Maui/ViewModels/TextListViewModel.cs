using CommunityToolkit.Mvvm.Input;
using EnglishApp.Domain.Interfaces;
using EnglishApp.Maui.ViewModels.Bases;

namespace EnglishApp.Maui.ViewModels;

public sealed class TextListViewModel : ViewModelBase
{
    public TextListViewModel(IMessageService messageService, INavigationService navigationService) : base(messageService, navigationService)
    {

    }

    public IAsyncRelayCommand NavigateToJuniorYear1Command { get; }
    public IAsyncRelayCommand NavigateToJuniorYear2Command { get; }
    public IAsyncRelayCommand NavigateToJuniorYear3Command { get; }

    public IAsyncRelayCommand NavigateToSeniorYear1Command { get; }
    public IAsyncRelayCommand NavigateToSeniorYear2Command { get; }
    public IAsyncRelayCommand NavigateToSeniorYear3Command { get; }
}
