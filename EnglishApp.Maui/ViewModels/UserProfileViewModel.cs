using EnglishApp.Application;
using EnglishApp.Application.Interfaces;
using EnglishApp.Domain;
using EnglishApp.Domain.Entities;
using EnglishApp.Domain.Interfaces;
using EnglishApp.Maui.ViewModels.Bases;

namespace EnglishApp.Maui.ViewModels;

public sealed class UserProfileViewModel : ViewModelBase
{
    private readonly IUserProfileApiClient _userProfileApiService;

    public UserProfileViewModel(IMessageService messageService, IUserProfileApiClient userProfileApiService) : base(messageService)
    {
        this._userProfileApiService = userProfileApiService;

        Task.Run(this.LoadUserProfile);
    }

    private string _nickName = String.Empty;
    public string NickName
    {
        get => this._nickName;
        set => this.SetProperty(ref this._nickName, value);
    }

    private string _gender = String.Empty;
    public string Gender
    {
        get => this._gender;
        set => this.SetProperty(ref this._gender, value);
    }

    private string _grade = String.Empty;
    public string Grade
    {
        get => this._grade;
        set => this.SetProperty(ref this._grade, value);
    }

    private string _learningPurpose = String.Empty;
    public string LearningPurpose
    {
        get => this._learningPurpose;
        set => this.SetProperty(ref this._learningPurpose, value);
    }

    private string _prefecture = String.Empty;
    public string Prefecture
    {
        get => this._prefecture;
        set => this.SetProperty(ref this._prefecture, value);
    }

    private string _birthDate = String.Empty;
    public string BirthDate
    {
        get => this._birthDate;
        set => this.SetProperty(ref this._birthDate, value);
    }

    private string _lastLoginAt = String.Empty;
    public string LastLoginAt
    {
        get => this._lastLoginAt;
        set => this.SetProperty(ref this._lastLoginAt, value);
    }

    private string? _profileText;
    public string? ProfileText
    {
        get => this._profileText;
        set => this.SetProperty(ref this._profileText, value);
    }

    private string? _iconUri;
    public string? IconUri
    {
        get => this._iconUri;
        set => this.SetProperty(ref this._iconUri, value);
    }

    private async Task LoadUserProfile()
    {
        
        ApiResult<UserProfileEntity> profileResult = await this._userProfileApiService.GetAsync(Shared.UserId);

        if (profileResult.IsSuccess && profileResult.Data is UserProfileEntity entity)
        {
            this.NickName = entity.NickName;
            this.Gender = entity.Gender == 1 ? "男性" : "女性";
            this.Grade = entity.Grade;
            this.LearningPurpose = entity.LearningPurpose;
            this.Prefecture = entity.Prefecture;
            this.BirthDate = entity.BirthDate?.ToString("yyyy年MM月dd日") ?? "未設定";
            this.LastLoginAt = entity.LastLoginAt.ToString("yyyy/MM/dd HH:mm");
            this.ProfileText = String.IsNullOrWhiteSpace(entity.ProfileText) ? "未入力" : entity.ProfileText;
            this.IconUri = entity.IconUri;
        }
        else if (profileResult.ErrorMessage is string errorMessage)
        {
            await this.MessageService.Show("エラー", errorMessage);
        }
    }
}
