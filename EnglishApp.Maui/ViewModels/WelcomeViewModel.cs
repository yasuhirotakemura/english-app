using CommunityToolkit.Mvvm.Input;
using EnglishApp.Application;
using EnglishApp.Application.Dtos.UserAuth;
using EnglishApp.Application.Interfaces;
using EnglishApp.Domain;
using EnglishApp.Domain.Interfaces;
using EnglishApp.Maui.Routes;
using EnglishApp.Maui.ViewModels.Bases;
using EnglishApp.Maui.Views;

namespace EnglishApp.Maui.ViewModels;

public sealed class WelcomeViewModel : ViewModelBase
{
    private readonly IUserAuthApiClient _userAuthApiService;

    public WelcomeViewModel(IMessageService messageService,
                            INavigationService navigationService,
                            IUserAuthApiClient userAuthApiService) : base(messageService,
                                                                          navigationService)
    {
        this._userAuthApiService = userAuthApiService;

        this.LoginCommand = new AsyncRelayCommand(this.OnLoginCommand);
        this.SignUpCommand = new AsyncRelayCommand(this.OnSignUpCommand);
    }

    public IAsyncRelayCommand LoginCommand { get; }
    public async Task OnLoginCommand()
    {
        await this.NavigationService.NavigateToAsync(nameof(SignInView));
    }

    public IAsyncRelayCommand SignUpCommand { get; }
    public async Task OnSignUpCommand()
    {
        await this.NavigationService.NavigateToAsync(nameof(SignUpView));
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

                await this.NavigationService.NavigateToAsync(route: AppShellRoute.HomeView, isRoot: true);

                return;
            }
        }
    }
}
