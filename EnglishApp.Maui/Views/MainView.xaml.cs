using EnglishApp.Maui.ViewModels;

namespace EnglishApp.Maui.Views;

public partial class MainView : ContentPage
{
    public MainView(MainViewModel mainVieModel)
    {
        this.InitializeComponent();

        this.BindingContext = mainVieModel;
    }
}