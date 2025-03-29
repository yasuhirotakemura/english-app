using CommunityToolkit.Mvvm.Input;
using EnglishApp.Application;
using EnglishApp.Application.Apis;
using EnglishApp.Application.Dtos.Responses;
using EnglishApp.Domain.Entities;
using EnglishApp.Domain.Interfaces;
using EnglishApp.Maui.Routes;
using EnglishApp.Maui.ViewModels.Bases;
using EnglishApp.Maui.Views;

namespace EnglishApp.Maui.ViewModels;

public sealed class WelcomeViewModel : ViewModelBase
{
    private readonly IMasterApiService _masterApiService;
    private readonly IUserAuthApiService _userAuthApiService;

    public WelcomeViewModel(IMessageService messageService, IMasterApiService masterApiService, IUserAuthApiService userAuthApiService) : base(messageService)
    {
        this._masterApiService = masterApiService;
        this._userAuthApiService = userAuthApiService;

        this.LoginCommand = new AsyncRelayCommand(this.OnLoginCommand);
        this.SignUpCommand = new AsyncRelayCommand(this.OnSignUpCommand);

        Task.Run(this.LoadMaster);
        Task.Run(this.TryAutoLoginAsync);
    }

    private async Task LoadMaster()
    {
        await this._masterApiService.LoadAllMasterData();
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
        // Visibleをfalseにする

        string? token = await SecureStorage.GetAsync("AccessToken");

        if (!String.IsNullOrWhiteSpace(token))
        {
            bool setHeaderResult = this._userAuthApiService.CanAutoLoginAsync(token);

            if (setHeaderResult)
            {
                ApiResult<UserAuthSignInResponse> result = await this._userAuthApiService.AutoSignInAsync();

                if (result.IsSuccess && result.Data is UserAuthSignInResponse userAuthSignInResponse)
                {
                    UserSignInEntity entity = new(userId: userAuthSignInResponse.UserId,
                                                  nickName: userAuthSignInResponse.NickName,
                                                  isEmailVerified: userAuthSignInResponse.IsEmailVerified);

                    Dictionary<string, object> dict = new()
                    {
                        { nameof(UserSignInEntity), entity}
                    };

                    await this.NavigateToRootAsync(AppShellRoute.HomeView, dict);

                    return;
                }
            }
        }
    }
}
