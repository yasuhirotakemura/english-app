using CommunityToolkit.Mvvm.Input;
using EnglishApp.Maui.ViewModels.Bases;
using EnglishApp.Maui.Views;

namespace EnglishApp.Maui.ViewModels;

public sealed class WelcomeViewModel : ViewModelBase
{
    public WelcomeViewModel()
    {
        this.LoginCommand = new AsyncRelayCommand(this.OnLoginCommand);
        this.SignUpCommand = new AsyncRelayCommand(this.OnSignUpCommand);
    }

    public IAsyncRelayCommand LoginCommand { get; }
    public async Task OnLoginCommand()
    {
        await this.NavigateToAsync(nameof(LoginView), []);
    }

    public IAsyncRelayCommand SignUpCommand { get; }
    public async Task OnSignUpCommand()
    {
        await this.NavigateToAsync(nameof(SignUpView), []);
    }
}
