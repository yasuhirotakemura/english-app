using CommunityToolkit.Mvvm.Input;
using EnglishApp.Application.Apis;
using EnglishApp.Application.Dtos.Requests;
using EnglishApp.Application.Dtos.Responses;
using EnglishApp.Domain;
using EnglishApp.Domain.Interfaces;
using EnglishApp.Domain.Logics;
using EnglishApp.Domain.ValueObjects;
using EnglishApp.Maui.ViewModels.Bases;
using EnglishApp.Maui.Views;
using System.Diagnostics;

namespace EnglishApp.Maui.ViewModels;

public sealed class SignUpViewModel : ViewModelBase, IQueryAttributable
{
    private readonly IUserAuthApiService _userAuthApiService;

    public SignUpViewModel(IMessageService messageService, IUserAuthApiService userAuthApiService) : base(messageService)
    {
        this._userAuthApiService = userAuthApiService;

        this.SignInCommand = new AsyncRelayCommand(this.OnSignInCommand);
    }

    public void ApplyQueryAttributes(IDictionary<string, object> query)
    {

    }

    private string _email = String.Empty;
    public string Email
    {
        get => this._email;
        set => this.SetProperty(ref this._email, value);
    }

    private string _password = String.Empty;
    public string Password
    {
        get => this._password;
        set => this.SetProperty(ref this._password, value);
    }

    private string _confirmPassword = String.Empty;
    public string ConfirmPassword
    {
        get => this._confirmPassword;
        set => this.SetProperty(ref this._confirmPassword, value);
    }

    public IAsyncRelayCommand SignInCommand { get; }
    private async Task OnSignInCommand()
    {
        if (!await this.IsInputCorrect())
        {
            return;
        }

        // 画面への入力制御を行う -> アクションでコードビハインド側に通知

        PasswordHash passwordHash = PasswordHash.CreateFromPlainText(this._confirmPassword);

        UserAuthSignUpRequest request = UserAuthSignUpRequest.Create(this._email, passwordHash);

        if(await this._userAuthApiService.SignUpAsync(request) is UserAuthSignUpResponse response)
        {
            Shared.UserId = response.UserId;

            await this.NavigateToAsync(nameof(UserProfileSetupView), []);
        }
    }

    private async Task<bool> IsInputCorrect()
    {
        if (!EmailAnalysis.IsValid(this._email))
        {
            await this.MessageService.Show("エラー", "メールアドレスを正しく入力してください。");
            return false;
        }
        else if (String.IsNullOrEmpty(this._password))
        {
            await this.MessageService.Show("エラー", "パスワードを入力してください。");
            return false;
        }
        else if (this._password != this._confirmPassword)
        {
            await this.MessageService.Show("エラー", "パスワードが異なります。");
            return false;
        }

        return true;
    }
}