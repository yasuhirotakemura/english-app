using CommunityToolkit.Mvvm.Input;
using EnglishApp.Application.Apis;
using EnglishApp.Application.Dtos.Requests;
using EnglishApp.Application.Dtos.Responses;
using EnglishApp.Domain;
using EnglishApp.Domain.Entities;
using EnglishApp.Domain.Interfaces;
using EnglishApp.Domain.Logics;
using EnglishApp.Domain.ValueObjects;
using EnglishApp.Maui.ViewModels.Bases;
using System.Diagnostics;

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
        UserAuthSaltResponse? saltResponse = await this._userAuthApiService.GetSaltAsync(new(this._email));

        if(saltResponse is not UserAuthSaltResponse userAuthSaltResponse)
        {
            return;
        }

        PasswordHash passwordHash = PasswordHash.CreateFromPlainTextAndSaltBase64(this._password, userAuthSaltResponse.SaltBase64);
        UserAuthSignInRequest userAuthSignInRequest = UserAuthSignInRequest.Create(this._email, passwordHash);
        UserAuthSignInResponse? signInResponse = await this._userAuthApiService.SignInAsync(userAuthSignInRequest);

        if(signInResponse is UserAuthSignInResponse userAuthSignInResponse)
        {
            Shared.UserId = userAuthSignInResponse.UserId;

            UserSignInEntity entity = new(userAuthSignInResponse.UserId, userAuthSignInResponse.NickName, userAuthSignInResponse.IsEmailVerified);

            Dictionary<string, object> dict = new()
            {
                {nameof(UserSignInEntity), entity}
            };

            await this.NavigateToRootAsync("home", dict);
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