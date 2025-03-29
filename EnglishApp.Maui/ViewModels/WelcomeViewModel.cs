using CommunityToolkit.Mvvm.Input;
using EnglishApp.Application.Apis;
using EnglishApp.Domain.Interfaces;
using EnglishApp.Maui.ViewModels.Bases;
using EnglishApp.Maui.Views;
using System.Diagnostics;

namespace EnglishApp.Maui.ViewModels;

public sealed class WelcomeViewModel : ViewModelBase
{
    private readonly IUserAuthApiService _userAuthApiService;

    public WelcomeViewModel(IMessageService messageService, IUserAuthApiService userAuthApiService) : base(messageService)
    {
        this._userAuthApiService = userAuthApiService;

        this.LoginCommand = new AsyncRelayCommand(this.OnLoginCommand);
        this.SignUpCommand = new AsyncRelayCommand(this.OnSignUpCommand);

        Task.Run(async () =>
        {
            string? accessToken = await SecureStorage.GetAsync("AccessToken");

            bool canAutoLogin = this._userAuthApiService.TryAutoLoginAsync(accessToken);

            if (canAutoLogin)
            {
                Debug.WriteLine("自動ログイン可能");
            }
        });
    }

    public IAsyncRelayCommand LoginCommand { get; }
    public async Task OnLoginCommand()
    {
        await this.NavigateToAsync(nameof(SignInView), []);
    }

    public IAsyncRelayCommand SignUpCommand { get; }
    public async Task OnSignUpCommand()
    {
        await this.NavigateToAsync(nameof(SignUpView), []);
    }
}
