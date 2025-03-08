using CommunityToolkit.Mvvm.Input;
using EnglishApp.Maui.ViewModels.Bases;

namespace EnglishApp.Maui.ViewModels;

public sealed class LoginViewModel : ViewModelBase
{
    public LoginViewModel()
    {
        this.LoginButton = new AsyncRelayCommand(this.OnLoginButton);
    }

    private string _userEmail = String.Empty;
    public string UserEmail
    {
        get => this._userEmail;
        set => this.SetProperty(ref this._userEmail, nameof(this.UserEmail));
    }

    private string _userPassword = String.Empty;
    public string UserPassword
    {
        get => this._userPassword;
        set => this.SetProperty(ref this._userPassword, nameof(this.UserPassword));
    }

    public IAsyncRelayCommand LoginButton { get; }
    private async Task OnLoginButton()
    {
        // API経由でサーバー側に Email とハッシュ化した Password を渡し、応答を見る。
    }
}