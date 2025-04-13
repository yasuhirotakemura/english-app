using CommunityToolkit.Mvvm.Input;
using EnglishApp.Application;
using EnglishApp.Application.Dtos.UserProfile;
using EnglishApp.Application.Interfaces;
using EnglishApp.Domain;
using EnglishApp.Domain.Entities;
using EnglishApp.Domain.Interfaces;
using EnglishApp.Maui.Routes;
using EnglishApp.Maui.ViewModels.Bases;
using System.Collections.ObjectModel;

namespace EnglishApp.Maui.ViewModels;

public sealed class UserProfileSetupViewModel : ViewModelBase
{
    private readonly IUserProfileApiClient _userProfileApiClient;

    public UserProfileSetupViewModel(IMessageService messageService,
                                     INavigationService navigationService,
                                     IUserProfileApiClient userProfileApiService) : base(messageService,
                                                                                         navigationService)
    {
        this._userProfileApiClient = userProfileApiService;

        this.Genders = [];
        this.Grades = [];
        this.LearningPurposes = [];
        this.Prefectures = [];
        this.IconUris = [];

        this.StartCommand = new AsyncRelayCommand(this.OnStartCommand);

        Task.Run(this.LoadProfileSetupData);
    }

    private async Task LoadProfileSetupData()
    {
        ApiResult<UserSetupDataResponse> result = await this._userProfileApiClient.GetUserSetupDataAsync();

        if(result.IsSuccess && result.Data is UserSetupDataResponse response)
        {
            foreach (IconUri iconUri in response.IconUris)
            {
                this.IconUris.Add(iconUri);
            }

            foreach (GenderEntity genderEntity in response.Genders)
            {
                this.Genders.Add(genderEntity);
            }

            foreach (GradeEntity gradeEntity in response.Grades)
            {
                this.Grades.Add(gradeEntity);
            }

            foreach (LearningPurposeEntity learningPurpose in response.LearningPurposes)
            {
                this.LearningPurposes.Add(learningPurpose);
            }

            foreach (PrefectureEntity prefecture in response.Prefectures)
            {
                this.Prefectures.Add(prefecture);
            }
        }
        else if (result.ErrorMessage is string errorMesseage)
        {
            await this.MessageService.Show("エラー", errorMesseage);
        }
    }


    public ObservableCollection<IconUri> IconUris { get; }
    private IconUri? _selectedIconUri;
    public IconUri? SelectedIconUri
    {
        get => this._selectedIconUri;
        set => this.SetProperty(ref this._selectedIconUri, value);
    }

    private string _nickName = String.Empty;
    public string NickName
    {
        get => this._nickName;
        set => this.SetProperty(ref this._nickName, value);
    }

    public ObservableCollection<GenderEntity> Genders { get; }
    private GenderEntity? _selectedGender;
    public GenderEntity? SelectedGender
    {
        get => this._selectedGender;
        set => this.SetProperty(ref this._selectedGender, value);
    }

    public ObservableCollection<GradeEntity> Grades { get; }
    private GradeEntity? _selectedGrade;
    public GradeEntity? SelectedGrade
    {
        get => this._selectedGrade;
        set => this.SetProperty(ref this._selectedGrade, value);
    }

    public ObservableCollection<LearningPurposeEntity> LearningPurposes { get; }
    public LearningPurposeEntity? _selectedLearningPurpose;
    public LearningPurposeEntity? SelectedLearningPurpose
    {
        get => this._selectedLearningPurpose;
        set => this.SetProperty(ref this._selectedLearningPurpose, value);
    }

    private DateTime _birthDate = DateTime.Today;
    public DateTime BirthDate
    {
        get => this._birthDate;
        set => this.SetProperty(ref this._birthDate, value);
    }

    public ObservableCollection<PrefectureEntity> Prefectures { get; }
    private PrefectureEntity? _selectedPrefecture;
    public PrefectureEntity? SelectedPrefecture
    {
        get => this._selectedPrefecture;
        set => this.SetProperty(ref this._selectedPrefecture, value);
    }

    public IAsyncRelayCommand StartCommand { get; }
    private async Task OnStartCommand()
    {
        await this.LoadProfileSetupData();

        if(! await this.IsInputCorrect())
        {
            return;
        }

        UserProfileSetupRequest request = new(Shared.UserId,
                                              this._nickName,
                                              this._selectedGender!.Id,
                                              this._selectedGrade!.Id,
                                              this._selectedLearningPurpose!.Id,
                                              this._selectedPrefecture!.Id,
                                              this._birthDate,
                                              "",
                                              this._selectedIconUri!.Uri);

        ApiResult<UserProfileEntity> result = await this._userProfileApiClient.CreateAsync(request);

        if(result.IsSuccess && result.Data is UserProfileEntity userProfileEntity)
        {
            await this.NavigationService.NavigateToAsync(route: AppShellRoute.HomeView, isRoot: true);
        }
        else if (result.ErrorMessage is string profileSetupErrorMessage)
        {
            await this.MessageService.Show("エラー", profileSetupErrorMessage);
        }
    }

    private async Task<bool> IsInputCorrect()
    {
        if (this._selectedIconUri is null)
        {
            await this.MessageService.Show("エラー", "アイコンを選択してください。");
            return false;
        }
        else if (String.IsNullOrEmpty(this._nickName))
        {
            await this.MessageService.Show("エラー", "ニックネームを入力してください。");
            return false;
        }
        else if (this._selectedGender is null)
        {
            await this.MessageService.Show("エラー", "性別を選択してください。");
            return false;
        }
        else if (this._selectedGrade is null)
        {
            await this.MessageService.Show("エラー", "区分を選択してください。");
            return false;
        }
        else if (this._selectedLearningPurpose is null)
        {
            await this.MessageService.Show("エラー", "学習目的を選択してください。");
            return false;
        }
        else if (this._selectedPrefecture is null)
        {
            await this.MessageService.Show("エラー", "都道府県を選択してください。");
            return false;
        }

        return true;
    }
}
