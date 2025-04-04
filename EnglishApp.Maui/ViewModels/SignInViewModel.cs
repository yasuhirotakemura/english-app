using CommunityToolkit.Mvvm.Input;
using EnglishApp.Application;
using EnglishApp.Application.Apis;
using EnglishApp.Application.Dtos.Requests;
using EnglishApp.Application.Dtos.Responses;
using EnglishApp.Domain;
using EnglishApp.Domain.Entities;
using EnglishApp.Domain.Interfaces;
using EnglishApp.Domain.Logics;
using EnglishApp.Domain.ValueObjects;
using EnglishApp.Maui.Routes;
using EnglishApp.Maui.ViewModels.Bases;

namespace EnglishApp.Maui.ViewModels;

public sealed class SignInViewModel : ViewModelBase, IQueryAttributable
{
    private readonly IUserAuthApiService _userAuthApiService;

    public SignInViewModel(IMessageService messageService, IUserAuthApiService userAuthApiService) : base(messageService)
    {
        this._userAuthApiService = userAuthApiService;

        this.LoginCommand = new AsyncRelayCommand(this.OnLoginCommand);
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

    public IAsyncRelayCommand LoginCommand { get; }
    private async Task OnLoginCommand()
    {
        if(! await this.IsInputCorrect())
        {
            return;
        }

        UserAuthSaltRequest saltRequest = new(this._email);
        ApiResult<UserAuthSaltResponse> saltResponse = await this._userAuthApiService.GetSaltAsync(new(this._email));

        if(saltResponse.ErrorMessage is string saltErrorMessage)
        {
            await this.MessageService.Show("エラー", saltErrorMessage);
            return; 
        }

        if(saltResponse.Data is not UserAuthSaltResponse userAuthSaltResponse)
        {
            return;
        }

        PasswordHash passwordHash = PasswordHash.CreateFromPlainTextAndSaltBase64(this._password, userAuthSaltResponse.SaltBase64);

        UserAuthSignInRequest userAuthSignInRequest = UserAuthSignInRequest.Create(this._email, passwordHash);
        ApiResult<UserAuthSignInResponse> signInResponse = await this._userAuthApiService.SignInAsync(userAuthSignInRequest);

        if(signInResponse.IsSuccess && signInResponse.Data is UserAuthSignInResponse userAuthSignInResponse)
        {
            await SecureStorage.SetAsync("AccessToken", userAuthSignInResponse.AccessToken);

            Shared.UserId = userAuthSignInResponse.UserId;

            await this.NavigateToRootAsync(AppShellRoute.HomeView);
        }
        else if(signInResponse.ErrorMessage is string signInErrorMessage)
        {
            await this.MessageService.Show("エラー", signInErrorMessage);
        }
    }

    private async Task<bool> IsInputCorrect()
    {
        if (!EmailAnalysis.IsValid(this._email))
        {
            await this.MessageService.Show("エラー", "メールアドレスを正しく入力してください。");
        }

        return true;
    }
}