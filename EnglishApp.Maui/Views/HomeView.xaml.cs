using EnglishApp.Maui.ViewModels;

namespace EnglishApp.Maui.Views;

public partial class HomeView : ContentPage
{
    public HomeView(HomeViewModel mainVieModel)
    {
        this.InitializeComponent();

        this.BindingContext = mainVieModel;
    }
}