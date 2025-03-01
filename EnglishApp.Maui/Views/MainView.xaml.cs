using EnglishApp.Maui.ViewModels;

namespace EnglishApp.Maui.Views;

public partial class MainView : ContentPage
{
    private INavigation _navigation;
    private readonly MainViewModel _mainViewModel;

    public MainView()
    {
        this.InitializeComponent();

        this._navigation = this.Navigation;

        this._mainViewModel = new();

        this.BindingContext = this._mainViewModel;
    }
}
