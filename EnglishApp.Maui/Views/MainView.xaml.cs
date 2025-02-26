using EnglishApp.Maui.ViewModels;

namespace EnglishApp.Maui.Views;

public partial class MainView : ContentPage
{
    public MainView()
    {
        this.InitializeComponent();

        this.BindingContext = new MainViewModel();
    }
}
