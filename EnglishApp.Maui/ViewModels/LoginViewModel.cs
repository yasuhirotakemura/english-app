using CommunityToolkit.Mvvm.Input;
using EnglishApp.Maui.ViewModels.Bases;

namespace EnglishApp.Maui.ViewModels;

public sealed class LoginViewModel : ViewModelBase, IQueryAttributable
{
    public LoginViewModel()
    {
        this.LoginCommand = new AsyncRelayCommand(this.OnLoginCommand);
    }

    public void ApplyQueryAttributes(IDictionary<string, object> query)
    {

    }

    private string _userEmail = String.Empty;
    public string UserEmail
    {
        get => this._userEmail;
        set => this.SetProperty(ref this._userEmail, value);
    }

    private string _userPassword = String.Empty;
    public string UserPassword
    {
        get => this._userPassword;
        set => this.SetProperty(ref this._userPassword, value);
    }

    public IAsyncRelayCommand LoginCommand { get; }
    private async Task OnLoginCommand()
    {
        // API経由でサーバー側に Email とハッシュ化した Password を渡し、応答を見る。
    }
}