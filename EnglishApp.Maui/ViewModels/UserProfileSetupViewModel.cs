using CommunityToolkit.Mvvm.Input;
using EnglishApp.Application;
using EnglishApp.Application.Dtos.UserProfile;
using EnglishApp.Application.Interfaces;
using EnglishApp.Domain;
using EnglishApp.Domain.Entities;
using EnglishApp.Domain.Interfaces;
using EnglishApp.Domain.StaticValues;
using EnglishApp.Maui.Routes;
using EnglishApp.Maui.ViewModels.Bases;
using System.Collections.ObjectModel;

namespace EnglishApp.Maui.ViewModels;

public sealed class UserProfileSetupViewModel : ViewModelBase, IQueryAttributable
{
    private readonly IUserProfileApiClient _userProfileApiService;

    public UserProfileSetupViewModel(IMessageService messageService, IUserProfileApiClient userProfileApiService) : base(messageService)
    {
        this._userProfileApiService = userProfileApiService;

        this.StartCommand = new AsyncRelayCommand(this.OnStartCommand);

        this.IconUris = [];
        // 性別どうにかしないと
        this.Genders = [.. MasterData.UserGenders];
        this.Grades = [.. MasterData.UserGrades];
        this.LearningPurposes = [.. MasterData.UserLearningPurposes];
        this.Prefectures = [.. MasterData.Prefectures];

        Task.Run(this.LoadProfileIcons);
    }

    public ObservableCollection<IconUri> IconUris { get; }
    private IconUri? _selectedIconUri;
    public IconUri? SelectedIconUri
    {
        get => this._selectedIconUri;
        set => this.SetProperty(ref this._selectedIconUri, value);
    }

    private async Task LoadProfileIcons()
    {
        ApiResult<IconUri[]> iconUrisResult = await this._userProfileApiService.GetProfileImageUris();

        if(iconUrisResult.IsSuccess && iconUrisResult.Data is IconUri[] profileIconsUris)
        {
            foreach (IconUri iconUri in profileIconsUris)
            {
                this.IconUris.Add(iconUri);
            }
        }
        else if(iconUrisResult.ErrorMessage is string errorMesseage)
        {
            await this.MessageService.Show("エラー", errorMesseage);
        }
    }

    public void ApplyQueryAttributes(IDictionary<string, object> query)
    {
    }

    private string _nickName = String.Empty;
    public string NickName
    {
        get => this._nickName;
        set => this.SetProperty(ref this._nickName, value);
    }

    public ObservableCollection<UserGenderEntity> Genders { get; }
    private UserGenderEntity? _selectedGender;
    public UserGenderEntity? SelectedGender
    {
        get => this._selectedGender;
        set => this.SetProperty(ref this._selectedGender, value);
    }

    public ObservableCollection<UserGradeEntity> Grades { get; }
    private UserGradeEntity? _selectedGrade;
    public UserGradeEntity? SelectedGrade
    {
        get => this._selectedGrade;
        set => this.SetProperty(ref this._selectedGrade, value);
    }

    public ObservableCollection<UserLearningPurposeEntity> LearningPurposes { get; }
    public UserLearningPurposeEntity? _selectedLearningPurpose;
    public UserLearningPurposeEntity? SelectedLearningPurpose
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

        ApiResult<UserProfileEntity> response = await this._userProfileApiService.CreateAsync(request);

        if(response.IsSuccess && response.Data is UserProfileEntity userProfileEntity)
        {
            await this.NavigateToRootAsync(AppShellRoute.HomeView);
        }
        else if (response.ErrorMessage is string profileSetupErrorMessage)
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
