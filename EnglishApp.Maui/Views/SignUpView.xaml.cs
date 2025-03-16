using EnglishApp.Maui.ViewModels;

namespace EnglishApp.Maui.Views;

public partial class SignUpView : ContentPage
{
	public SignUpView(SignUpViewModel signInViewModel)
	{
		this.InitializeComponent();

        this.BindingContext = signInViewModel;
	}
}