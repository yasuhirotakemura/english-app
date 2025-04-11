using CommunityToolkit.Mvvm.Input;
using EnglishApp.Application;
using EnglishApp.Application.Dtos.UserAuth;
using EnglishApp.Application.Interfaces;
using EnglishApp.Domain;
using EnglishApp.Domain.Entities;
using EnglishApp.Domain.Interfaces;
using EnglishApp.Maui.Routes;
using EnglishApp.Maui.ViewModels.Bases;
using EnglishApp.Maui.Views;

namespace EnglishApp.Maui.ViewModels;

public sealed class WelcomeViewModel : ViewModelBase
{
    private readonly IMasterApiClient _masterApiService;
    private readonly IUserAuthApiClient _userAuthApiService;

    public WelcomeViewModel(IMessageService messageService, IMasterApiClient masterApiService, IUserAuthApiClient userAuthApiService) : base(messageService)
    {
        this._masterApiService = masterApiService;
        this._userAuthApiService = userAuthApiService;

        this.LoginCommand = new AsyncRelayCommand(this.OnLoginCommand);
        this.SignUpCommand = new AsyncRelayCommand(this.OnSignUpCommand);

        Task.Run(this.LoadMaster);
    }

    private async Task LoadMaster()
    {
        await this._masterApiService.GetAsync();
    }

    public IAsyncRelayCommand LoginCommand { get; }
    public async Task OnLoginCommand()
    {
        await this.NavigateToAsync(nameof(SignInView));
    }

    public IAsyncRelayCommand SignUpCommand { get; }
    public async Task OnSignUpCommand()
    {
        await this.NavigateToAsync(nameof(SignUpView));
    }

    public async Task TryAutoLoginAsync()
    {
        string? token = await SecureStorage.GetAsync("AccessToken");

        if (!String.IsNullOrWhiteSpace(token))
        {
            this._userAuthApiService.SetAuthenticationHeaderValue(token);

            ApiResult<UserAuthSignInResponse> result = await this._userAuthApiService.AutoSignInAsync();

            if (result.IsSuccess && result.Data is UserAuthSignInResponse userAuthSignInResponse)
            {
                Shared.UserId = userAuthSignInResponse.UserId;

                await this.NavigateToRootAsync(AppShellRoute.HomeView);

                return;
            }
        }
    }
}
