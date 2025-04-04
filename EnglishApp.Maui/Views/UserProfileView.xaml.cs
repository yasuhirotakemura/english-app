using EnglishApp.Maui.ViewModels;
using EnglishApp.Maui.Views.Bases;

namespace EnglishApp.Maui.Views;

public partial class UserProfileView : BaseContentPage
{
	public UserProfileView(UserProfileViewModel viewModel)
	{
		this.InitializeComponent();

        this.BindingContext = viewModel;
	}
}