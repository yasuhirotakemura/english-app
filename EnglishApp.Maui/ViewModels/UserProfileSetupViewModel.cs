using CommunityToolkit.Mvvm.Input;
using EnglishApp.Domain.Entities;
using EnglishApp.Domain.Interfaces;
using EnglishApp.Domain.StaticValues;
using EnglishApp.Maui.ViewModels.Bases;
using System.Collections.ObjectModel;

namespace EnglishApp.Maui.ViewModels;

public sealed class UserProfileSetupViewModel : ViewModelBase, IQueryAttributable
{
    public UserProfileSetupViewModel(IMessageService messageService) : base(messageService)
    {
        this.GenderList = new ObservableCollection<UserGenderEntity>([new UserGenderEntity(1, "男性"), new UserGenderEntity(2, "女性"), new UserGenderEntity(3, "その他")]);
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

    public ObservableCollection<UserGenderEntity> GenderList { get; }
    private UserGenderEntity? _selectedGender;
    public UserGenderEntity? SelectedGender
    {
        get => this._selectedGender;
        set => this.SetProperty(ref this._selectedGender, value);
    }

    public ObservableCollection<UserGradeEntity> GradeList { get; }
    private UserGradeEntity? _selectedGrade;
    public UserGradeEntity? SelectedGrade
    {
        get => this._selectedGrade;
        set => this.SetProperty(ref this._selectedGrade, value);
    }

    public ObservableCollection<UserLearningPurposeEntity> LearningPurposeList { get; }
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

    public ObservableCollection<PrefectureEntity> PrefectureList { get; }
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
    }

    private async Task<bool> IsInputCorrect()
    {
        if(String.IsNullOrEmpty(this._nickName))
        {
            await this.MessageService.Show("エラー", "ニックネームを入力してください。");
            return false;
        }
        else if(this._selectedGender is null)
        {
            await this.MessageService.Show("エラー", "性別を選択してください。");
            return false;
        }
        else if(this._selectedGrade is null)
        {
            await this.MessageService.Show("エラー", "区分を選択してください。");
            return false;
        }
        else if(this._selectedLearningPurpose is null)
        {
            await this.MessageService.Show("エラー", "学習目的を選択してください。");
            return false;
        }
        else if(this._selectedPrefecture is null)
        {
            await this.MessageService.Show("エラー", "都道府県を選択してください。");
            return false;
        }

        return true;
    }
}
