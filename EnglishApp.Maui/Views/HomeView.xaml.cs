using EnglishApp.Maui.ViewModels;
using EnglishApp.Maui.Views.Bases;

namespace EnglishApp.Maui.Views;

public partial class HomeView : BaseContentPage
{
    public HomeView(HomeViewModel viewModel)
    {
        this.InitializeComponent();

        this.BindingContext = viewModel;
    }
}