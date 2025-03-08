using EnglishApp.Maui.ViewModels;

namespace EnglishApp.Maui.Views;

public partial class WelcomeView : ContentPage
{
	public WelcomeView(WelcomeViewModel welcomeViewModel)
	{
		this.InitializeComponent();

        this.BindingContext = welcomeViewModel;
	}
}