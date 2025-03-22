using CommunityToolkit.Mvvm.Input;
using EnglishApp.Domain.Entities;
using EnglishApp.Domain.Enums;
using EnglishApp.Domain.Helpers;
using EnglishApp.Domain.Interfaces;
using EnglishApp.Domain.StaticValues;
using EnglishApp.Maui.ViewModels.Bases;
using System.Collections.ObjectModel;

namespace EnglishApp.Maui.ViewModels;

public sealed class UserProfileSetupViewModel : ViewModelBase, IQueryAttributable
{
    public UserProfileSetupViewModel(IMessageService messageService) : base(messageService)
    {
        this.GenderList = [.. EnumHelper.ToDictionary<Gender>()];
        this.GradeList = [.. MasterData.UserGrades];
        this.LearningPurposeList = [.. MasterData.UserLearningPurposes];
        this.PrefectureList = [.. MasterData.Prefectures];

        this.StartCommand = new AsyncRelayCommand(this.OnStartCommand);
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

    public ObservableCollection<KeyValuePair<int, string>> GenderList { get; } = [];
    private byte _selectedGender;
    public byte SelectedGender
    {
        get => this._selectedGender;
        set
        {
            this._selectedGender = value;
            this.SetProperty(ref this._selectedGender, value);
        }
    }

    public ObservableCollection<UserGradeEntity> GradeList { get; }
    private byte _selectedGrade;
    public byte SelectedGrade
    {
        get => this._selectedGrade;
        set
        {
            this._selectedGrade = value;
            this.SetProperty(ref this._selectedGrade, value);
        }
    }

    public ObservableCollection<UserLearningPurposeEntity> LearningPurposeList { get; }
    public byte _selectedLearningPurpose;
    public byte SelectedLearningPurpose
    {
        get => this._selectedLearningPurpose;
        set
        {
            this._selectedLearningPurpose = value;
            this.SetProperty(ref this._selectedLearningPurpose, value);
        }
    }

    private DateTime _birthDate = DateTime.Today;
    public DateTime BirthDate
    {
        get => this._birthDate;
        set => this.SetProperty(ref this._birthDate, value);
    }

    public ObservableCollection<PrefectureEntity> PrefectureList { get; }
    private byte _selectedPrefecture;
    public byte SelectedPrefecture
    {
        get => this._selectedPrefecture;
        set => this.SetProperty(ref this._selectedPrefecture, value);
    }

    public IAsyncRelayCommand StartCommand { get; }
    private async Task OnStartCommand()
    {

    }

    private async Task<bool> IsInputCorrect()
    {
        if(String.IsNullOrEmpty(this._nickName))
        {
            await this.MessageService.Show("エラー", "ニックネームを入力してください。");
        }
    }
}
