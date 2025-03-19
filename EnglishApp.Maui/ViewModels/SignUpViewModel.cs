using CommunityToolkit.Mvvm.Input;
using EnglishApp.Domain.Interfaces;
using EnglishApp.Domain.Logics;
using EnglishApp.Maui.ViewModels.Bases;
using System.Diagnostics;

namespace EnglishApp.Maui.ViewModels;

public sealed class SignUpViewModel : ViewModelBase, IQueryAttributable
{
    private readonly IMessageService _messageService;

    public SignUpViewModel(IMessageService messageService)
    {
        this._messageService = messageService;

        this.SignInCommand = new AsyncRelayCommand(this.OnSignInCommand);
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

    private string _confirmPassword = String.Empty;
    public string ConfirmPassword
    {
        get => this._confirmPassword;
        set => this.SetProperty(ref this._confirmPassword, value);
    }

    public IAsyncRelayCommand SignInCommand { get; }
    private async Task OnSignInCommand()
    {
        if(! await this.IsInputCorrect())
        {
            return;
        }

        // API経由でサーバー側に Email とハッシュ化した Password を渡し、応答を見る。
        byte[] salt;
        byte[] passwordHash = PasswordHasher.HashPassword(this._confirmPassword, out salt);


    }

    private async Task<bool> IsInputCorrect()
    {
        if (!EmailAnalysis.IsValid(this._email))
        {
            await this._messageService.Show("エラー", "メールアドレスを正しく入力してください。");
            return false;
        }
        else if (String.IsNullOrEmpty(this._password))
        {
            await this._messageService.Show("エラー", "パスワードを入力してください。");
            return false;
        }
        else if (this._password != this._confirmPassword)
        {
            await this._messageService.Show("エラー", "パスワードが異なります。");
            return false;
        }

        return true;
    }

    //private string _nickName = String.Empty;
    //public string NickName
    //{
    //    get => this._nickName;
    //    set => this.SetProperty(ref this._nickName, value);
    //}

    //public ObservableCollection<KeyValuePair<byte, string>> GenderList { get; }
    //private byte _selectedGender;
    //public byte SelectedGender
    //{
    //    get => this._selectedGender;
    //    set
    //    {
    //        this._selectedGender = value;
    //        this.SetProperty(ref this._selectedGender, value);
    //    }
    //}

    //public ObservableCollection<UserGradeEntity> GradeList { get; }
    //private byte _selectedGrade;
    //public byte SelectedGrade
    //{
    //    get => this._selectedGrade;
    //    set
    //    {
    //        this._selectedGrade = value;
    //        this.SetProperty(ref this._selectedGrade, value);
    //    }
    //}

    //public ObservableCollection<UserLearningPurposeEntity> LearningPurposeList { get; }
    //public byte _selectedLearningPurpose;
    //public byte SelectedLearningPurpose
    //{
    //    get => this._selectedLearningPurpose;
    //    set
    //    {
    //        this._selectedLearningPurpose = value;
    //        this.SetProperty(ref this._selectedLearningPurpose, value);
    //    }
    //}

    //private DateTime _birthDate = DateTime.Today;
    //public DateTime BirthDate
    //{
    //    get => this._birthDate;
    //    set => this.SetProperty(ref this._birthDate, value);
    //}

    //public ObservableCollection<PrefectureEntity> PrefectureList { get; }
    //private byte _selectedPrefecture;
    //public byte SelectedPrefecture
    //{
    //    get => this._selectedPrefecture;
    //    set => this.SetProperty(ref this._selectedPrefecture, value);
    //}
}
