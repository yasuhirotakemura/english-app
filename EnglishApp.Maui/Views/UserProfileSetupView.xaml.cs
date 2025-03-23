using EnglishApp.Maui.ViewModels;

namespace EnglishApp.Maui.Views;

public partial class UserProfileSetupView : ContentPage
{
	public UserProfileSetupView(UserProfileSetupViewModel userProfileSetupViewModel)
	{
		this.InitializeComponent();

        this.BindingContext = userProfileSetupViewModel;
    }
}