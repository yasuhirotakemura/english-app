using CommunityToolkit.Mvvm.Input;
using EnglishApp.Maui.ViewModels.Bases;
using System.Diagnostics;

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
        Debug.WriteLine("ログインします。");
    }

    public IAsyncRelayCommand SignUpCommand { get; }
    public async Task OnSignUpCommand()
    {
        Debug.WriteLine("新規登録します。");
    }
}
