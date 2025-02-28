namespace EnglishApp.Maui.ViewModels;

public class ProblemViewModel : BindableBase
{
    public ProblemViewModel()
    {
    }

    private string _title = String.Empty;
    public string Title
    {
        get => this._title;
        set => this.SetProperty(ref this._title, value);
    }

    private string _content = String.Empty;
    public string Content
    {
        get => this._content;
        set => this.SetProperty(ref this._content, value);
    }
}