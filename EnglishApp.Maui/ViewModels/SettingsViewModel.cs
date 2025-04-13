using CommunityToolkit.Mvvm.Input;
using EnglishApp.Domain.Interfaces;
using EnglishApp.Maui.Routes;
using EnglishApp.Maui.ViewModels.Bases;

namespace EnglishApp.Maui.ViewModels;

public sealed class SettingsViewModel : ViewModelBase
{
    public SettingsViewModel(IMessageService messageService, INavigationService navigationService) : base(messageService, navigationService)
    {
        this.UserProfileSettingCommand = new AsyncRelayCommand(this.OnUserProfileSettingButton);
    }

    public IAsyncRelayCommand UserProfileSettingCommand { get; }
    private async Task OnUserProfileSettingButton()
    {
        await this.NavigationService.NavigateToAsync(route: AppShellRoute.UserProfileView);
    }
}
