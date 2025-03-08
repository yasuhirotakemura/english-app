using EnglishApp.Maui.ViewModels;

namespace EnglishApp.Maui.Views;

public partial class LoginView : ContentPage
{
	public LoginView(LoginViewModel loginViewModel)
	{
		this.InitializeComponent();

        this.BindingContext = loginViewModel;
	}
}